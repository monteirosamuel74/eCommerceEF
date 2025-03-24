using Microsoft.EntityFrameworkCore;

namespace eCommerce.API.Database
{
    public class eCommerceContext : DbContext
    {
        public eCommerceContext(DbContextOptions<eCommerceContext> options) : base(options)
        {

        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Contato> Contatos { get; set; }
        public DbSet<EnderecoEntrega> EnderecoEntrega { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Departamento>().HasData(
                new Departamento { Id = 1, Name = "Mercado" },
                new Departamento { Id = 2, Name = "Moda" },
                new Departamento { Id = 3, Name = "Móveis" },
                new Departamento { Id = 4, Name = "informática" },
                new Departamento { Id = 5, Name = "Eletroeletrônico" },
                new Departamento { Id = 6, Name = "Beleza" }
                );
        }
    }
}
