using proiectDAW.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proiectDAW.DAL.Interfaces
{
    public interface ICategoryRepository
    {
        //nu apare public/protected/private aici
        IQueryable<Category> GetAll();
        Category GetById(int id);
        Task Create(Category categ);
        Task Delete(Category categ);
        Task Update(Category categ);
        Task<IQueryable<Category>> GetAllQuery(); //functie ajutatoare
        List<string> CategoriesJoin(IQueryable<Category> categs);
    }
}
