
using OkFood.Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace OkFood.Domain.Interfaces
{
    public interface IBankCardRepository: IRepository<BankCard>
    {
        BankCard FindById(Guid CardId);
        IList<BankCard> GetAllByUserId(Guid UserId);
        BankCard GetCurrency(Guid CardId);
        decimal GetBalance(Guid CardId);
        bool Activity(Guid CardId);
    }
}
