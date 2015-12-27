using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using OkFood.Data.Identity;
using Microsoft.AspNet.Identity;
using System.ComponentModel.DataAnnotations;

namespace OkFood.Data.Model.Entities
{
    public class User
    {
        #region Fields
        private ICollection<Claim> _claims;
        private ICollection<ExternalLogin> _externalLogins;
        private ICollection<Role> _roles;
        private ICollection<Category> _categories;
        private ICollection<BankCard> _cards;
        private ICollection<Order> _orders;

        #endregion

        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }


        public ICollection<Order> Orders
        {
            get { return _orders?? (_orders = new List<Order>()); }
            set { _orders = value; }
        }
        public ICollection<BankCard> BankCards
        {
            get { return _cards ?? (_cards = new List<BankCard>()); }
            set { _cards = value; }
        }
        public ICollection<Claim> Claims
        {
            get { return _claims ?? (_claims = new List<Claim>()); }
            set { _claims = value; }
        }

        public ICollection<ExternalLogin> Logins
        {
            get
            {
                return _externalLogins ??
                    (_externalLogins = new List<ExternalLogin>());
            }
            set { _externalLogins = value; }
        }

        public ICollection<Role> Roles
        {
            get { return _roles ?? (_roles = new List<Role>()); }
            set { _roles = value; }
        }
        public ICollection<Category> Categories
        {
            get { return _categories ?? (_categories = new List<Category>()); }
            set { _categories = value; }
        }
    }
}
