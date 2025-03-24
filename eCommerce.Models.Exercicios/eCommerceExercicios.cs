using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace eCommerce.Models.Exercicios
{
    public class eCommerceExercicios : DbContext
    {
        public eCommerceExercicios(DbContextOptions<eCommerceExercicios> options) : base(options)
        {

        }
        public DbSet<Usuario>? Usuarios { get; set; }
        public DbSet<Contato>? Contatos { get; set; }
        public DbSet<EnderecoEntrega>? EnderecoEntrega { get; set; }
        public DbSet<Departamento>? Departamentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().Ignore(a => a.Sexo);
            modelBuilder.Entity<Usuario>().Property(a => a.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<Usuario>().HasIndex("CPF").IsUnique();
            modelBuilder.Entity<Usuario>().HasIndex(a => a.CPF);

            modelBuilder.Entity<Usuario>().HasIndex("CPF", "Email");
            modelBuilder.Entity<Usuario>().HasIndex(a => new { a.CPF, a.Email });

            modelBuilder.Entity<Usuario>().HasKey("Id", "CPF");
            modelBuilder.Entity<Usuario>().HasKey(a => new { a.Id, a.CPF });

            modelBuilder.Entity<Usuario>().HasAlternateKey("CPF", "Email");

            modelBuilder.Entity<Usuario>().HasOne(a => a.Contato).WithOne(a => a.Usuario).
                HasForeignKey<Contato>(a => a.Usuario);
            modelBuilder.Entity<Usuario>().HasMany(a => a.EnderecosEntrega).WithOne(a => a.Usuario);
            modelBuilder.Entity<Usuario>().HasMany(a => a.Departamentos).WithMany(a => a.Usuarios);
        }
    }
}
