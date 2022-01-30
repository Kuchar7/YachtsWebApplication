using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using YachtsWebApplication.Entities;

namespace YachtsWebApplication.DatabaseContexts
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("name=DbContext")
        {

        }

        public virtual DbSet<Yacht> Yachts { get; set; }
        public virtual DbSet<YachtCategory> YachtCategories { get; set; }
        public virtual DbSet<Booking> Bookings { get; set; }
    }
}