using Newtonsoft.Json;
using ProvaAvonale.ApplicationService.Interfaces;
using ProvaAvonale.ApplicationService.Models;
using ProvaAvonale.Domain.Entities;
using ProvaAvonale.Domain.Entities.Auxiliar;
using ProvaAvonale.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProvaAvonale.ApplicationService.Applications
{
    public class RepositorioApplicationService : ApplicationServiceBase<Repositorio>, IRepositorioApplicationService
    {
        #region Variáveis
        private readonly IRepositorioService repositorioService;
        #endregion

        #region Construtor
        public RepositorioApplicationService(IRepositorioService repositorioService) : base(repositorioService)
        {
            this.repositorioService = repositorioService;
        }
        #endregion

        #region ListarRepositoriosPublicos
        public async Task<Response> ListarRepositoriosPublicos()
        {
            try
            {
                var repositorios = await repositorioService.ListarRepositoriosPublicos();
                
                if (repositorios.Any()) {
                
                }

                return new Response { Success = true, Data = repositorios.OrderBy(repos => repos.Nome) };
            }
            catch (Exception ex)
            {
                return new Response { Message = ex.Message, Error = ex };
            }
        }
        #endregion

        #region ListarRepositoriosUsuario
        public async Task<Response> ListarRepositoriosUsuario(string userName)
        {
            try
            {
                var json = await repositorioService.ListarRepositoriosUsuario(userName);
                return new Response { Success = true, Data = json };
            }
            catch (Exception ex)
            {
                return new Response { Message = ex.Message, Error = ex };
            }
        }
        #endregion

        #region PesquisarRepositoriosPorNome
        public async Task<Response> PesquisarRepositoriosPorNome(string nome)
        {
            try
            {
                var json = await repositorioService.PesquisarRepositoriosPorNome(nome);
                return new Response { Success = true, Data = json };
            }
            catch (Exception ex)
            {
                return new Response { Message = ex.Message, Error = ex };
            }
        }
        #endregion

        #region ObterRepositoriosPorId
        public async Task<Response> ObterRepositoriosPorId(int id)
        {
            try
            {
                var json = await repositorioService.ObterRepositorioPorId(id);
                return new Response { Success = true, Data = json };
            }
            catch (Exception ex)
            {
                return new Response { Message = ex.Message, Error = ex };
            }
        }
        #endregion

        #region AdicionarRepositorioAosFavoritos
        public async Task<Response> AdicionarRepositorioAosFavoritos(int id)
        {
            try
            {
                var s = await repositorioService.AdicionarRepositorioAosFavoritos(id);
                return new Response { Success = true, Data = null };
            }
            catch (Exception ex)
            {
                return new Response { Message = ex.Message, Error = ex };
            }
        }
        #endregion

        #region MostrarFavoritos
        public Response MostrarFavoritos()
        {
            try
            {
                var repositorios = repositorioService.MostrarFavoritos();
                return new Response { Success = true, Data = repositorios };
            }
            catch (Exception ex)
            {
                return new Response { Message = ex.Message, Error = ex };
            }
        }
        #endregion

        #region RemoverFavoritos
        public Response RemoverFavoritos(int id)
        {
            try
            {
                repositorioService.RemoverFavoritos(id);
                return new Response { Success = true, Data = null };
            }
            catch (Exception ex)
            {
                return new Response { Message = ex.Message, Error = ex };
            }
        }
        #endregion
    }
}
