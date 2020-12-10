using BusinessLogic.Interfaces;
using Dal.Interfaces;
using Dal;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete
{
    public class Category: ICategory
    {
        private readonly ICategoryDal _categoryDal;
        public Category(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public List<CategoryDTO> GetAllCategories()
        {
            return _categoryDal.GetAllCategories();
        }
    }
}
