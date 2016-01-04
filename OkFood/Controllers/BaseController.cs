using Microsoft.AspNet.Identity;
using OkFood.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OkFood.Controllers
{
    public class BaseController : Controller
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

    }
}