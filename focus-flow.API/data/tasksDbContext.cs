using focus_flow.Shared.models;
using Microsoft.EntityFrameworkCore;

namespace focus_flow.API.Data;

public class tasksDbContext : DbContext
{
    public tasksDbContext(DbContextOptions<tasksDbContext> options) : base(options) { }
    public DbSet<taskItem> Tasks => Set<taskItem>();
    public DbSet<tag> Tags => Set<tag>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<taskItem>()
            .HasMany(t => t.Tags)
            .WithMany(t => t.Tasks);
    }

}