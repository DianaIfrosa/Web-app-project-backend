using proiectDAW.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proiectDAW.BLL.Interfaces
{
    public interface IIdeaMaterialManager
    {
        void AddIdeaM(IdeaMaterial im);
        void DeleteIdeaM(IdeaMaterial im);
        void UpdateIdeaM(IdeaMaterial im, int new_number);
        List<string> GetGroupBy();
    }
}
