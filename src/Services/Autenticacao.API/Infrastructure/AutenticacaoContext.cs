using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Autenticacao.API.Infrastructure
{
    public class AutenticacaoContext : IdentityDbContext
    {
        public AutenticacaoContext(DbContextOptions<AutenticacaoContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
