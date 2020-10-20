using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using CentricProject_Team10.Models;

namespace CentricProject_Team10.DAL
{
    public class CentricContext : DbContext
    {
            public CentricContext() : base ("nameDefaultConnection")
            {

            }
        public DbSet<userData> userData { get; set; }

    }
    }