using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using WebAppCoreExample.Models;

namespace WebAppCoreExample.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {


        } 


        //add category model here
        public DbSet<Category> Categories { get; set; }
    }
}
