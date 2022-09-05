using proiectDAW.DAL.Entities;
using proiectDAW.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proiectDAW.DAL.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        //avem un serviciu aici

        private readonly proiectDbContext _context;
        public CategoryRepository(proiectDbContext context)
        {
            _context = context;
        }

        public async Task Create(Category categ)
        {
            await _context.Categories.AddAsync(categ);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Category categ)
        {
            _context.Categories.Remove(categ);
            await _context.SaveChangesAsync();
        }

        public IQueryable<Category> GetAll()
        {
            var categories = _context.Categories;
            return categories;
        }

        public Category GetById(int id)
        {
            var categ = _context.Categories.Find(id);
            return categ;
        }

        public async Task Update(Category categ)
        {
            _context.Categories.Update(categ);
            await _context.SaveChangesAsync();
        }
        public async Task<IQueryable<Category>> GetAllQuery()
        {
            //folosesc aceasta metoda la GetAll
            var q =  _context.Categories.AsQueryable(); //creeaza un query instant
            return q;

        }

        public List<string> CategoriesJoin(IQueryable<Category> categs)
        {
            var join = categs.Join(_context.DIYIdeas, c => c.Id, i => i.Category.Id, (c, i) =>
            new { CategName = c.Name, IdeaName = i.Name, IdeaDescription = i.Description });
            var list_c = new List<string>(); //lista de mesaje
            foreach (var c in join)
            {
                // $= string interpolat care ma ajuta sa inserez si variabile
                list_c.Add($"CategName: {c.CategName}, IdeaName: {c.IdeaName}, IdeaDescription:{c.IdeaDescription}");
            }

            return list_c;
        }
    }
}
