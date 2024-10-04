using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StructurMessegerFullUserActyvyti.DAL.Entities;

namespace StructurMessegerFullUserActyvyti.DAL.DB;

class ConnectingDatabase : DbContext
{
    public ConnectingDatabase()
    {
        Database.EnsureCreated();
    }

    public DbSet<UserDataEntity> UserDataTable { get; set; }
    public DbSet<UserFriendsEntity> UserFriendsTable { get; set; }
    public DbSet<MessageEntity> MessageEntity { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=DESKTOP-582CB1R;Database=UserDataBase;Trusted_Connection=True;TrustServerCertificate=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserDataEntity>().HasKey(u => u.UserID);
        modelBuilder.Entity<UserFriendsEntity>().HasKey(f => f.FriendID);
        modelBuilder.Entity<MessageEntity>().HasKey(m => m.MessageID);
    }
}
