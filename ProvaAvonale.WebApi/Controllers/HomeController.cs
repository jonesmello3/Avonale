using AutoMapper;
using ProvaAvonale.ApplicationService.Interfaces;
using ProvaAvonale.Domain.Entities;
using ProvaAvonale.Domain.Entities.Auxiliar;
using ProvaAvonale.WebApi.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ProvaAvonale.WebApi.Controllers
{
    public class HomeController : Controller
    {
        #region Variáveis
        private readonly IRepositorioApplicationService repositorioApplicationService; 
        #endregion

        #region Construtor
        public HomeController(IRepositorioApplicationService repositorioApplicationService)
        {
            this.repositorioApplicationService = repositorioApplicationService;
        } 
        #endregion

        #region Index
        public ActionResult Index()
        {
            return View();
        } 
        #endregion

        #region List
        [HttpGet]
        public async Task<ActionResult> List()
        {
            var filtro = Request.QueryString["filtro"];

            Response response = new Response();

            if (String.IsNullOrEmpty(filtro))
            {
                response = await repositorioApplicationService.ListarRepositoriosPublicos();
            }
            else
            {
                response = await repositorioApplicationService.PesquisarRepositoriosPorNome(filtro);
            }

            var result = ((IEnumerable<Repositorio>)response.Data).Cast<Repositorio>().ToList();
            var clienteViewModel = Mapper.Map<IEnumerable<Repositorio>, IEnumerable<RepositorioViewModel>>(result);
            return View(clienteViewModel);
        } 
        #endregion

        #region ListarRepositoriosUsuario
        public async Task<ActionResult> ListarRepositoriosUsuario()
        {
            var userName = "jonesMello3";
            var te = await repositorioApplicationService.ListarRepositoriosUsuario(userName);
            var result = ((IEnumerable<Repositorio>)te.Data).Cast<Repositorio>().ToList();
            var clienteViewModel = Mapper.Map<IEnumerable<Repositorio>, IEnumerable<RepositorioViewModel>>(result);
            return View(clienteViewModel);
        } 
        #endregion

        #region PesquisarRepositoriosPorNome
        public async Task<ActionResult> PesquisarRepositoriosPorNome(string filtro)
        {
            var te = await repositorioApplicationService.PesquisarRepositoriosPorNome(filtro);
            var result = ((IEnumerable<Repositorio>)te.Data).Cast<Repositorio>().ToList();
            var clienteViewModel = Mapper.Map<IEnumerable<Repositorio>, IEnumerable<RepositorioViewModel>>(result);
            return View(clienteViewModel);
        }
        #endregion

        #region Detalhes
        public async Task<ActionResult> Detalhes(int id)
        {
            var repositorio = await repositorioApplicationService.ObterRepositoriosPorId(id);
            var t = (Repositorio)Convert.ChangeType(repositorio.Data, typeof(Repositorio));
            var clienteViewModel = Mapper.Map<Repositorio, RepositorioViewModel>(t);
            return View(clienteViewModel);
        }
        #endregion

        #region AdicionarRepositorioAosFavoritos
        public async Task<ActionResult> AdicionarRepositorioAosFavoritos(int id)
        {
            var repositorio = await repositorioApplicationService.AdicionarRepositorioAosFavoritos(id);
            var t = (Repositorio)Convert.ChangeType(repositorio.Data, typeof(Repositorio));
            var clienteViewModel = Mapper.Map<Repositorio, RepositorioViewModel>(t);
            return RedirectToRoute(new { controller = "Home", action = "List" });
        }
        #endregion

        #region MostrarFavoritos
        public ActionResult Favoritos()
        {
            var repositorio = repositorioApplicationService.MostrarFavoritos();
            if (repositorio.Data != null)
            {
                var result = ((IEnumerable<Repositorio>)repositorio.Data).Cast<Repositorio>().ToList();
                var clienteViewModel = Mapper.Map<IEnumerable<Repositorio>, IEnumerable<RepositorioViewModel>>(result);
                return View(clienteViewModel);
            }
            else
            {
                return View();
            }
            
        }
        #endregion
    }
}