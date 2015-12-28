
using OkFood.Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkFood.Domain.Interfaces
{
   public interface ISubcategoryRepository : IRepository<Subcategory>
    {
        IList<Subcategory> GetAll(Guid catId);
        Subcategory Get(Guid id);
    }
}
