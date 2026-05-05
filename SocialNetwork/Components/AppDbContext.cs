using SocialNetwork.Model;

namespace SocialNetwork.Components;

using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    
    public DbSet<Account> Account { get; set; }
    public DbSet<Friend> Friend { get; set; }
    public DbSet<Message> Message { get; set; }
    public DbSet<Groups> Groups { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Friend>(entity =>
        {
            // 🔑 Составной PRIMARY KEY
            entity.HasKey(f => new { f.AccountId, f.FriendId });

            // 🔗 FK: account_id → account(id)
            entity.HasOne(f => f.Account)
                .WithMany()
                .HasForeignKey(f => f.AccountId)
                .OnDelete(DeleteBehavior.Restrict);

            // 🔗 FK: friend_id → account(id)
            entity.HasOne(f => f.FriendAccount)
                .WithMany()
                .HasForeignKey(f => f.FriendId)
                .OnDelete(DeleteBehavior.Restrict);

            // ❗ запрет дружбы с самим собой
            entity.HasCheckConstraint("CK_Friend_NotSelf",
                "\"account_id\" <> \"friend_id\"");
        });
    }
    
    
}