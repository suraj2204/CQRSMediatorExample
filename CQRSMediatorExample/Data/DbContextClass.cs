using CQRSMediatorExample.Models;
using Microsoft.EntityFrameworkCore;

namespace CQRSMediatorExample.Data
{
    public class DbContextClass: DbContext
    {
        protected readonly IConfiguration _configuration;

        public DbSet<StudentDetails> StudentDetails { get; set; }

        public DbContextClass(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        //public DbContextClass(DbContextOptions<DbContextClass> options) : base(options)
        //{

        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
        }



    }
}
