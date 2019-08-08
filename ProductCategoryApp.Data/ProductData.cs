using System;
using System.Collections.Generic;
using System.Text;
using ProductCategoryApp.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ProductCategoryApp.Data
{
    public class ProductData : IDisposable
    {
        private DBContext Context { get; }

        public ProductData()
        {
            Context = new DBContext();
        }
        
        public void Create(ProductModel product) {

            product.Category = Context.Categories.FirstOrDefault(item => item.ID == product.Category.ID);
            product.Id = Guid.NewGuid();
            Context.Products.Add(product);
            Context.SaveChanges();
        }

        public List<ProductModel> Read()
        {
            return Context.Products.Include("Category").ToList();
        }

        public ProductModel Read(Guid id)
        {
            return Context.Products.Include("Category").FirstOrDefault(item => item.Id == id);
        }

        public void Update(ProductModel product)
        {
            product.Category = Context.Categories.FirstOrDefault(item => item.ID == product.Category.ID);
            Context.Products.Update(product);
            Context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            Context.Products.Remove(Context.Products.FirstOrDefault(item => item.Id == id));
            Context.SaveChanges();

        }

        public void Dispose()
        {
            Context?.Dispose();
        }
    }
}
