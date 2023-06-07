using ApiLibreria.Models;
using ApiLibreria.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiLibreria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        private readonly ILibroService libroService;
        public LibroController(ILibroService _libroService)
        {
            libroService = _libroService;
        }

        // GET AutorController/
        [HttpGet]
        public ActionResult Index()
        {
            return Ok(libroService.GetAll());
        }

        // GET: AutorController/5
        [HttpGet("{id}")]
        public ActionResult Details(int id)
        {
            var libro = libroService.Get(id);
            if (libro != null) return Ok(libro);
            return NotFound();
        }

        // POST: AutorController/Create
        [HttpPost]
        public ActionResult Create(Libro libro)
        {
            try
            {
                bool res = libroService.Add(libro);
                if (res) return Ok();
            }
            catch
            {
            }
            return BadRequest();
        }

        // PUT: AutorController/Edit/5
        [HttpPut]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Libro libroData)
        {
            try
            {
                var libro = libroService.Get(id);
                if (libro != null)
                {
                    libroData.Titulo = libroData.Titulo;
                    libroService.Update(libro);
                    return Ok();
                }
            }
            catch
            {
            }
            return BadRequest();
        }

        // DELETE: AutorController/Delete/5
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            try
            {
                var res = libroService.Delete(id);
                if (res)
                {
                    return Ok();
                }
            }
            catch
            {
            }
            return BadRequest();

        }
    }
}
