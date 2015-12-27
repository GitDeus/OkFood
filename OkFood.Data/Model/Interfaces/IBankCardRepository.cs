using OkFood.Data.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkFood.Data.Model.Interfaces
{
    public interface IBankCardRepository: IRepository<BankCard>
    {
        BankCard FindById(Guid CardId);
        BankCard GetAllByUserId(Guid UserId);
        BankCard GetCurrency(Guid CardId);
    }
}
