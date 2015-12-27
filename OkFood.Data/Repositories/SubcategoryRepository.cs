using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using OkFood.Data.Model.Interfaces;
using OkFood.Data.Model.Entities;


namespace OkFood.Data.Repositories
{
    //Subcategory Repository
    internal class SubcategoryRepository : Repository<Subcategory>, ISubcategoryRepository
    {
        internal SubcategoryRepository(DataContext context)
            : base(context)
        {
        }

        public Subcategory Get(Guid id)
        {
            return Set.Find(id);
        }

        public IList<Subcategory> GetAll(Guid catId)
        {
            return Set.FirstOrDefault(x => x.Category.Id == catId).Category.Subcategories.SkipWhile(x => x.Category.Id != catId).AsEnumerable()
                    .OrderBy(x => x.Category.Id).ToList();
        }
     

    }
}