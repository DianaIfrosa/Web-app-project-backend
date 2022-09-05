using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proiectDAW.DAL.Entities
{
    public class PresentationVideo
    {
        public int Id { get; set; }

        [Required]
        public string Link { get; set; }

        [Required]
        public string Views { get; set; }

        //one to one cu diyidea
        //'virtual' ca sa pot accesa cealalta tabela in mod direct, fara join
        public virtual DIYIdea DIYIdea { get; set; }
    }
}
