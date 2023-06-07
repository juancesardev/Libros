using LibrosAutoresBlazor.Models;
using System;

namespace LibrosAutoresBlazor.Repository
{
    public interface ILibroService
    {
        Task<List<Libro>> GetLibrosAsync();
        Task<Libro> GetLibroByIdAsync(int id);
        Task CreateLibroAsync(Libro libro);
        Task UpdateLibroAsync(Libro libro);
        Task DeleteLibroAsync(int id);
    }
}
