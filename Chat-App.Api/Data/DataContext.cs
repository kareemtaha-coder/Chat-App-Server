using Chat_App.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Chat_App.Api.Data
{
    public class DataContext (DbContextOptions<DataContext> options) : DbContext(options)
    {
        public DbSet<AppUser> Users { get; set; } = null!;
    }

}
