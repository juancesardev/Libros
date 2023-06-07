using System.ComponentModel.DataAnnotations;

namespace ApiLibreria.Models
{
    public class Autor
    {
        [Key]
        public int Id { get; set; }
        public string AutorName { get; set; } = string.Empty;
        public bool Estado { get; set; } = false;
    }
}
