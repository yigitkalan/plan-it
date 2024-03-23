using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using planit.Domain.Entities;

namespace planit.Persistance.Contexts;
public class AppDbContext: IdentityDbContext<User, Role, Guid>
{
    public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
    {
    }
    DbSet<Column> Columns { get; set; } 
    DbSet<Board> Boards { get; set; }
    DbSet<Item> Tasks { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<User>().HasMany(u => u.Tasks).WithMany(t => t.AssignedUsers);
        modelBuilder.Entity<Board>().HasMany(b => b.Users).WithMany(u => u.ParticipatedBoards);
        modelBuilder.Entity<Board>().HasMany(b => b.Columns).WithOne(c => c.Board).HasForeignKey(c => c.BoardId);
        modelBuilder.Entity<Column>().HasMany(c => c.Tasks).WithOne(t => t.Column).HasForeignKey(t => t.ColumnId);
    }
}
