using Microsoft.EntityFrameworkCore;
        
namespace Contato.Domain
{
    public class ContatoDbContext : DbContext
    {
        public ContatoDbContext(DbContextOptions<ContatoDbContext> options)
            : base(options) {

            this.Database.EnsureCreated();
        }

        public DbSet<Models.Contato> Contatos { get; set; }
    }
}
