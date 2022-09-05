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
    public class IdeaMaterialManager : IIdeaMaterialManager
    {

        private readonly IIdeaMaterialRepository _ideamRepository;
        public IdeaMaterialManager(IIdeaMaterialRepository ideamRepository)
        {
            _ideamRepository = ideamRepository;
        }
        public void AddIdeaM(IdeaMaterial im)
        {
            _ideamRepository.Create(im);
        }

        public void DeleteIdeaM(IdeaMaterial im)
        {
            _ideamRepository.Delete(im);
        }

        public List<string> GetGroupBy()
        {
            var im= _ideamRepository.GetAll();
            var ideas = im
              .GroupBy(x => x.IdeaId)
              .Select(x => new { IdeaId = x.Key, NoMaterials = x.Count()}).ToList();
            var list_ideas = new List<string>(); //lista de mesaje

            //iau fiecare obiect din ideas si il pun in lista mea 
            foreach (var idea in ideas)
            {
                // $= string interpolat care ma ajuta sa inserez si variabile
                list_ideas.Add($"Idea Id: {idea.IdeaId}, NoMaterials: {idea.NoMaterials}");
            }

            return list_ideas;
        }

        public void UpdateIdeaM(IdeaMaterial im, int new_number)
        {
            _ideamRepository.Update(im, new_number);   
        }
    }
}
