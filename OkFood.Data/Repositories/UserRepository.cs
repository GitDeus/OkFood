﻿
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using OkFood.Domain.Model.Entities;
using OkFood.Domain.Interfaces;
using OkFood.Data.Context;

namespace OkFood.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DataContext context)
            : base(context)
        {
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
