using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Training.Models;

namespace Training.Data
{
    public class TrelloContext : DbContext
    {
        public TrelloContext(DbContextOptions<TrelloContext> options) : base(options)
        {
        }

        public DbSet<TrelloBoard> Boards { get; set; }
        public DbSet<TrelloColumn> Columns { get; set; }
        public DbSet<TrelloTask> Tasks { get; set; }
        public DbSet<TrelloUser> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
