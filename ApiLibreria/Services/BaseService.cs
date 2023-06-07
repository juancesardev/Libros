using ApiLibreria.Data;

namespace ApiLibreria.Services
{

    public class BaseService<T>
    {
        public ApplicationDbContext dbContext;
        public BaseService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void SaveAndFlush()
        {
            dbContext.SaveChanges();
        }
    }
}
