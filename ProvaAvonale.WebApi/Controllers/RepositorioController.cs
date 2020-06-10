using AutoMapper;
using ProvaAvonale.ApplicationService.Interfaces;
using ProvaAvonale.Domain.Entities;
using ProvaAvonale.WebApi.Models.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ProvaAvonale.WebApi.Controllers
{
    public class RepositorioController : Controller
    {
        private readonly IRepositorioApplicationService repositorioApplicationService;

        public RepositorioController(IRepositorioApplicationService repositorioApplicationService)
        {
            this.repositorioApplicationService = repositorioApplicationService;
        }

        // GET: Repositorio
        public ActionResult Index()
        {
            //var te = repositorioApplicationService.ListarRepositoriosPublicos();
            //var result = ((IEnumerable<Repositorio>)te.Data).Cast<Repositorio>().ToList();
            //var clienteViewModel = Mapper.Map<IEnumerable<Repositorio>, IEnumerable<RepositorioViewModel>>(result);
            return View();
        }

        // GET: Repositorio/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Repositorio/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Repositorio/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Repositorio/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Repositorio/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Repositorio/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Repositorio/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Listar(){
            var te = repositorioApplicationService.ListarRepositoriosPublicos();
            var result = ((IEnumerable<Repositorio>)te.Result.Data).Cast<Repositorio>().ToList();
            var clienteViewModel = Mapper.Map<IEnumerable<Repositorio>, IEnumerable<RepositorioViewModel>>(result);
            return View(clienteViewModel);
        }
    }
}
