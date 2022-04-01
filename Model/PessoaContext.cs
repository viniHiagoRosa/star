using Microsoft.EntityFrameworkCore;

namespace star.Model
{
    public class PessoaContext : DbContext
    {
        public PessoaContext(DbContextOptions<PessoaContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Pessoa> Pessoas { get; set; }

    }
}
