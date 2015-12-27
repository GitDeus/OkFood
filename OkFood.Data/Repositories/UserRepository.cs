using OkFood.Data.Model.Entities;
using OkFood.Data.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace OkFood.Data.Repositories
{
    internal class UserRepository : Repository<User>, IUserRepository
    {
        internal UserRepository(DataContext context)
            : base(context)
        {
        }

        public User FindByCategory(Category category)
        {
            return Set.FirstOrDefault(s=> s.Categories.Select(x=>x.Id).Contains(category.Id));
        }
        public User FindByEmail(string email)
        {
            /////  
            throw new NotImplementedException();
        }

        public Task<User> FindByEmailAsync(string email)
        {
            /////       
            throw new NotImplementedException();
        }

        public Task<User> FindByEmailAsync(CancellationToken cancellationToken, string email)
        {
            /////  
            throw new NotImplementedException();
        }

        public User FindByUserName(string username)
        {
            return Set.FirstOrDefault(x => x.UserName == username);
        }

        public Task<User> FindByUserNameAsync(string username)
        {
            return Set.FirstOrDefaultAsync(x => x.UserName == username);
        }

        public Task<User> FindByUserNameAsync(System.Threading.CancellationToken cancellationToken, string username)
        {
            return Set.FirstOrDefaultAsync(x => x.UserName == username, cancellationToken);
        }
    }
}
