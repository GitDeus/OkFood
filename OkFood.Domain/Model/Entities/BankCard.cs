using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkFood.Domain.Model.Entities
{
    public class BankCard
    {
        #region Fields
        private ICollection<BankCard> _card;
        private User _user;

        #endregion
        public Guid BankCardId { get; set; }

        public decimal BankCardNumber { get; set; }
        public decimal BankCardBalance { get; set; }
        public string Currency { get; set; }
        public DateTime DateAdd { get; set; }
        public DateTime DateUpdate { get; set; }
        public bool Activity { get; set; }

        public Guid UserId { get; set; }
        
        public User User
        {
            get { return _user; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("valueuser");
                _user = value;
            }
        }

    }
}
