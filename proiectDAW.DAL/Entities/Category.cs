using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proiectDAW.DAL.Entities
{
    public class Category
    {
        public int Id { get; set; }

        [MaxLength(50), Required]
        public string Name { get; set; }

        [Range(1,10, ErrorMessage ="Value for {0} must be between {1} and {2}")]
        public int PopularityScore { get; set; }

        //one to many cu diyidea
        public  virtual ICollection<DIYIdea> DIYIdeas { get; set; }

    }
}
