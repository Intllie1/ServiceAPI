using Microsoft.EntityFrameworkCore;
using RegistrationAPI.DataAccess.Models;
using RegistrationAPI.objects.Proxies;

namespace RegistrationAPI.DataAccess.Context
{
    public class MySQLDBContext:DbContext
    {
        public MySQLDBContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Registration> Registration { get; set; }
    }
}
