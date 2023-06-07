using ApiLibreria.Data;
using ApiLibreria.Models;

namespace ApiLibreria.Services
{

        public interface ILibroService
        {
            public bool Add(Libro libro);
            public bool Update(Libro libro);
            public Libro? Get(int Id);
            public bool Delete(int Id);
            public List<Libro> GetAll();
        }

        public class LibroService : BaseService<Libro>, ILibroService
        {
            public LibroService(ApplicationDbContext dbContext) : base(dbContext) { }

            public bool Add(Libro libro)
            {
            try
            {
                dbContext.libros.Add(libro);
                SaveAndFlush();
                return true;
            }
            catch (Exception) { }
            return false;
        }

            public bool Delete(int Id)
            {
            try
            {
                var libro = Get(Id);
                if (libro != null)
                {
                    libro.Estado = false;
                    SaveAndFlush();
                    return true;
                }
            }
            catch (Exception) { }
            return false;
        }

            public Libro? Get(int Id)
            {
            try
            {
                var libro = dbContext.libros.FirstOrDefault(a => a.Id == Id);
                return libro;
            }
            catch (Exception) { }
            return null;
        }

            public List<Libro> GetAll()
            {
            try
            {
                var libros = dbContext.libros.Where(a => a.Estado).ToList();
                return libros;
            }
            catch (Exception) { }
            return new List<Libro>();
        }

            public bool Update(Libro libro)
            {
            try
            {
                dbContext.libros.Update(libro);
                return true;
            }
            catch (Exception) { }
            return false;
        }
        }
}
