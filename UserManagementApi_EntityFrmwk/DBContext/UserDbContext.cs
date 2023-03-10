using Microsoft.EntityFrameworkCore;
using UserManagementApi_EntityFrmwk.Model;
namespace UserManagementApi_EntityFrmwk.DBContext;
public class UserDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string conString = @"server=localhost; port=3306; user=root; password=root; database=userinfo";
        optionsBuilder.UseMySQL(conString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.userid);
            entity.Property(e => e.username).IsRequired();
            entity.Property(e => e.course).IsRequired();
            entity.Property(e => e.purchasedate).IsRequired();
        });
        modelBuilder.Entity<User>().ToTable("users");
    }
}