using proiectDAW.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proiectDAW.BLL.Interfaces
{
    public interface IMaterialManager
    {
        Material GetMaterial(int id);
        void AddMaterial(Material m);
        void DeleteMaterial (Material m);
        void UpdateMaterial(int id, float price);
    }
}
