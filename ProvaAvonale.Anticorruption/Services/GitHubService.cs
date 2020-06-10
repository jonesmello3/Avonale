using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProvaAvonale.Anticorruption.Interfaces;
using ProvaAvonale.ApplicationService.Models;
using ProvaAvonale.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Threading.Tasks;

namespace ProvaAvonale.Anticorruption.Services
{
    public class GitHubService : IGitHubService
    {
        public static string BaseUrl
        {
            get 
            {
                return "https://api.github.com/repositories";
            }
        }

        public async Task<IEnumerable<Repositorio>> ListarRepositoriosPublicos()
        {
            List<Repositorio> listaRepositorios = new List<Repositorio>();

            try
            {
                //var url = "repositories?since=" + paginacao;
                //HttpClient client = new HttpClient();
                //Repositorio repositorio = null;
                //HttpResponseMessage response = await client.GetAsync(BaseUrl + url);

                //if (response.IsSuccessStatusCode)
                //{
                //    repositorio = await response.Content.ReadAsAsync<Repositorio>();
                //}
                //return product;

                //HttpClient cliente = new HttpClient();
                //HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, BaseUrl);
                //cliente.DefaultRequestHeaders.Accept.Add(re);

                //HttpResponseMessage response = HttpInstance.GetHttpClientInstance().SendAsync(request).Result;

                //HttpWebRequest request = WebRequest.Create(BaseUrl) as HttpWebRequest;
                //request.UserAgent = "jonesmello";
                

            //using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            //{
            //    foreach (var item in response)
            //    {

            //    }

            //    StreamReader reader = new StreamReader(response.GetResponseStream());
            //    String content1 = reader.ReadToEnd();
            //    Console.WriteLine(content1);

            //}
            Uri baseUri = new Uri(BaseUrl);
            var clientHandler = new HttpClientHandler();
            // clientHandler.CookieContainer.Add(baseUri, new Cookie("name", "value"));
            HttpClient client = new HttpClient(clientHandler);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            ProductHeaderValue header = new ProductHeaderValue("jonesmello", Assembly.GetExecutingAssembly().GetName().Version.ToString());
            ProductInfoHeaderValue userAgent = new ProductInfoHeaderValue(header);
            client.DefaultRequestHeaders.UserAgent.Add(userAgent);


            client.BaseAddress = baseUri;
            HttpResponseMessage response = await client.GetAsync(baseUri);

            if (response.IsSuccessStatusCode)
            {
              
                    // JArray repoJson = (JArray)JObject.Parse(response.Content.ReadAsStringAsync().Result)[];
                    //var repoJson = await JsonConvert.SerializeObject(response.Content.ReadAsStringAsync());


                    var jsonString = await response.Content.ReadAsStringAsync();
                    var repoJson =  JsonConvert.DeserializeObject<List<RepositorioDTO>>(jsonString);
                    

                    foreach (var item in repoJson )
                    {
                        listaRepositorios.Add(new Repositorio { Nome = "full_name", Descricao = "description" });
                    }
             
            }
            else
            {
                Console.WriteLine(response.Content);
            }

            }
            catch (Exception e)
            {

                throw e;
            }


            return listaRepositorios;
        }

        public IEnumerable<Repositorio> ListarRepositoriosUsuario(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Contribuidor> ObterCollaboradoresRepositorio(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public Repositorio ObterRepositorioUsuario(Usuario usuario)
        {
            throw new NotImplementedException();
        }
    }
}
