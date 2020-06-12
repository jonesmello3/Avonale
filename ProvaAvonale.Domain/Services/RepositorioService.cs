using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProvaAvonale.Domain.Entities;
using ProvaAvonale.Domain.Interfaces.Repository;
using ProvaAvonale.Domain.Interfaces.Service;
using ProvaAvonale.Domain.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace ProvaAvonale.Domain.Services
{
    public class RepositorioService : ServiceBase<Repositorio>, IRepositorioService
    {

        #region Variáveis
        private readonly IRepositorioRepository repositorioRepository;
        #endregion

        #region Construtor
        public RepositorioService(IRepositorioRepository repositorioRepository) : base(repositorioRepository)
        {
            this.repositorioRepository = repositorioRepository;
        }
        #endregion

        #region BaseUrl
        public static string BaseUrl
        {
            get
            {
                return "https://api.github.com/";
            }
        }
        #endregion

        #region ListarRepositoriosPublicos
        public async Task<List<Repositorio>> ListarRepositoriosPublicos()
        {
            var url = "repositories";
            Uri baseUri = new Uri(BaseUrl + url);
            var clientHandler = new HttpClientHandler();
            HttpClient client = new HttpClient(clientHandler);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            ProductHeaderValue header = new ProductHeaderValue("jonesmello3", Assembly.GetExecutingAssembly().GetName().Version.ToString());
            ProductInfoHeaderValue userAgent = new ProductInfoHeaderValue(header);
            client.DefaultRequestHeaders.UserAgent.Add(userAgent);

            client.BaseAddress = baseUri;
            HttpResponseMessage response = await client.GetAsync(baseUri);

            if (response.IsSuccessStatusCode)
            {
                var pathArquivos = DiretorioVirtual.ObterDiretorioVirtual();
                var nomeArquivo = $"RepositoriosFavoritos.json";
                var caminho = $"{pathArquivos}{nomeArquivo}";
                var reposi = JsonConvert.DeserializeObject<List<Repositorio>>(File.ReadAllText(caminho));

                var jsonString = await response.Content.ReadAsStringAsync();
                var repositorios = JsonConvert.DeserializeObject<List<Repositorio>>(jsonString);

                foreach (var item in repositorios)
                {
                    foreach (var repos in reposi)
                    {
                        if (item.Id == repos.Id)
                        {
                            item.IsFavorito = true;
                        }
                    }
                }
                return repositorios;
            }

            return null;
        }
        #endregion

        #region PesquisarRepositoriosPorNome
        public async Task<IEnumerable<Repositorio>> PesquisarRepositoriosPorNome(string nome)
        {
            var url = "search/repositories?q=" + nome;
            Uri baseUri = new Uri(BaseUrl + url);
            var clientHandler = new HttpClientHandler();
            HttpClient client = new HttpClient(clientHandler);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            ProductHeaderValue header = new ProductHeaderValue("jonesmello3", Assembly.GetExecutingAssembly().GetName().Version.ToString());
            ProductInfoHeaderValue userAgent = new ProductInfoHeaderValue(header);
            client.DefaultRequestHeaders.UserAgent.Add(userAgent);

            client.BaseAddress = baseUri;
            HttpResponseMessage response = await client.GetAsync(baseUri);

            List<Repositorio> listaRepositorios = new List<Repositorio>();

            if (response.IsSuccessStatusCode)
            {
                JArray repositorios = (JArray)JObject.Parse(response.Content.ReadAsStringAsync().Result)["items"];

                foreach (var repositorio in repositorios)
                {
                    listaRepositorios.Add(new Repositorio
                    {
                        Id = Convert.ToInt32(repositorio["id"].ToString()),
                        Nome = repositorio["name"].ToString(),
                        NomeCompleto = repositorio["full_name"].ToString(),
                        Privado = repositorio["private"].ToString(),
                        Owner = new Owner
                        {
                            Login = repositorio["owner"]["login"].ToString(),
                            Type = repositorio["owner"]["type"].ToString(),
                            SiteAdmin = Convert.ToBoolean(repositorio["owner"]["site_admin"])
                        },
                        Descricao = repositorio["description"].ToString(),
                        LanguagesUrl = repositorio["language"].ToString(),
                    });
                }

                PreenchendoJson(listaRepositorios);

                return listaRepositorios;
            }

            return null;
        }
        #endregion

        #region ObterColaboradoresRepositorio
        private IEnumerable<Contribuidor> ObterContribuidoreRepositorio(string url)
        {
            Uri baseUri = new Uri(url);
            var clientHandler = new HttpClientHandler();
            HttpClient client = new HttpClient(clientHandler);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            ProductHeaderValue header = new ProductHeaderValue("jonesmello3", Assembly.GetExecutingAssembly().GetName().Version.ToString());
            ProductInfoHeaderValue userAgent = new ProductInfoHeaderValue(header);
            client.DefaultRequestHeaders.UserAgent.Add(userAgent);

            client.BaseAddress = baseUri;
            HttpResponseMessage response = client.GetAsync(baseUri).Result;

            if (response.IsSuccessStatusCode)
            {
                var jsonString = response.Content.ReadAsStringAsync();
                var contribuidor = JsonConvert.DeserializeObject<IEnumerable<Contribuidor>>(jsonString.Result);
                return contribuidor;
            }

            return null;
        }
        #endregion

        #region ObterLinguagem
        private IEnumerable<Linguagem> ObterLinguagem(string url)
        {
            Uri baseUri = new Uri(url);
            var clientHandler = new HttpClientHandler();
            HttpClient client = new HttpClient(clientHandler);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            ProductHeaderValue header = new ProductHeaderValue("jonesmello3", Assembly.GetExecutingAssembly().GetName().Version.ToString());
            ProductInfoHeaderValue userAgent = new ProductInfoHeaderValue(header);
            client.DefaultRequestHeaders.UserAgent.Add(userAgent);

            client.BaseAddress = baseUri;
            HttpResponseMessage response = client.GetAsync(baseUri).Result;

            if (response.IsSuccessStatusCode)
            {
                var jsonString = response.Content.ReadAsStringAsync();

                if (jsonString.Result != "")
                {
                    var srtLimpa = jsonString.Result.Replace(" ", "").Replace("{", "").Replace("}", "").Replace("\"", "");
                    List<Linguagem> linguagens = new List<Linguagem>();
                    
                    if (srtLimpa.IndexOf(",") > -1)
                    {
                        var arr = srtLimpa.Split(',');
                        int cont = 0;

                        foreach (var item in arr)
                        {
                            cont++;
                            Linguagem linguagem = new Linguagem();
                            var ar = item.Split(':');

                            if (cont == arr.Length) 
                            {
                                linguagem.Descricao = ar[0] + " .";
                            }
                            else 
                            {
                                linguagem.Descricao = ar[0] + " ,";
                            }

                            linguagem.Id = Convert.ToInt32(ar[1]);

                            linguagens.Add(linguagem);
                        }
                    }
                    else
                    {
                        Linguagem linguagem = new Linguagem();
                        var arr = srtLimpa.Split(':');
                        linguagem.Descricao = arr[0];
                        linguagem.Id = Convert.ToInt32(arr[1]);

                        linguagens.Add(linguagem);
                    }

                    return linguagens;
                }
            }

            return null;
        }
        #endregion

        #region ObterRepositorioPorId
        public async Task<Repositorio> ObterRepositorioPorId(int id)
        {
            var url = "repositories/" + id;
            Uri baseUri = new Uri(BaseUrl + url);
            var clientHandler = new HttpClientHandler();
            HttpClient client = new HttpClient(clientHandler);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            ProductHeaderValue header = new ProductHeaderValue("jonesmello3", Assembly.GetExecutingAssembly().GetName().Version.ToString());
            ProductInfoHeaderValue userAgent = new ProductInfoHeaderValue(header);
            client.DefaultRequestHeaders.UserAgent.Add(userAgent);

            client.BaseAddress = baseUri;
            HttpResponseMessage response = await client.GetAsync(baseUri);

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var repositorio = JsonConvert.DeserializeObject<Repositorio>(jsonString);

                repositorio.Contribuidores = ObterContribuidoreRepositorio(repositorio.ContributorsUrl);
                repositorio.Linguagens = ObterLinguagem(repositorio.LanguagesUrl);

                return repositorio;
            }

            return null;
        }
        #endregion

        #region ListarRepositoriosUsuario
        public async Task<IEnumerable<Repositorio>> ListarRepositoriosUsuario(string userName)
        {
            var url = "users/" + userName + "/repos";
            Uri baseUri = new Uri(BaseUrl + url);
            var clientHandler = new HttpClientHandler();
            HttpClient client = new HttpClient(clientHandler);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            ProductHeaderValue header = new ProductHeaderValue("jonesmello3", Assembly.GetExecutingAssembly().GetName().Version.ToString());
            ProductInfoHeaderValue userAgent = new ProductInfoHeaderValue(header);
            client.DefaultRequestHeaders.UserAgent.Add(userAgent);

            client.BaseAddress = baseUri;
            HttpResponseMessage response = await client.GetAsync(baseUri);

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var repositorio = JsonConvert.DeserializeObject<IEnumerable<Repositorio>>(jsonString);

                return repositorio;
            }

            return null;
        }
        #endregion

        #region AdicionarRepositorioAosFavoritos
        public async Task<Repositorio> AdicionarRepositorioAosFavoritos(int id)
        {
            var pathArquivos = DiretorioVirtual.ObterDiretorioVirtual();
            var nomeArquivo = $"RepositoriosFavoritos.json";
            var repositorio = await ObterRepositorioPorId(id);
            var caminho = $"{pathArquivos}{nomeArquivo}";
            var repositorios = JsonConvert.DeserializeObject<List<Repositorio>>(File.ReadAllText(caminho));

            if (repositorio != null)
            {
                if (repositorios == null)
                {
                    repositorios = new List<Repositorio>();
                    repositorios.Add(repositorio);
                }
                else
                {
                    repositorios.Add(repositorio);
                }

                var repo = JsonConvert.SerializeObject(repositorios, Formatting.Indented);

                File.Delete(caminho);

                using (var streamReader = new StreamWriter(caminho, true))
                {
                    streamReader.WriteLine(repo.ToString());

                    streamReader.Close();
                }
            }

            return repositorio;
        }
        #endregion

        #region MostrarFavoritos
        public IEnumerable<Repositorio> MostrarFavoritos()
        {
            var pathArquivos = DiretorioVirtual.ObterDiretorioVirtual();
            var nomeArquivo = $"RepositoriosFavoritos.json";
            var caminho = $"{pathArquivos}{nomeArquivo}";

            var repositorios = JsonConvert.DeserializeObject<IEnumerable<Repositorio>>(File.ReadAllText(caminho));
            return repositorios;
        }
        #endregion

        #region RemoverFavoritos
        public void RemoverFavoritos(int id)
        {
            var pathArquivos = DiretorioVirtual.ObterDiretorioVirtual();
            var nomeArquivo = $"RepositoriosFavoritos.json";
            var caminho = $"{pathArquivos}{nomeArquivo}";
            var repositorios = JsonConvert.DeserializeObject<List<Repositorio>>(File.ReadAllText(caminho));

            if (repositorios != null)
            {
                var repositorio = repositorios.FirstOrDefault(repos => repos.Id == id);
                repositorios.Remove(repositorio);
            }
           

            var repo = JsonConvert.SerializeObject(repositorios, Formatting.Indented);

            File.Delete(caminho);

            using (var streamReader = new StreamWriter(caminho, true))
            {
                streamReader.WriteLine(repo.ToString());

                streamReader.Close();
            }
        }
        #endregion

        private void PreenchendoJson(List<Repositorio> repositorios) {
            var pathArquivos = DiretorioVirtual.ObterDiretorioVirtual();
            var nomeArquivo = $"RepositoriosFavoritos.json";
            var caminho = $"{pathArquivos}{nomeArquivo}";
            var reposi = JsonConvert.DeserializeObject<List<Repositorio>>(File.ReadAllText(caminho));

            foreach (var item in repositorios)
            {
                foreach (var repos in reposi)
                {
                    if (item.Id == repos.Id)
                    {
                        item.IsFavorito = true;
                    }
                }
            }
        } 
    }
}
