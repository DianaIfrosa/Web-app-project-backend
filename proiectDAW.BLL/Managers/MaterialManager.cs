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
    public class MaterialManager : IMaterialManager
    {
        private readonly IMaterialRepository _matRepository;
        public MaterialManager(IMaterialRepository matRepository)
        {
            _matRepository = matRepository;
        }

        public void AddMaterial(Material m)
        {
            _matRepository.Create(m);
        }

        public void DeleteMaterial(Material m)
        {
            _matRepository.Delete(m);
        }

        public Material GetMaterial(int id)
        {
            var mat= _matRepository.GetAll().FirstOrDefault(x => x.Id == id);
            return mat;
        }

        public void UpdateMaterial(int id, float price)
        {
            _matRepository.Update(id, price);
        }
    }
}
