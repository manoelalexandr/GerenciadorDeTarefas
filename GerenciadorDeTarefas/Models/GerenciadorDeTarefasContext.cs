using Microsoft.EntityFrameworkCore;

namespace GerenciadorDeTarefas.Models
{
    public class GerenciadorDeTarefasContext : DbContext
    {
        public GerenciadorDeTarefasContext(DbContextOptions<GerenciadorDeTarefasContext> options) : base(options)
        {

        }

        public DbSet<Usuario> Usuario { get; set; }
    }
}
