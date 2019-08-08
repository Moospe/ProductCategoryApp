using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductCategoryApp.Models;
using ProductCategoryApp.Data;

namespace ProductCategoryApp.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            List<ProductModel> products;

            using (ProductData data = new ProductData())
            {
                products = data.Read();
            }

            return View(products);
        }

        [Route("product/filter/{category}")]
        // GET: Product/{Category}
        public ActionResult Index(string category)
        {
            List<ProductModel> products;
            List<ProductModel> filterdProducts = new List<ProductModel>();

            using (ProductData data = new ProductData())
            {
                products = data.Read();
            }
            foreach(ProductModel product in products)
            {
                if(product.Category?.Name == category)
                {
                    filterdProducts.Add(product);
                }
            }


            return View(filterdProducts);
        }
        // GET: Product/Details/5
        public ActionResult Details(Guid id)
        {
            ProductModel product;

            using (ProductData data = new ProductData())
            {
                product = data.Read(id);
            }

            return View(product);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductModel product)
        {
            try
            {
                using(ProductData data = new ProductData())
                {
                    data.Create(product);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(product);
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(Guid id)
        {
            ProductModel product;

            using (ProductData data = new ProductData())
            {
                product = data.Read(id);
            }

            return View(product);
        }

        // POST: Product/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, ProductModel product)
        {

            product.Id = id;

            try
            {
                using(ProductData data = new ProductData())
                {
                    data.Update(product);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(product);
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(Guid id)
        {
            ProductModel product;

            using (ProductData data = new ProductData())
            {
                product = data.Read(id);
            }

            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, ProductModel product)
        {
            try
            {
                using (ProductData data = new ProductData())
                {
                    data.Delete(id);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(product);
            }
        }
    }
}