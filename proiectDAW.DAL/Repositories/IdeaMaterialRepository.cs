using proiectDAW.DAL.Entities;
using proiectDAW.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proiectDAW.DAL.Repositories
{
    public class IdeaMaterialRepository : IIdeaMaterialRepository
    {
        //avem un serviciu aici

        private readonly proiectDbContext _context;
        public IdeaMaterialRepository(proiectDbContext context)
        {
            _context = context;
        }
        public async Task Create(IdeaMaterial im)
        {
            await _context.MaterialsDIYIdeas.AddAsync(im);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(IdeaMaterial im)
        {
            _context.MaterialsDIYIdeas.Remove(im);
            await _context.SaveChangesAsync();
        }

        public IQueryable<IdeaMaterial> GetAll()
        {
            var idea_material = _context.MaterialsDIYIdeas;
            return idea_material;
        }

        public async Task<IQueryable<IdeaMaterial>> GetAllQuery()
        {
            //folosesc aceasta metoda la GetAll
            var q = _context.MaterialsDIYIdeas.AsQueryable(); //creeaza un query instant
            return q;
        }

        public async Task Update(IdeaMaterial im, int new_number)
        {
            im.NoPieces = new_number;
            await _context.SaveChangesAsync();
        }
    }
}
