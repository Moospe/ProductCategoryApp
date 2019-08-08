using System;
using System.Collections.Generic;
using System.Text;
using ProductCategoryApp.Models;
using System.Linq;


namespace ProductCategoryApp.Data
{
    public class CategoryData : IDisposable
    {
        private DBContext Context { get; }

        public CategoryData()
        {
            Context = new DBContext();
        }

        public void Create(CategoryModel category)
        {
            category.ID = Guid.NewGuid();
            Context.Categories.Add(category);
            Context.SaveChanges();
        }

        public List<CategoryModel> Read()
        {
            return Context.Categories.ToList();
        }

        public CategoryModel Read(Guid id)
        {
            return Context.Categories.FirstOrDefault(item => item.ID == id);
        }

        public void Update(CategoryModel category)
        {
            Context.Categories.Update(category);
            Context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            Context.Categories.Remove(Context.Categories.FirstOrDefault(item => item.ID == id));
            Context.SaveChanges();

        }

        public void Dispose()
        {
            Context?.Dispose();
        }
    }
}
