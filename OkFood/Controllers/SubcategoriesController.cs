
using OkFood.Data.Repositories;
using OkFood.Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace OkFood.Controllers
{
    [Authorize]
    public class SubcategoriesController : Controller
    {

        private readonly UnitOfWork _Manager;

        public SubcategoriesController(UnitOfWork manager) { _Manager = manager; }
        // GET: Subcategories
        /// <summary>
        /// Add Subcategory method
        /// </summary>
        /// <param name="subcategory"></param>
        /// <returns></returns>
        public int AddSubcategory(Subcategory subcategory, Guid? categoryId)
        {
            if (subcategory == null)
                throw new ArgumentNullException("subcategory");

            var category = _Manager.CategoryRepository.FindById(subcategory.CategoryId);
            if (category == null)
                throw new ArgumentException("Subcategory does not correspond.", "category");

            var c = new Subcategory
            {
                Id = subcategory.Id,
                Value = subcategory.Value,
                Title = subcategory.Title,
                Date = DateTime.Now,
                CategoryId = subcategory.CategoryId,

                Category = category
            };
            category.NumberofMoney -= c.Value;
            category.Subcategories.Add(c);
            _Manager.CategoryRepository.Update(category);
            return _Manager.SaveChanges();
        }
        // GET: Subcategories/Create
        public ActionResult Create(Guid Id)
        {
            ViewBag.CategoryId = Id;
            return View(new Subcategory() { CategoryId = Id, Value = decimal.Zero, Title = string.Empty, Date = DateTime.UtcNow});
        }

        // POST: Subcategories/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Value,CategoryId")] Subcategory subcategory)
        {

            if (ModelState.IsValid)
            {
                if (_Manager.CategoryRepository.FindById(subcategory.CategoryId).NumberofMoney < subcategory.Value)
                {
                    RedirectToAction("Index", "Categories");
                }
                else
                {
                    AddSubcategory(subcategory, subcategory.CategoryId);
                }
                return RedirectToAction("Details", "Categories", new { id = subcategory.CategoryId });
            }
            ViewBag.CategoryId = new SelectList(_Manager.CategoryRepository.GetAll(), "Id", "Title", subcategory.CategoryId);
            return View(subcategory);
        }

        // GET: Subcategories/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subcategory subcategory = _Manager.SubcategoryRepository.FindById(id);
            if (subcategory == null)
            {
                return HttpNotFound();
            }
            return View(subcategory);
        }

        // POST: Subcategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Subcategory subcategory = _Manager.SubcategoryRepository.FindById(id);
            _Manager.SubcategoryRepository.Remove(subcategory);
            _Manager.SaveChanges();
            return RedirectToAction("Index", "Categories");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
