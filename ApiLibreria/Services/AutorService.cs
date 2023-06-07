using ApiLibreria.Data;
using ApiLibreria.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiLibreria.Services
{
    public interface IAutorService
    {
        public bool Add(Autor autor);
        public bool Update(Autor autor);
        public Autor? Get(int autorId);
        public bool Delete(int autorId);
        public List<Autor> GetAll();
    }
    public class AutorService : BaseService<Autor>, IAutorService
    {
        public AutorService(ApplicationDbContext dbContext) : base(dbContext) { }

        public bool Add(Autor autor)
        {
            try
            {
                dbContext.autores.Add(autor);
                SaveAndFlush();
                return true;
            }
            catch(Exception) { }
            return false;
        }

        public bool Delete(int autorId)
        {
            try
            {
                var autor = Get(autorId);
                if (autor != null)
                {
                    autor.Estado = false;
                    SaveAndFlush();
                    return true;
                }
            }
            catch (Exception) { }
            return false;
        }

        public Autor? Get(int autorId)
        {
            try
            {
                var autor = dbContext.autores.FirstOrDefault(a => a.Id == autorId);
                return autor;
            }
            catch(Exception) { }
            return null;
        }

        public List<Autor> GetAll()
        {
            try
            {
                var autors = dbContext.autores.Where(a => a.Estado).ToList();
                return autors;
            }
            catch (Exception) { }
            return new List<Autor>();
        }

        public bool Update(Autor autor)
        {
            try
            {
                dbContext.autores.Update(autor);
                return true;
            }
            catch (Exception) { }
            return false;
        }
    }
}
