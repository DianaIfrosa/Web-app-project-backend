using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proiectDAW.DAL.Entities
{
    public class Material
    {
        public int Id { get; set; }
        [MaxLength(100), Required]
        public string Name { get; set; }
        [Required]
        public float Price { get; set; }
        public string BuyFrom { get; set; }

        //many to many cu diyidea
        public virtual ICollection<IdeaMaterial> MaterialsDIYIdeas { get; set; }
      

    }
}
