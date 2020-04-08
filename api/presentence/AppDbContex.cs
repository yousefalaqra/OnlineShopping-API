using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext (DbContextOptions<AppDbContext> options)
     : base(options)
    { 
    }


    //? DbSets ././
    public DbSet<ItemEntity> Items { get; set; }
}