using Microsoft.EntityFrameworkCore;

namespace LRMS.Server
{
    public class UserInfoDbContext : DbContext
    {
        public UserInfoDbContext(DbContextOptions options) : base(options) { }

        public DbSet<UserLoginModel> user_login { get; set; }
    }
}