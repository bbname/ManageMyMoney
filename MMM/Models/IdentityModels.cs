using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MMM.Models
{
    public class DbContext : IdentityDbContext
    {
        public DbContext()
            : base("DefaultConnection")
        {
        }

        public static DbContext Create()
        {
            return new DbContext();
        }
    }
}