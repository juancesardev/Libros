using ApiLibreria.Models;
using ApiLibreria.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiLibreria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly IAutorService autorService;
        public AutorController(IAutorService _autorService) {
            autorService = _autorService;
        }

        // GET AutorController/
        [HttpGet]
        public ActionResult Index()
        {
            return Ok(autorService.GetAll());
        }

        // GET: AutorController/5
        [HttpGet("{id}")]
        public ActionResult Details(int id)
        {
            var autor = autorService.Get(id);
            if(autor != null) return Ok(autor);
            return NotFound();
        }

        // POST: AutorController/Create
        [HttpPost]
        public ActionResult Create(Autor autor)
        {
            try
            {
                bool res = autorService.Add(autor);
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
        public ActionResult Edit(int id, Autor autorData)
        {
            try
            {
                var autor = autorService.Get(id);
                if (autor != null)
                {
                    autor.AutorName = autorData.AutorName;
                    autorService.Update(autor);
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
                var res = autorService.Delete(id);
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
