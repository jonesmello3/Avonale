using Newtonsoft.Json;
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
            try
            {
               
                Uri baseUri = new Uri(BaseUrl);
                var clientHandler = new HttpClientHandler();
                HttpClient client = new HttpClient(clientHandler);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                ProductHeaderValue header = new ProductHeaderValue("jonesmello", Assembly.GetExecutingAssembly().GetName().Version.ToString());
                ProductInfoHeaderValue userAgent = new ProductInfoHeaderValue(header);
                client.DefaultRequestHeaders.UserAgent.Add(userAgent);

                client.BaseAddress = baseUri;
                HttpResponseMessage response = await client.GetAsync(baseUri);

                IEnumerable<Repositorio> listaRepositorios = new List<Repositorio>();
        
                if (response.IsSuccessStatusCode)
                {
                        var jsonString = await response.Content.ReadAsStringAsync();
                        var json =  JsonConvert.DeserializeObject<List<RepositorioDTO>>(jsonString);
                }
                else
                {
                    Console.WriteLine(response.Content);
                }

                return listaRepositorios;

            }
            catch (Exception e)
            {
                throw e;
            }
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
