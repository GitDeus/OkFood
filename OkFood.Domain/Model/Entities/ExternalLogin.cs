using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkFood.Domain.Model.Entities
{
    public class ExternalLogin
    {
        private User _user;

        #region Scalar Properties
        public string LoginProvider { get; set; }
        public string ProviderKey { get; set; }
        public Guid UserId { get; set; }
        #endregion

        #region Navigation Properties
        public User User
        {
            get { return _user; }
            set
            {
                _user = value;
                UserId = value.UserId;
            }
        }
        #endregion
    }
}
