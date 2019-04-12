using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BO
{
    public class Category
    {
        public int Id { get; set; }

        [Display(Name = "Titre")]
        public string Title { get; set; }

        public virtual ICollection<Race> Races { get; set; }

        public Category()
        {

        }

    }
}
