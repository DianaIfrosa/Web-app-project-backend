using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proiectDAW.DAL.Entities
{
    public class IdeaMaterial
    {
        //tabel asociativ

        //one to many cu DIYIdea
        public int IdeaId { get; set; }
        public virtual DIYIdea DIYIdea { get; set; }

        //one to many cu Material
        public int MaterialId { get; set; }
        public virtual Material Material { get; set; }

        [Required]
        public int NoPieces { get; set; }
       
    }
   
}
