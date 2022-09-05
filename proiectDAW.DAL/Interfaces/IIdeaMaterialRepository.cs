using proiectDAW.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proiectDAW.DAL.Interfaces
{
    public interface IIdeaMaterialRepository
    {
        //nu apare public/protected/private aici
        IQueryable<IdeaMaterial> GetAll();
        Task Create(IdeaMaterial im);
        Task Delete(IdeaMaterial im);
        Task Update(IdeaMaterial im, int number);
        Task<IQueryable<IdeaMaterial>> GetAllQuery(); //functie ajutatoare





    }
}
