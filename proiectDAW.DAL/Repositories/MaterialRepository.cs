using proiectDAW.DAL.Entities;
using proiectDAW.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proiectDAW.DAL.Repositories
{
    public class MaterialRepository : IMaterialRepository
    {
        //avem un serviciu aici

        private readonly proiectDbContext _context;
        public MaterialRepository(proiectDbContext context)
        {
            _context = context;
        }

        public async Task Create(Material m)
        {
            await _context.Materials.AddAsync(m);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Material m)
        {
            _context.Materials.Remove(m);
            await _context.SaveChangesAsync();
        }

        public IQueryable<Material> GetAll()
        {
            var materials = _context.Materials;
            return materials;
        }


        public Material GetById(int id)
        {
            var mat = _context.Materials.Find(id);
            return mat;
        }

        public async Task Update(int id, float price)
        {
            var mat = GetById(id);
            mat.Price = price;
            await _context.SaveChangesAsync();
        }
        public async Task<IQueryable<Material>> GetAllQuery()
        {
            //folosesc aceasta metoda la GetAll
            var q = _context.Materials.AsQueryable(); //creeaza un query instant
            return q;

        }
    }
}
