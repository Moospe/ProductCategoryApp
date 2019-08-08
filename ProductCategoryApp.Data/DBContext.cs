using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ProductCategoryApp.Models;

namespace ProductCategoryApp.Data
{
    public class DBContext : DbContext
    {
        public DBContext() { }

        public DBContext(DbContextOptions<DbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=ProductCategoryApp;Trusted_Connection=True;ConnectRetryCount=0");
            }
        }

        public DbSet<ProductModel> Products { get; set; }

        public DbSet<CategoryModel> Categories { get; set; }

        public DbSet<CollectionModel> Collections { get; set; }
    }
}
