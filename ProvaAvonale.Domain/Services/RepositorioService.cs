using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProvaAvonale.Domain.Entities;
using ProvaAvonale.Domain.Interfaces.Repository;
using ProvaAvonale.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Threading.Tasks;

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
                var jsonString = await response.Content.ReadAsStringAsync();
                var repositorio = JsonConvert.DeserializeObject<List<Repositorio>>(jsonString);
                return repositorio;
            }

            return null;
        }
        #endregion

        #region ListarRepositoriosUsuario
        public async Task<IEnumerable<Repositorio>> ListarRepositoriosUsuario(string userName)
        {
            var url = "search/repositories?q=" + userName;
            //search / repositories ? q = tetris + language : assembly & sort = stars & order = desc
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
                return listaRepositorios;
            }

            return null;
        }
        #endregion

        #region ObterColaboradoresRepositorio
        public IEnumerable<Contribuidor> ObterColaboradoresRepositorio(Usuario usuario)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region ListarRepositoriosPublicos
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
                return repositorio;
            }

            return null;
        }
        #endregion

        private async Task<HttpResponseMessage> ConfigurarcaoGitHub(string url = "")
        {
            Uri baseUri = new Uri(BaseUrl + url);
            var clientHandler = new HttpClientHandler();
            HttpClient client = new HttpClient(clientHandler);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            ProductHeaderValue header = new ProductHeaderValue("jonesmello3", Assembly.GetExecutingAssembly().GetName().Version.ToString());
            ProductInfoHeaderValue userAgent = new ProductInfoHeaderValue(header);
            client.DefaultRequestHeaders.UserAgent.Add(userAgent);

            client.BaseAddress = baseUri;
            HttpResponseMessage response = await client.GetAsync(baseUri);

            return response;
        }
    }
}
