using System.Data.Entity;
using Trainings.Models;

namespace Trainings.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Training> Trainings { get; set; }
    }
}