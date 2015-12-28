using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.AspNet.Identity;
using System.Threading;
using OkFood.Domain.Model.Entities;
using OkFood.Domain.Interfaces;
using OkFood.Data.Context;

namespace OkFood.Data.Repositories
{
    //Category Repositiry
    internal class CategoryRepository: Repository<Category>, ICategoryRepository
    {
        internal CategoryRepository(DataContext context)
            : base(context)
        {
        }
        public Category Get(Category cat)
        {
            return Set.FirstOrDefault(x => x.Id == cat.Id);
        }

        public List<Category> UserAllCategory(Guid UserId)
        {

            return Set
                .Include(x => x.User)
                .Where(x => x.User.UserId == UserId)
                .ToList();
        }
        public IEnumerable<Subcategory> GetAllSubcategory(Category cat)
        {
            var employeeOptions = Set
            .SelectMany(res1 => cat.Subcategories
                               .Where(res2 => res2.Category.Id == res1.Id)
                               .Select(res2 => new Subcategory
                               {
                                   Id = res2.Id,
                                   Title = res2.Title,
                                   Value = res2.Value,
                                   Date = res2.Date,
                                   Category = res2.Category
                               }));
            return employeeOptions.AsEnumerable();
        }

        public List<Category> GetAll(Category cat)
        {
           return Set.Where(x=>x==cat).ToList();
        }



        public Task<List<Category>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Category>> GetAllAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public List<Category> PageAll(int skip, int take)
        {
            throw new NotImplementedException();
        }

        public Task<List<Category>> PageAllAsync(int skip, int take)
        {
            throw new NotImplementedException();
        }

        public Task<List<Category>> PageAllAsync(CancellationToken cancellationToken, int skip, int take)
        {
            throw new NotImplementedException();
        }

        public Task<Category> FindByIdAsync(object id)
        {
            throw new NotImplementedException();
        }

        public Task<Category> FindByIdAsync(CancellationToken cancellationToken, object id)
        {
            throw new NotImplementedException();
        }

        public Category Get(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
