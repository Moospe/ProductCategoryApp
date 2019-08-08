using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductCategoryApp.Models
{
    public class ProductModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal CurrentValue { get; set; }
        public decimal PurchaseValue { get; set; }
        public decimal Weight { get; set; }
        public decimal Length_X { get; set; }
        public decimal Length_Y { get; set; }
        public decimal Length_Z { get; set; }
        public string Color { get; set; }
        public CategoryModel Category { get; set; }
    }
}
