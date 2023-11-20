using Microsoft.EntityFrameworkCore;
using UrlShorter.entities;
using UrlShorter.Entities;

using UrlShorter.Models.Enum;

namespace UrlShorter.Data
{
    public class URLShortContext : DbContext
    {
        public DbSet<URL> URLs { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        public DbSet<User> Users { get; set; }


        public URLShortContext(DbContextOptions<URLShortContext> options) : base(options) //Acá estamos llamando al constructor de DbContext que es el que acepta las opciones
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Categoria Trabajo = new Categoria()
            {
                Id = 1,
                Name = "Trabajo"
            };
            Categoria Diversion = new Categoria()
            {
                Id = 2,
                Name = "Diversion"
            };
            User Usuario1 = new User()
            {
                Id = 1,
                Name = "Gaspar",
                Password = "password",
                RolUser = Role.Admin
              
            };

            User Usuario2 = new User()
            {
                Id = 2,
                Name = "Jose",
                Password = "password",
                RolUser = Role.User

            };

            User Usuario3 = new User()
            {
                Id = 3,
                Name = "Guest",
                Password = "password",
                RolUser = Role.Guest

            };

            URL url = new URL()
            {
                Id = 1,
                URLShort = "jef",
                URLLong = "Lasoadsat",
                contador = 0,
                IdCategoria = Trabajo.Id,
                IdUser = Usuario1.Id
            };
            URL url1 = new URL()
            {
                Id = 2,
                URLShort = "Karenaaa",
                URLLong = "Lasotsdasdsa",
                contador = 1,
                IdCategoria = Diversion.Id,
                IdUser = Usuario2.Id
                
            };

            URL url2 = new URL()
            {
                Id = 3,
                URLShort = "asddsadsa",
                URLLong = "Ldsadsadasdasot",
                contador = 2,
                IdCategoria = Diversion.Id,
                IdUser = Usuario2.Id
            };

            modelBuilder.Entity<URL>()
            .HasOne(c => c.User)
            .WithMany()
            .HasForeignKey(c => c.IdUser);
            modelBuilder.Entity<URL>()
            .HasOne(c => c.Categoria)
            .WithMany()
            .HasForeignKey(c => c.IdCategoria);




            modelBuilder.Entity<Categoria>().HasData(Trabajo, Diversion);
            modelBuilder.Entity<URL>().HasData(url, url1, url2);
            modelBuilder.Entity<User>().HasData(Usuario1, Usuario2, Usuario3);

            base.OnModelCreating(modelBuilder);
            
        }
    }
}