using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BO
{
    public class TypeInscription
    {
        public int Id { get; set; } // l'id du type d'inscription

        public string Description { get; set; } // description courte du type d'inscription (ex : "competiteur", "organisateur")
    }
}
