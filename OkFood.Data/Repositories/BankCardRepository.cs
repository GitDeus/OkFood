using OkFood.Data.Context;
using OkFood.Domain.Interfaces;
using OkFood.Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkFood.Data.Repositories
{
    internal class BankCardRepository : Repository<BankCard>, IBankCardRepository
    {
        internal BankCardRepository(DataContext context)
            : base(context)
        {
        }
        public BankCard FindById(Guid CardId)
        {
            return Set.FirstOrDefault(s => s.User.BankCards.Select(x => x.BankCardId).Contains(CardId));
        }

        public BankCard GetAllByUserId(Guid UserId)
        {
            return Set.FirstOrDefault(s => s.User.BankCards.Select(x => x.UserId).Contains(UserId));
        }

        public BankCard GetCurrency(Guid CardId)
        {
            return Set.FirstOrDefault(s => s.BankCardId == CardId);
        }
    }
}
