using demo.Models;
using Microsoft.EntityFrameworkCore;

namespace demo.Data
{
    public class ContextApplication:DbContext
    {
        public ContextApplication(DbContextOptions options): base(options) 
        {
            
        }
        public DbSet<trial> trials { get; set; }
    }
}
