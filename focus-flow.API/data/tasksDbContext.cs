using focus_flow.Shared.models;
using Microsoft.EntityFrameworkCore;

namespace focus_flow.API.Data;

//DbContext is the EF Core base class that handles all DB operations.
public class tasksDbContext : DbContext
{
    public tasksDbContext(DbContextOptions<tasksDbContext> options)
        : base(options) { }//constructor lets us pass configuration from Program.cs
    public DbSet<taskItem> Tasks => Set<taskItem>();
    public DbSet<tag> Tags => Set<tag>();

    // to customize how EF maps relationships.
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<taskItem>()
            .HasMany(t => t.Tags)
            .WithMany(t => t.Tasks);
    }

}