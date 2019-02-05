using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PTPTestPortal.Models;

namespace PTPTestPortal.Models
{
    public class PTPTestContext:DbContext
    {
        public PTPTestContext(DbContextOptions<PTPTestContext> options) : base(options)
        { }
        public DbSet<FAQ> faq{ get; set; }
        public DbSet<NEWs> news { get; set; }
    }
}
