using Microsoft.EntityFrameworkCore;

namespace Mission07_Fowler.Models
{
    public class Context : DbContext // Bridge between database and application, allowing for CRUD functionality
    {
        public Context(DbContextOptions<Context> options) : base(options) // Constructor
        {

        }
        public DbSet<Movie> Movies { get; set; } //Links to Movies table
        public DbSet<Category> Categories { get; set; } //Links to Categories table
    }
}
