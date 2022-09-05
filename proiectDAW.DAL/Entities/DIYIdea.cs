using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proiectDAW.DAL.Entities
{
    public class DIYIdea
    {
        public int Id {get; set;} //pk
        [MaxLength(200), Required]
        public string Name { get; set;}

        [Required]
        public string Description { get; set;}

        [Required]
        public int Time { get; set; }

        // 1 to many cu category
        public virtual Category Category { get; set; }

        //1 to many cu IdeaMaterial (din many to many)
        public virtual ICollection<IdeaMaterial> MaterialsDIYIdeas { get; set; }

        //1 to 1 cu presentationvideo
        public int PresentationVideoId { get; set; }
        public virtual PresentationVideo PresentationVideo { get; set; }

    }
}
