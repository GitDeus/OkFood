using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkFood.Data.Model.Entities
{
    public class BankCard
    {
        #region Fields
        private ICollection<BankCard> _card;
        private User _user;

        #endregion
        public Guid BankCardId { get; set; }

        [DataType(DataType.CreditCard)]
        public decimal BankCardNumber { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Currency { get; set; }

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
