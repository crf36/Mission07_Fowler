using Microsoft.EntityFrameworkCore;

namespace Mission07_Fowler.Models
{
    // Define a class named Context that inherits from DbContext. Bridge between database/application, allows for CRUD functionality
    public class Context : DbContext 
    {
        public Context(DbContextOptions<Context> options) : base(options) // Constructor, DbContextOptions is a parameter
        {
            // Can add options for how the database should connect
        }

        // DbSet accesses the table in the database. DbSet<record/row> Table (newly defined in the program)
        // Provides a way to interact with the table through Linq queries and EF
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
