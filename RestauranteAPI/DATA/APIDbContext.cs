using Microsoft.EntityFrameworkCore;
using RestauranteAPI.MODELS;
using System.Reflection.PortableExecutable;

namespace RestauranteAPI.DATA
{
    public class APIDbContext : DbContext
    {
        public APIDbContext(DbContextOptions<APIDbContext> options)
            :base(options)
        {
            
        }
        //DBSet de las tablas
        public DbSet<Platos> Platos { get; set; }
        public DbSet<TipoComida> TipoComida { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var tipoDeComida1 = new TipoComida() { ID = 1, Descripcion = "Italiana" };
            var tipoDeComida2 = new TipoComida() { ID = 2, Descripcion = "Mexicana" };
            var tipoDeComida3 = new TipoComida() { ID = 3, Descripcion = "Americana" };
            var tipoDeComida4 = new TipoComida() { ID = 4, Descripcion = "Ecuatoriana" };
            var tipoDeComida5 = new TipoComida() { ID = 5, Descripcion = "Colombiana" };

            var plato1 = new Platos() { ID = 1, Nombre = "LaSagna", Precio = 10, TipoComidaID = 1 };
            var plato2 = new Platos() { ID = 2, Nombre = "Tacos", Precio = 8.5, TipoComidaID = 2 };
            var plato3 = new Platos() { ID = 3, Nombre = "Hamburguesa", Precio = 7.5, TipoComidaID = 3 };
            var plato4 = new Platos() { ID = 4, Nombre = "Guatita", Precio = 9, TipoComidaID = 4 };
            var plato5 = new Platos() { ID = 5, Nombre = "Ceviche", Precio = 5, TipoComidaID = 5 };

            //tipoDeComida1.Platos = new List<Platos> { plato1 };
            //tipoDeComida2.Platos = new List<Platos> { plato2 };
            //tipoDeComida3.Platos = new List<Platos> { plato3 };
            //tipoDeComida4.Platos = new List<Platos> { plato4 };
            //tipoDeComida5.Platos = new List<Platos> { plato5 };


            modelBuilder.Entity<TipoComida>().HasData(new TipoComida[] { tipoDeComida1, tipoDeComida2, tipoDeComida3, tipoDeComida4, tipoDeComida5 });
            modelBuilder.Entity<Platos>().HasData(new Platos[] {plato1, plato2, plato3, plato4, plato5 });

            base.OnModelCreating(modelBuilder);
        }

    }
}
