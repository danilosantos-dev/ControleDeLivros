using Microsoft.EntityFrameworkCore;
using ListaDeLivros.Models;

namespace ListaDeLivros.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<LivroModel> Livros { get; set; }
        public DbSet<UsuarioModel> Usuarios { get; set; }

    }
}
