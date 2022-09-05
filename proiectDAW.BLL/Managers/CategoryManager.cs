using proiectDAW.BLL.Interfaces;
using proiectDAW.DAL.Entities;
using proiectDAW.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proiectDAW.BLL.Managers
{
    public class CategoryManager:ICategoryManager
    {
        private readonly ICategoryRepository _categRepository;
        public CategoryManager(ICategoryRepository categRepository)
        {
            _categRepository = categRepository;
        }

        public List<Category>  CategoriesSelect()
        {
            var select = _categRepository
                 .GetAll()
                 .OrderByDescending(c => c.PopularityScore)
                 .Select(c => new Category{ Id = c.Id, Name = c.Name, PopularityScore = c.PopularityScore })
                 .ToList(); //aduce sql query in memoria aplicatiei
            return select;
        }

        public List<string> CategoriesJoin()
        {
           
            var categs = _categRepository.GetAll();
            var join=_categRepository.CategoriesJoin(categs);
           
            return join;
        }
        
         public void AddCategory(Category categ)
        {
            _categRepository.Create(categ);
        }
       
         public void DeleteCategory(Category categ)
        {
            _categRepository.Delete(categ);
        }
     
        public void UpdateCategory(int id, Category categ)
        {
            var categModified = _categRepository.GetById(id);
            categModified = categ;
        }
      
    }
}
