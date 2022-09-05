using proiectDAW.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proiectDAW.DAL.Interfaces
{
    public interface IMaterialRepository
    {
        //nu apare public/protected/private aici
        IQueryable<Material> GetAll();
        Material GetById(int id);
        Task Create(Material m);
        Task Delete(Material m);
        Task Update(int id, float price);
        Task<IQueryable<Material>> GetAllQuery(); //functie ajutatoare
    }
}
