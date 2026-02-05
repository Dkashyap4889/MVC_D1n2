using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVC_Assignment.Models;

namespace MVC_Assignment.Data
{
    public class MVC_AssignmentContext : DbContext
    {
        public MVC_AssignmentContext (DbContextOptions<MVC_AssignmentContext> options)
            : base(options)
        {
        }

        public DbSet<MVC_Assignment.Models.CustomerModel> CustomerModel { get; set; } = default!;
    }
}
