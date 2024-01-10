using DAL.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace DAL.Context
{
    public class TestContext : DbContext
    {
        public TestContext(DbContextOptions<TestContext> options) : base(options)
        {

        }
        public Microsoft.EntityFrameworkCore.DbSet<User> Users { get; set; }

        public Microsoft.EntityFrameworkCore.DbSet<Student> Students { get; set; }

        public Microsoft.EntityFrameworkCore.DbSet<Teacher> Teachers { get; set; }


    }
}
