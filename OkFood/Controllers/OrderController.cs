using OkFood.Domain.Model.Entities;
using System;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using OkFood.Data.NStore;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections;
using System.Net;

namespace OkFood.Controllers
{
    [Authorize]
    public class OrderController : BaseController
    {

        private readonly IOrderStore<Order, Guid> orderService;
        private readonly IDeliveryAddressStore<DeliveryAddress, Guid> deliveryService;
        //private readonly IUserStore<IdentityUser, Guid> userService;
        public OrderController(IOrderStore<Order, Guid> orderService, IDeliveryAddressStore<DeliveryAddress, Guid> deliveryService/*, IUserStore<IdentityUser, Guid> userService*/)
        {
            this.deliveryService = deliveryService;
            this.orderService = orderService;
        }

        // GET: Order
        public ActionResult Index()
        {
            var res = orderService.AllOrderByUser(UserId);
            return View(res);
        }

        // GET: Order/Details/5
        public async Task<ActionResult> Details(Guid Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = await orderService.FindByIdAsync(Id);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdOrder = Id;
            return View(order);
        }


        // GET: Order/Create
        public ActionResult Create()
        {
            IEnumerable res = deliveryService.AllDeliveryAddressByUserId(UserId);
            ViewBag.DeliveryList = new SelectList(res, "DeliveryAdressId", "Comment");
            return View();
        }

        // POST: Order/Create
        //[HttpPost]
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Order order)
        {
            if (ModelState.IsValid)
            {
                await orderService.CreateAsync(order, UserId);
                return RedirectToAction("Index", "Order");
            }
            //IEnumerable res = deliveryService.AllDeliveryAddressByUserId(UserId);
            //ViewBag.DeliveryList = new SelectList(res, "DeliveryAdressId", "Comment", order.DeliveryAddressId);
            return View(order);
        }

            // GET: Order/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Order/Edit/5
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

        // GET: Order/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Order/Delete/5
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
