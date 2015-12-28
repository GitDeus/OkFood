
using OkFood.Data.Repositories;
using OkFood.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OkFood.Domain.Model.Entities;

namespace OkFood.Controllers
{
    public class BankCardsController : Controller
    {
        protected bool UserIsAuthenticated
        {
            get
            {
                return System.Web.HttpContext.Current.User.Identity.IsAuthenticated;
            }
        }

        protected Guid UserId
        {
            get
            {
                var result = default(Guid);
                Guid.TryParse(UserIsAuthenticated ? System.Web.HttpContext.Current.User.Identity.GetUserId() : null, out result);
                return result;
            }
        }
        private readonly UnitOfWork _Manager;

        public BankCardsController(UnitOfWork manager) { _Manager = manager; }

        // GET: BankCards
        public ActionResult Index()
        {

            var result = _Manager.BankCardRepository.GetAllByUserId(UserId);
            return View(result);
        }

        // GET: BankCards/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        public int AddCard(BankCard card)
        {
            if (card == null)
                throw new ArgumentNullException("category");

            var user = _Manager.UserRepository.FindById(UserId);
            if (user == null)
                throw new ArgumentException("IdentityUser не соответствуют сущности пользователя.", "user");
            //else if (user.TotalMoney < category.NumberofMoney)
            //    throw new ArgumentException("Недостаточно средств", "user");

            var c = new BankCard
            {
                BankCardId = card.BankCardId,
                BankCardNumber = card.BankCardNumber,
                Currency = card.Currency,
                UserId = UserId,
                User = user
            };

            //user.TotalMoney -= c.NumberofMoney;
            user.BankCards.Add(c);

            _Manager.UserRepository.Update(user);
            return _Manager.SaveChanges();
        }
        // GET: BankCards/Create
        public ActionResult Create([Bind(Include = "BankCardNumber,Currency")] BankCard card)
        {
            if (ModelState.IsValid)
            {
                //if (_Manager.UserRepository.FindById(UserId).TotalMoney < category.NumberofMoney)
                //{

                //    return RedirectToAction("TotalMoneyEdit", "Categories");
                //}
                //else
                //{
                AddCard(card);
                return RedirectToAction("Index", "BankCards");
                //}
            }
            return View();
        }

        // POST: BankCards/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: BankCards/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BankCards/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: BankCards/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BankCards/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
