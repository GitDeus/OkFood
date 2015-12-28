using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkFood.Domain.Model.Entities
{
    public class Claim
    {
        private User _user;

        #region Scalar Properties
        public int ClaimId { get; set; }
        public Guid UserId { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
        #endregion

        #region Navigation Properties
        public User User
        {
            get { return _user; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("value");
                _user = value;
                UserId = value.UserId;
            }
        }
        #endregion
    }
}
