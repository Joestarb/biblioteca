using Microsoft.EntityFrameworkCore;

namespace biblioteca.Models
{
    public class BibliotecaContext : DbContext
    {
        public BibliotecaContext(DbContextOptions<BibliotecaContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Libro> Libros { get; set; }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Editorial> Editoriales { get; set; }
        public DbSet<Genero> Generos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.Rol)
                .WithMany()
                .HasForeignKey(u => u.FkRol);
            
      
            modelBuilder.Entity<Libro>()
                .HasOne(l => l.Autor)
                .WithMany()
                .HasForeignKey(l => l.PkAutor);

            modelBuilder.Entity<Libro>()
                .HasOne(l => l.Editorial)
                .WithMany()
                .HasForeignKey(l => l.PkEditorial);

            modelBuilder.Entity<Usuario>()
                .HasKey(u => u.PkUsuario);

            modelBuilder.Entity<Libro>()
                .HasOne(l => l.Genero)
                .WithMany()
                .HasForeignKey(l => l.PkGenero);

            modelBuilder.Entity<Libro>()
                .HasKey(l => l.PkLibro);

            modelBuilder.Entity<Autor>()
                .HasKey(a => a.PkAutor);

            modelBuilder.Entity<Editorial>()
                .HasKey(e => e.PkEditorial);

            modelBuilder.Entity<Genero>()
                .HasKey(g => g.PkGenero);

            modelBuilder.Entity<Rol>()
                .HasKey(r => r.PkRol);
        }
    }
}