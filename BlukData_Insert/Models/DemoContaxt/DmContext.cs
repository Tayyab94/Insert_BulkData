using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlukData_Insert.Models.DemoContaxt
{
    public class DmContext:IdentityDbContext
    {
        
        public DmContext(DbContextOptions options):base(options)
        {

        }

        public DbSet<ContactInfo> ContactInfos { get; set; }
    }
}
