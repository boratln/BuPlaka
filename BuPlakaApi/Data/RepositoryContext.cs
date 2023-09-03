using BuPlakaApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BuPlakaApi.Data
{
    public class RepositoryContext:DbContext
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options) { 
        
        }
        public DbSet<User> Users { get; set; }
        public DbSet<CarPlate> CarPlate { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Vote> Votes { get; set; }
    }
}
