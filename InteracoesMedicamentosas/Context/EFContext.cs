using System.Data.Entity;
using InteracoesMedicamentosas.Models;

namespace InteracoesMedicamentosas.Context
{
    public class EFContext : DbContext
    {
        public EFContext() : base("InteracoesMedicamentosas")
        {
            Database.SetInitializer<EFContext>(new DropCreateDatabaseIfModelChanges<EFContext>());
        }

        public DbSet<Reacao> Reacoes { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Interacao> Interacoes { get; set; }
    }
}