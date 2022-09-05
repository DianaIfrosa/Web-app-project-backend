using proiectDAW.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proiectDAW.BLL.Interfaces
{
    public interface IDIYIdeaManager
    {
        Task<List<DIYIdea>> ShowDIYIdea();
        DIYIdea GetIdea(int id);
        List<string> GetPopularIdeas();
        void AddDIYIdea(DIYIdea idea);
        void DeleteIdea(DIYIdea idea);
        void UpdateIdea(int id, DIYIdea idea);
    }
}
