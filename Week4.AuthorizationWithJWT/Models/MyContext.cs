using Microsoft.EntityFrameworkCore;

namespace Week4.AuthorizationWithJWT.Models
{
    public class MyContext : DbContext
    {
        
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {
        }
        DbSet<User> _users { get; set; }
    }
}
