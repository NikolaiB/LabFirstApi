using Microsoft.EntityFrameworkCore;
using WebApplication10.Models;

namespace WebApplication10.Data
{
    public class ApiPetContext : DbContext

    {
        public ApiPetContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Pet> Pets { get; set; }

    }
}
