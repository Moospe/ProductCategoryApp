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
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            List<CategoryModel> categories;

            using (CategoryData data = new CategoryData())
            {
                categories = data.Read();
            }

            return View(categories);
        }

        // GET: Category/Details/5
        public ActionResult Details(Guid id)
        {
            CategoryModel category;

            using (CategoryData data = new CategoryData())
            {
                category = data.Read(id);
            }

            return View(category);
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoryModel category)
        {
            try
            {
                using (CategoryData data = new CategoryData())
                {
                    data.Create(category);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(category);
            }
        }

        // GET: Category/Edit/5
        public ActionResult Edit(Guid id)
        {
            CategoryModel category;

            using (CategoryData data = new CategoryData())
            {
                category = data.Read(id);
            }

            return View(category);
        }

        // POST: Category/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, CategoryModel category)
        {

            category.ID = id;

            try
            {
                using (CategoryData data = new CategoryData())
                {
                    data.Update(category);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(category);
            }
        }

        // GET: Category/Delete/5
        public ActionResult Delete(Guid id)
        {
            CategoryModel category;

            using (CategoryData data = new CategoryData())
            {
                category = data.Read(id);
            }

            return View(category);
        }

        // POST: Category/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, CategoryModel category)
        {
            try
            {
                using (CategoryData data = new CategoryData())
                {
                    data.Delete(id);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(category);
            }
        }
    }
}