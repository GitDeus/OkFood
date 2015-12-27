using Cash_Inspection.Data.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cash_Inspection.Data.Model.Entities;
using System.Threading;

namespace Cash_Inspection.Service
{
    public class CategoryService: ICategoryRepository
    {
        private readonly ICategoryRepository _categoryRepository;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="categoryRepository"> </param>
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public void Add(Category entity)
        {
            throw new NotImplementedException();
        }

        public Category FindById(object id)
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

        public Category Get(Category cat)
        {
            throw new NotImplementedException();
        }

        public List<Category> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Category> GetAll(Category cat)
        {
            throw new NotImplementedException();
        }

        public Task<List<Category>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Category>> GetAllAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Subcategory> GetAllSubcategory(Category cat)
        {
            throw new NotImplementedException();
        }

        public void M1()
        {

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

        public void Remove(Category entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Category entity)
        {
            throw new NotImplementedException();
        }

        public List<Category> UserAllCategory(Guid UserId)
        {
            throw new NotImplementedException();
        }
    }
}
