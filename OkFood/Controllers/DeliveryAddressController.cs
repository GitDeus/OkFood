using OkFood.Data.NStore;
using OkFood.Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace OkFood.Controllers
{
    public class DeliveryAddressController : BaseController
    {
        private readonly IDeliveryAddressStore<DeliveryAddress, Guid> deliveryService;
        public DeliveryAddressController(IDeliveryAddressStore<DeliveryAddress, Guid> deliveryService/*, IUserStore<IdentityUser, Guid> userService*/)
        {
            this.deliveryService = deliveryService;
        }
        // GET: DeliveryAddress
        public ActionResult Index()
        {
            ViewBag.Count = Count();
            var res = deliveryService.AllDeliveryAddressByUserId(UserId);
            return View(res);
        }

        // GET: DeliveryAddress/Create
        public ActionResult Create()
        {
            return View();
        }
        private int Count()
        {
            return deliveryService.Count(UserId);
        }

        // POST: DeliveryAddress/Create
        //[HttpPost]
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(DeliveryAddress deliveryAddress)
        {
            if (ModelState.IsValid) 
            {
                if (Count() <= 5)
                {
                    await deliveryService.CreateAsync(deliveryAddress, UserId);
                    return RedirectToAction("Index", "DeliveryAddress");
                }

            }
            return View(deliveryAddress);
        }
    }
}