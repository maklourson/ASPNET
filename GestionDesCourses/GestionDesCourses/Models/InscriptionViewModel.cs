using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionDesCourses.Models
{
    public class InscriptionViewModel
    {
        public Inscription Inscription { get; set; }

        public List<Inscription> lesInscriptionsVM;

        public List<Race> Races { get; set; } = new List<Race>();

        public int RaceId { get; set; }

        public string IdentityModelId { get; set; }

        public float Amount { get; set; }

        public int TypeInscriptionId { get; set; }

        public virtual TypeInscription TypeInscription { get; set; }
        public virtual Race Race { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

    }
}