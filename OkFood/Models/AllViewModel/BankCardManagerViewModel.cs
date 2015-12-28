using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OkFood.Models.AllViewModel
{
    public class BankCardManagerViewModel
    {
        [Required]
        [Display(Name = "Номер банковской карты")]
        [DataType(DataType.CreditCard)]
        public decimal BankCardNumber { get; set; }

        [Required]
        [Display(Name = "Валюта")]
        [DataType(DataType.Text)]
        public string Currency { get; set; }
    }
}