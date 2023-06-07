using ApiLibreria.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiLibreria.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // Define your entity sets here
        public DbSet<Autor> autores { get; set; }
        public DbSet<Libro> libros { get; set; }
    }
}
