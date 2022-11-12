using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MiniShop.Data.Abstract;
using MiniShop.Entity;

namespace MiniShop.Data.Concreate
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private Context_MiniShop context
        {
            get
            {
                return _dbContext as Context_MiniShop;
            }
        }
        public CategoryRepository(Context_MiniShop dbContext) : base(dbContext)
        {

        }
    }
}