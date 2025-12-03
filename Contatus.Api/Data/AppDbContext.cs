using Microsoft.EntityFrameworkCore;
using Contatus.Core.Models;
using System.Reflection;

namespace Contatus.Api.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Pessoa> Pessoas { get; set; } = null!;
        public DbSet<Telefone> Telefones { get; set; } = null!;

        //Mapeamento para o banco de dados, melhor performance
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Automaticamente busca por todas as classes que implementam IEntityTypeConfiguration
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
