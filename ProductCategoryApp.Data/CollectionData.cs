using System;
using System.Collections.Generic;
using System.Text;
using ProductCategoryApp.Models;
using System.Linq;


namespace ProductCategoryApp.Data
{
    public class CollectionData : IDisposable
    {
        private DBContext Context { get; }

        public CollectionData()
        {
            Context = new DBContext();
        }

        public void Create(CollectionModel collection)
        {
            collection.ID = Guid.NewGuid();
            Context.Collections.Add(collection);
            Context.SaveChanges();
        }

        public List<CollectionModel> Read()
        {
            return Context.Collections.ToList();
        }

        public CollectionModel Read(Guid id)
        {
            return Context.Collections.FirstOrDefault(item => item.ID == id);
        }

        public void Update(CollectionModel collection)
        {
            Context.Collections.Update(collection);
            Context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            Context.Collections.Remove(Context.Collections.FirstOrDefault(item => item.ID == id));
            Context.SaveChanges();

        }

        public void Dispose()
        {
            Context?.Dispose();
        }
    }
}
