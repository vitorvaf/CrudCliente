using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using loja.Models;
using Microsoft.Extensions.Configuration;

namespace loja.Data
{
    public class LojaDataContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Telefone> Telefones { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=localhost; Database=loja; user id=SA; password="");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>().ToTable("Clientes");
            modelBuilder.Entity<Telefone>().ToTable("Telefones");
        }
    }
}
