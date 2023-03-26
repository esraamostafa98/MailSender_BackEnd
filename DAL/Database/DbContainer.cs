using EmailSender.DAL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace EmailSender.DAL.Database
{
    public class DbContainer : IdentityDbContext
    {
        public DbContainer(DbContextOptions opts) : base(opts)
        {
        }

        public DbSet<Messages> Messages { get; set; }
      
    }
}
