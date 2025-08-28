using Microsoft.EntityFrameworkCore;
using MyApp.Model;

namespace MyApp.Data
{
    public class MyDatabase : DbContext
    {
        public MyDatabase(DbContextOptions<MyDatabase> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOtp> userotp{ get; set; }
        
    }
}   