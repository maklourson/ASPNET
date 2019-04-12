using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Inscription
    {
        public Inscription()
        {

        }

        public int Id { get; set; } // l'id de l'inscription
        [Display(Name = "prix")]
        public float Amount { get; set; } // ??? 

        public string IdentityModelId { get; set; } // l'id de la personne qui s'inscrit

        public int RaceId { get; set; } // l'id de la course  laquelle la personne s'inscrit

        public string RaceTitle { get; set; } // à supprimer car on retrouve cette info avec l'id de la course (RaceId)
        public DateTime RaceStart { get; set; } // à supprimer car on retrouve cette info avec l'id de la course (RaceId)
        public DateTime RaceEnd { get; set; } // à supprimer car on retrouve cette info avec l'id de la course (RaceId)

        public int TypeInscriptionId { get; set; } // // l'id correspondant au type d'inscription (la personne s'inscrit en tant que compétiteur ou organisateur)
        
    }
}
