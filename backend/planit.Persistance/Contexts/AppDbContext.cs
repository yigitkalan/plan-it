using Microsoft.EntityFrameworkCore;
using planit.Domain.Entities;

namespace planit.Persistance.Contexts;
public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
    {
    }
    DbSet<Column> Columns { get; set; } 
    DbSet<Board> Boards { get; set; }
    DbSet<Item> Tasks { get; set; }
    DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasMany(u => u.OwnedBoards).WithOne(b => b.Owner).HasForeignKey(b => b.OwnerId);
        modelBuilder.Entity<Board>().HasMany(b => b.Users).WithMany(u => u.ParticipatedBoards);
        modelBuilder.Entity<Board>().HasMany(b => b.Columns).WithOne(c => c.Board).HasForeignKey(c => c.BoardId);
        modelBuilder.Entity<Column>().HasMany(c => c.Tasks).WithOne(t => t.Column).HasForeignKey(t => t.ColumnId);
    }
}
