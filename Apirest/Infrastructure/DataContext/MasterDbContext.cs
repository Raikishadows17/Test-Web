using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Infrastructure.DataContext
{
    public class MasterDbContext : DbContext
    {
        public MasterDbContext(DbContextOptions<MasterDbContext> options) : base(options)
        {
        }
    }
}
