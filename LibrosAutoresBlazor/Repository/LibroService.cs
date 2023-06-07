using LibrosAutoresBlazor.Models;
using System;

namespace LibrosAutoresBlazor.Repository
{
    public class LibroService : ILibroService
    {
        private readonly HttpClient _httpClient;
        public LibroService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateLibroAsync(Libro libro)
        {
            await _httpClient.PostAsJsonAsync("https://localhost:7082/api/libro", libro);
        }

        public async Task DeleteLibroAsync(int id)
        {
            await _httpClient.DeleteAsync($"https://localhost:7082/api/personas/{id}");
        }

        public async Task<Libro> GetLibroByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Libro>($"https://localhost:7082/api/libro/{id}");
        }

        public async Task<List<Libro>> GetLibrosAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Libro>>("https://localhost:7082/api/libro");
        }

        public async Task UpdateLibroAsync(Libro libro)
        {
            await _httpClient.PutAsJsonAsync($"https://localhost:7082/api/personas/", libro);
        }
    }
}
