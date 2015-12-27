using OkFood.Data.Model.Entities;
using OkFood.Data.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkFood.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Fields
        private readonly DataContext _context;
        private IExternalLoginRepository _externalLoginRepository;
        private IRoleRepository _roleRepository;
        private IUserRepository _userRepository;
        private ICategoryRepository _categoryRepository;
        private ISubcategoryRepository _subcategoryRepository;
        private IBankCardRepository _bankcardRepository;
        #endregion

        #region Constructors
        public UnitOfWork(string nameOrConnectionString)
        {
            _context = new DataContext(nameOrConnectionString);
        }
        #endregion

        #region IUnitOfWork Members
        public IExternalLoginRepository ExternalLoginRepository
        {
            get { return _externalLoginRepository ?? (_externalLoginRepository = new ExternalLoginRepository(_context)); }
        }

        public IRoleRepository RoleRepository
        {
            get { return _roleRepository ?? (_roleRepository = new RoleRepository(_context)); }
        }

        public IUserRepository UserRepository
        {
            get { return _userRepository ?? (_userRepository = new UserRepository(_context)); }
        }
        public ICategoryRepository CategoryRepository
        {
            get { return _categoryRepository ?? (_categoryRepository = new CategoryRepository(_context)); }
        }
        public ISubcategoryRepository SubcategoryRepository
        {
            get { return _subcategoryRepository ?? (_subcategoryRepository = new SubcategoryRepository(_context)); }
        }
        public IBankCardRepository BankCardRepository
        {
            get { return _bankcardRepository ?? (_bankcardRepository = new BankCardRepository(_context)); }
        }
        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

        public Task<int> SaveChangesAsync(System.Threading.CancellationToken cancellationToken)
        {
            return _context.SaveChangesAsync(cancellationToken);
        }
        #endregion

        #region IDisposable Members
        public void Dispose()
        {
            _externalLoginRepository = null;
            _roleRepository = null;
            _userRepository = null;
            _context.Dispose();
        }
        #endregion
    }
}
