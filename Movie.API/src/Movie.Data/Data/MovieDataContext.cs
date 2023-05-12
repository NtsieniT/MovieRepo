using Microsoft.EntityFrameworkCore;
using Movie.Domain.Models;
using Movie.Domain.Models.Lookups;

namespace Movie.Data.Data
{
    public class MovieDataContext : DbContext
    {
        public MovieDataContext()
        {

        }
    
        public MovieDataContext(DbContextOptions<MovieDataContext> options) : base(options) { }

        public DbSet<Movies> Movies { get; set; }
        public DbSet<TypeLookup> Types { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
           
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("Server=.;Database=MoviesDB;Trusted_Connection=True; MultipleActiveResultSets=True");
            base.OnConfiguring(builder);
        }

    }
}
