

using Microsoft.EntityFrameworkCore;
using Models;
using StudentSIS.API.Contracts;

namespace StudentSIS.API.DatabaseContext
{
    public class ApplicationDatabaseContext : DbContext, IApplicationDatabaseContext
    {


        public DbSet<Student> Student { get; set; }

        public ApplicationDatabaseContext(DbContextOptions<ApplicationDatabaseContext> options):base(options){}

 
    }
}
