using System.Text.Json.Serialization;

namespace biblioteca.Models
{
    public class Usuario
    {
        public int PkUsuario { get; set; }
        public string Nombre { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int FkRol { get; set; }
        [JsonIgnore]
        public Rol? Rol { get; set; }
    }

    public class Rol
    {
        public int PkRol { get; set; }
        public string Nombre { get; set; }
    }

    public class Autor
    {
        public int PkAutor { get; set; }
        public string Nombre { get; set; }
        public string Biografia { get; set; }
        public string FotoUrl { get; set; }
        public DateTime? FechaNacimiento { get; set; }
    }

    public class Libro
    {
        public int PkLibro { get; set; }
        public string Titulo { get; set; }
        public int PkAutor { get; set; }
        public string Descripcion { get; set; }
        public int PkEditorial { get; set; }
        public int PkGenero { get; set; }
        public DateTime? FechaPublicacion { get; set; }
        public string FotoUrl { get; set; }
        public int? Paginas { get; set; }
        public string OpenLibrary { get; set; }
        public string Isbn10 { get; set; }
        public string Isbn13 { get; set; }
        public string WorldId { get; set; }
        public string Idioma { get; set; }
        [JsonIgnore]
        public Autor? Autor { get; set; }
        [JsonIgnore]
        public Editorial? Editorial { get; set; }
        [JsonIgnore]
        public Genero? Genero { get; set; }
    }

    public class Editorial
    {
        public int PkEditorial { get; set; }
        public string Nombre { get; set; }
    }

    public class Genero
    {
        public int PkGenero { get; set; }
        public string Nombre { get; set; }
    }
}