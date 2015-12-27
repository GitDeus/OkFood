
using OkFood.Data.Model;
using OkFood.Data.Model.Entities;
using OkFood.Data.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkFood.Data.Model.Interfaces
{
   public interface ISubcategoryRepository : IRepository<Subcategory>
    {
        IList<Subcategory> GetAll(Guid catId);
        Subcategory Get(Guid id);
    }
}
