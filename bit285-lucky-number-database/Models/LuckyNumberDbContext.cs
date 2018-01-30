using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using lucky_number_database.Models;

namespace bit285_lucky_number_database.Models
{
    public class LuckyNumberDbContext : DbContext
    {
        public LuckyNumberDbContext() : base("LuckyNumber") { }

        public DbSet<LuckyNumber> LuckyNumbers { get; set; }
    }
}