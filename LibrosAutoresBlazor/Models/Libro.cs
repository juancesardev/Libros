namespace LibrosAutoresBlazor.Models
{
    public class Libro
    {
        public int Id { get; set; }
        public int AutorId { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Categoria { get; set; } = string.Empty;
        public DateTime FechaPublicacion { get; set; } = DateTime.Now;
        public bool Estado { get; set; } = true;
    }
}
