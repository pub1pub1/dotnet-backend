using Microsoft.EntityFrameworkCore;
using TutorialApi.Models;

namespace TutorialApi.Data
{
    public class TutorialContext : DbContext
    {
        public TutorialContext(DbContextOptions<TutorialContext> options)
            : base(options)
        {
        }

        public DbSet<Tutorial> Tutorials { get; set; }
    }
}