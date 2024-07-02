using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Web;
using MySql.Data.EntityFramework;
using Scada.models;

namespace Scada.repositories
{
    public class ScadaContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Tag> Tags { get; set; }
    }
}