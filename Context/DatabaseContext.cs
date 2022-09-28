using ControleDeEstoque.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleDeEstoque.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
                
        }

        public DbSet<EstoqueModel> Invetory { get; set; }
        public DbSet<UserModel> User { get; set; }
    }
}
