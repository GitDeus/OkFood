using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using OkFood.Data.Repositories;
using OkFood.Data.Identity;
using System.Net;
using System.Collections.Generic;
using System.Data.Entity;
using OkFood.Models;
using Newtonsoft.Json;
using System.Linq;
using System.Web.Script.Services;
using System.Web.Services;
using OkFood.Domain.Model.Entities;
using OkFood.Data.NStore;

namespace OkFood.Controllers
{
    [Authorize(Roles = "Manager")]
    public class CategoriesController : BaseController
    {
        private readonly UnitOfWork _Manager;
        private readonly IOrderStore<Order, Guid> orderStore;
        public CategoriesController(UnitOfWork manager, IOrderStore<Order, Guid> orderStore) {

            this.orderStore = orderStore;
            _Manager = manager;
        }
        [HttpGet]
        public JsonResult Piechart(Guid Id) {

            var chartsdata = _Manager.SubcategoryRepository.GetAll().Where(x=>x.CategoryId == Id).Select(x=>x);
            return Json(chartsdata.ToList(), JsonRequestBehavior.AllowGet);


        }
        // GET: Categories
        public ActionResult Index()
        {
            var result = UserIsAuthenticated ? _Manager.CategoryRepository.UserAllCategory(UserId) : null;
            return View(result);
        
        }

        // GET: Categories/Details/5
        public ActionResult Details(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = _Manager.CategoryRepository.FindById(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCategory = id;
            return View(category);
        }

        // GET: Categories/Create
        public ActionResult Create(Guid Id)
        {
            ViewBag.OrderId = Id;
            //ViewBag.OrderId = new SelectList(orderStore.AllOrderByUser(UserId), "OrderId", "Title");
            return View(new Category() { Id = Guid.NewGuid(), OrderId = Id, Title = string.Empty, NumberofMoney = decimal.Zero });
        }
        //private Guid getGuid(string value)
        //{
        //    var result = default(Guid);
        //    Guid.TryParse(value, out result);
        //    return result;
        //}



        /// <summary>
        /// Add Category method
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public int AddCategory(Category category)
        {
            if (category == null)
                throw new ArgumentNullException("category");

            var order = _Manager.OrderRepository.FindById(category.OrderId);
            if (order == null) 
                throw new ArgumentException("IdentityUser не соответствуют сущности пользователя.", "user");
            //else if (user.TotalMoney < category.NumberofMoney)
            //    throw new ArgumentException("Недостаточно средств", "user");

            var c = new Category
            {
                Id = Guid.NewGuid(),
                NumberofMoney = category.NumberofMoney,
                Title = category.Title,
                OrderId = category.OrderId,

                Order = order
            };
            //user.TotalMoney -= c.NumberofMoney;
            order.Categories.Add(c);

            _Manager.OrderRepository.Update(order);
            return _Manager.SaveChanges();
        }
        ////GET
        //public string TotalMoney()
        //{
        //    var user = _Manager.UserRepository.FindById(UserId);

        //    return string.Format("{0:n0}", user.TotalMoney);
        //}

        //// GET: Categories/Edit/5
        //public ActionResult TotalMoneyEdit()
        //{

        //    var user = _Manager.UserRepository.FindById(UserId);
        //    var userres = new AddTotalMoneyViewModel
        //    {
        //        TotalMoney = user.TotalMoney
        //    };
        //    if (user == null)
        //    {
        //        return HttpNotFound();
        //    }

        //    return View(userres);
        //}
        //// POST: TotalMoneyEdit
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult TotalMoneyEdit([Bind(Include = "TotalMoney")] AddTotalMoneyViewModel totalMoneyModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var user = _Manager.UserRepository.FindById(UserId);
        //            //user.TotalMoney = totalMoneyModel.TotalMoney;
        //        _Manager.UserRepository.Update(user);
        //        _Manager.SaveChanges();

        //        return RedirectToAction("Index", "Categories");
        //    }
            
        //    return View(totalMoneyModel);
        //}
        // POST: Categories/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,NumberofMoney,OrderId")] Category category)
        {

            if (ModelState.IsValid)
            {
                //if (_Manager.UserRepository.FindById(UserId).TotalMoney < category.NumberofMoney)
                //{

                //    return RedirectToAction("TotalMoneyEdit", "Categories");
                //}
                //else
                //{
                if (orderStore.AllOrderByUser(UserId).Count > 0)
                {
                    AddCategory(category);
                    return RedirectToAction("Index", "Categories");
                //}
                }
                else
                {
                    return RedirectToAction("Index", "Orders");
                }
                ViewBag.OrderId = new SelectList(_Manager.CategoryRepository.GetAll(), "Id", "Title", category.OrderId);
            }

            return View(category);
        }

        // GET: Categories/Edit/5
        public ActionResult Edit(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Category category = _Manager.CategoryRepository.FindById(id);
            if (category == null)
            {
                return HttpNotFound();
            }


            return View(category);
        }

            
        // POST: Categories/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,NumberofMoney")] Category category)
        {
            if (ModelState.IsValid)
            {

                category.OrderId = category.OrderId;/**ddddddddd*/
                _Manager.CategoryRepository.Update(category);
                _Manager.SaveChanges();
                return RedirectToAction("Index", "Categories");
            }
            return View(category);
        }

        // GET: Categories/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = _Manager.CategoryRepository.FindById(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public ActionResult DeleteConfirmed(Guid? id)
        {
            Category category = _Manager.CategoryRepository.FindById(id);
            //var res = _Manager.UserRepository.FindById(UserId);
            //    res.TotalMoney += category.NumberofMoney;
            //_Manager.UserRepository.Update(res);
            //_Manager.SaveChanges();
            _Manager.CategoryRepository.Remove(category);
            _Manager.SaveChanges();
            return RedirectToAction("Index", "Categories");
        }
    }
}
