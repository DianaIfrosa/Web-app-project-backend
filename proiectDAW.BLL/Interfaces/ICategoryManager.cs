using proiectDAW.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proiectDAW.BLL.Interfaces
{
    public interface ICategoryManager
    {
        public List<Category> CategoriesSelect();
        public List<string> CategoriesJoin();
        void AddCategory(Category categ);
        void DeleteCategory(Category categ);
        void UpdateCategory(int id, Category categ);
       
    }
}
