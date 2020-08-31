using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MySql.Data.EntityFrameworkCore.Extensions;

namespace OnlineExamApp.Models
{
    public class ExamAppDbContext : DbContext
    {
      public DbSet<CustomerAccounts> CustomerAccount { get; set; }
        public DbSet<CustomerRoles> CustomerRoles { get; set; }
        public DbSet<ChoiceTable> choiceTables { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<SimTest> SimTests { get; set; }
        public DbSet<Test> Tests { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseMySQL("server=localhost;database=ExamLibrary;user=root;pasword=test123#");
        //}

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //}

        public ExamAppDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
