using OkFood.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OkFood.Domain.Model.Entities;
using System.Threading;

namespace OkFood.BLL
{
    public partial class BankCardService : IBankCardRepository
    {
        private readonly IBankCardRepository _bankcardRepository;

        public void Add(BankCard entity)
        {
            _bankcardRepository.Add(entity);
        }

        public BankCard FindById(object id)
        {
            return _bankcardRepository.FindById(id);
        }

        public BankCard FindById(Guid CardId)
        {
            return _bankcardRepository.FindById(CardId);
        }

        public List<BankCard> GetAll()
        {
            return _bankcardRepository.GetAll();
        }
        public void Remove(BankCard entity)
        {
            _bankcardRepository.Remove(entity);
        }

        public void Update(BankCard entity)
        {
            _bankcardRepository.Update(entity);
        }
        public decimal GetBalance(Guid CardId)
        {
            return _bankcardRepository.FindById(CardId).BankCardBalance;
        }
        public IList<BankCard> GetAllByUserId(Guid UserId)
        {
            return _bankcardRepository.GetAllByUserId(UserId);
        }

        public BankCard GetCurrency(Guid CardId)
        {
            return _bankcardRepository.GetCurrency(CardId);
        }
        public bool Activity(Guid CardId)
        {
            return _bankcardRepository.Activity(CardId);
        }








        public Task<BankCard> FindByIdAsync(object id)
        {
            throw new NotImplementedException();
        }

        public Task<BankCard> FindByIdAsync(CancellationToken cancellationToken, object id)
        {
            throw new NotImplementedException();
        }

        public Task<List<BankCard>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<BankCard>> GetAllAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public List<BankCard> PageAll(int skip, int take)
        {
            throw new NotImplementedException();
        }

        public Task<List<BankCard>> PageAllAsync(int skip, int take)
        {
            throw new NotImplementedException();
        }

        public Task<List<BankCard>> PageAllAsync(CancellationToken cancellationToken, int skip, int take)
        {
            throw new NotImplementedException();
        }


    }

}
