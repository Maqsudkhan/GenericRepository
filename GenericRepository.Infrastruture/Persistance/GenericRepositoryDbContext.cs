using GenericRepository.Domain.Entites.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepository.Domain.Entites.DTOs.Persistance
{
    public class GenericRepositoryDbContext : DbContext
    {
        public GenericRepositoryDbContext(DbContextOptions<GenericRepositoryDbContext> options ) : base(options)
        {
            Database.Migrate();
        }

        public  DbSet<User> Users { get; set; }
    }
}
