using OkFood.Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkFood.Domain.Interfaces
{
    public interface ICategoryRepository: IRepository<Category>
    {
        List<Category> UserAllCategory(Guid UserId);
        Category Get(Category cat);
        List<Category> GetAll(Category cat);
        IEnumerable<Subcategory> GetAllSubcategory(Category cat);
        Category Get(Guid id);
    }
}
