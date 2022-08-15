using Microsoft.EntityFrameworkCore;
using Models;


namespace StudentSIS.API.Contracts
{
    public interface IApplicationDatabaseContext
    {
        public DbSet<Student> Student { get; set; }
    }
}
