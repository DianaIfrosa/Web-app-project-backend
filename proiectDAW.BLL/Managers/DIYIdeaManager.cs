using Microsoft.EntityFrameworkCore;
using proiectDAW.BLL.Interfaces;
using proiectDAW.DAL;
using proiectDAW.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proiectDAW.BLL.Managers
{
    public class DIYIdeaManager : IDIYIdeaManager
    {
        private readonly IDIYIdeaRepository _ideaRepository;
        public DIYIdeaManager(IDIYIdeaRepository ideaRepository)
        {
            _ideaRepository = ideaRepository;
        }

        public void AddDIYIdea(DIYIdea idea)
        {
            _ideaRepository.Create(idea);
        }

        public void DeleteIdea(DIYIdea idea)
        {
            _ideaRepository.Delete(idea);
        }

        public DIYIdea GetIdea(int id)
        {
            var idea =  _ideaRepository.GetAll().FirstOrDefault(x => x.Id == id);
            return idea;
        }

        public List<string> GetPopularIdeas()
        {
            var ideas = _ideaRepository.GetAll()
                 .Include(di => di.Category)
                 .Where(di => di.Category.PopularityScore>=8)
                 .OrderByDescending(di => di.Category.PopularityScore)
                 .Select(di => di.Name)
                 .ToList(); //aduce sql query in memoria aplicatiei

            return ideas;
        }

        public async Task<List<DIYIdea>> ShowDIYIdea()
        {
            var ideas = _ideaRepository.GetAll();
            var list_ideas = new List<DIYIdea>(); //lista de mesaje
            //iau fiecare obiect din ideas si il pun in lista mea 
            foreach (var idea in ideas)
                list_ideas.Add(idea);
            

            return list_ideas; 
        }

        public void UpdateIdea(int id, DIYIdea idea)
        {
            var ideaModified = _ideaRepository.GetById(id);
            ideaModified = idea;
        }
    }
}
