using proiectDAW.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proiectDAW.DAL
{
    public interface IDIYIdeaRepository
    {
        //nu apare public/protected/private aici
        IQueryable<DIYIdea> GetAll();
        DIYIdea GetById(int id);
        Task Create(DIYIdea idea);
        Task Delete(DIYIdea idea);
        Task Update(DIYIdea idea);
        Task<IQueryable<DIYIdea>> GetAllQuery(); //functie ajutatoare

    }
}
