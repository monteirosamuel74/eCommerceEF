using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace eCommerce.Models.FluentAPI
{
    public class eCommerceFluentContext : DbContext
    {
        public eCommerceFluentContext(DbContextOptions<eCommerceFluentContext> options) : base(options)
        {

        }
        public DbSet<Usuario>? Usuarios { get; set; }
        public DbSet<Contato>? Contatos { get; set; }
        public DbSet<EnderecoEntrega>? EnderecoEntrega { get; set; }
        public DbSet<Departamento>? Departamentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().ToTable("TB_USUARIOS");
            modelBuilder.Entity<Usuario>().Property(a=>a.RG).HasColumnName("REGISTRO_GERAL").
                HasMaxLength(5).HasDefaultValue().IsRequired();
            modelBuilder.Entity<Usuario>().Ignore(a => a.Sexo);
            modelBuilder.Entity<Usuario>().Property(a => a.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<Usuario>().HasIndex("CPF").IsUnique().HasFilter("[CPF] is not null").
                HasDatabaseName("IX_CPF_UNIQUE");
            modelBuilder.Entity<Usuario>().HasIndex(a => a.CPF);
            
            modelBuilder.Entity<Usuario>().HasIndex("CPF", "Email");
            modelBuilder.Entity<Usuario>().HasIndex(a => new { a.CPF, a.Email });

            modelBuilder.Entity<Usuario>().HasKey("Id", "CPF");
            modelBuilder.Entity<Usuario>().HasKey(a => new { a.Id, a.CPF });

            modelBuilder.Entity<Usuario>().HasAlternateKey("CPF", "Email");

            modelBuilder.Entity<Usuario>().HasOne(a => a.Contato).WithOne(a => a.Usuario).
                HasForeignKey<Contato>(a => a.Usuario);
            modelBuilder.Entity<Usuario>().HasMany(a => a.EnderecosEntrega).WithOne(a=>a.Usuario);
            modelBuilder.Entity<Usuario>().HasMany(a => a.Departamentos).WithMany(a=>a.Usuarios);
        }
    }
}
