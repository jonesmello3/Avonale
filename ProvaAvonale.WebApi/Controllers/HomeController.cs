using AutoMapper;
using Microsoft.Ajax.Utilities;
using PagedList;
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
        public async Task<ActionResult> List(string sortOrder, string searchString, string currentFilter, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            var filtro = Request.QueryString["filtro"];
            int pageSize = 10;
            int pageNumber = (page ?? 1);

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            Response response = new Response();

            if (String.IsNullOrEmpty(filtro))
            {
                response = await repositorioApplicationService.ListarRepositoriosPublicos();
            }
            else
            {
                response = await repositorioApplicationService.PesquisarRepositoriosPorNome(filtro);
            }

            if (response.Success && response.Data != null)
            {
                var result = ((IEnumerable<Repositorio>)response.Data).Cast<Repositorio>().ToList();
                var clienteViewModel = Mapper.Map<IEnumerable<Repositorio>, IEnumerable<RepositorioViewModel>>(result).ToPagedList(pageNumber, pageSize);
                return View(clienteViewModel);
            }
            else
            {
                return RedirectToRoute(new { controller = "Home", action = "List" });
            }
            
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
            var repositorios = await repositorioApplicationService.PesquisarRepositoriosPorNome(filtro);

            if (repositorios.Data != null) {
                var result = ((IEnumerable<Repositorio>)repositorios.Data).Cast<Repositorio>().ToList();
                var clienteViewModel = Mapper.Map<IEnumerable<Repositorio>, IEnumerable<RepositorioViewModel>>(result);
                return View(clienteViewModel);
            }
            else
            {
                return RedirectToRoute(new { controller = "Home", action = "List" });
            }
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
            await repositorioApplicationService.AdicionarRepositorioAosFavoritos(id);
            return RedirectToRoute(new { controller = "Home", action = "List" });
        }
        #endregion

        #region MostrarFavoritos
        public ActionResult MostrarFavoritos()
        {
            var repositorio = repositorioApplicationService.MostrarFavoritos();
            if (repositorio.Data != null)
            {
                var result = ((IEnumerable<Repositorio>)repositorio.Data).Cast<Repositorio>().ToList().OrderByDescending(repo => repo.DataAtualizacao);
                var clienteViewModel = Mapper.Map<IEnumerable<Repositorio>, IEnumerable<RepositorioViewModel>>(result);
                return View(clienteViewModel);
            }
            else
            {
                return View();
            }
        }
        #endregion

        #region RemoverFavoritos
        public ActionResult RemoverFavoritos(int id)
        {
            repositorioApplicationService.RemoverFavoritos(id);
            return RedirectToRoute(new { controller = "Home", action = "MostrarFavoritos" });
        }
        #endregion
    }
}