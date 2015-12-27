
using OkFood.Data.Model.Entities;
using OkFood.Data.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkFood.Data.Model.Interfaces
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
