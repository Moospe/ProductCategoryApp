using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProductCategoryApp.Models
{
    public class CategoryModel
    {
        [Key]
        public Guid ID { get; set; }
        public string Name { get; set; }
        public CollectionModel Collection { get; set; }
    }
}
