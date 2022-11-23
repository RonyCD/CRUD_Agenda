//using CRUDAgenda.Models;
//using Microsoft.AspNetCore.Mvc;
//using System.Diagnostics;

//namespace CRUDAgenda.Controllers
//{
//    public class HomeController : Controller
//    {
//        private readonly ILogger<HomeController> _logger;

//        public HomeController(ILogger<HomeController> logger)
//        {
//            _logger = logger;
//        }

//        public IActionResult Index()
//        {
//            return View();
//        }

//        public IActionResult Privacy()
//        {
//            return View();
//        }

//        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
//        public IActionResult Error()
//        {
//            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
//        }
//    }
//}


using CRUDAgenda.Datos;
using CRUDAgenda.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CrudNet7MVC.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        private readonly AgendaDBContext _context;

        public HomeController(AgendaDBContext context)
        {
            //_logger = logger;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Contacto.ToArrayAsync());
        }

        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }


        // Accion Crear

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(Contacto contacto)
        {
            if (ModelState.IsValid)
            {
                _context.Contacto.Add(contacto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View();

        }


        // Accion Editar

        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contacto = _context.Contacto.Find(id);
            if (contacto == null)
            {
                return NotFound();
            }
            return View(contacto);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(Contacto contacto)
        {
            if (ModelState.IsValid)
            {
                _context.Update(contacto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View();

        }


        // Accion Detalle

        public IActionResult Detalle(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contacto = _context.Contacto.Find(id);
            if (contacto == null)
            {
                return NotFound();
            }
            return View(contacto);
        }


        // Accion Borrar

        [HttpGet]
        public IActionResult Borrar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contacto = _context.Contacto.Find(id);
            if (contacto == null)
            {
                return NotFound();
            }
            return View(contacto);
        }

        [HttpPost, ActionName("Borrar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BorrarContacto(int? id)
        {
            var contacto = await _context.Contacto.FindAsync(id);
            if (contacto == null)
            {
                return View();
            }

            _context.Contacto.Remove(contacto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}