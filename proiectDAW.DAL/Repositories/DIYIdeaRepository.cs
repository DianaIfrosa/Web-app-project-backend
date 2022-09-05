using Microsoft.EntityFrameworkCore;
using proiectDAW.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proiectDAW.DAL.Repositories
{
    public class DIYIdeaRepository : IDIYIdeaRepository
    {
        //avem un serviciu aici

        private readonly proiectDbContext _context;
        public DIYIdeaRepository(proiectDbContext context)
        {
            _context = context;
        }

        public async Task Create(DIYIdea idea)
        {
            await _context.DIYIdeas.AddAsync(idea);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(DIYIdea idea)
        {
             _context.DIYIdeas.Remove(idea);
            await _context.SaveChangesAsync();
        }

        public IQueryable<DIYIdea> GetAll()
        {
            var ideas = _context.DIYIdeas;
            return ideas;
        }

        public DIYIdea GetById(int id)
        {
            var idea = _context.DIYIdeas.Find(id);
            return idea;
        }

        public async Task Update(DIYIdea idea)
        {
            _context.DIYIdeas.Update(idea);
           await _context.SaveChangesAsync();
        }
        public async Task<IQueryable<DIYIdea>> GetAllQuery()
        {
            //folosesc aceasta metoda la GetAll
            var q = _context.DIYIdeas.AsQueryable(); //creeaza un query instant
            return q;

        }
    }
}
