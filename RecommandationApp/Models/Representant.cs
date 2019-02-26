using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RecommandationApp.Models
{
    public class Representant
    {        
        [ForeignKey("ApplicationUser")]
        public String Id { get; set; }
       
        [StringLength(25)]
        public String nom { get; set; }

        [StringLength(25)]
        public String prenom { get; set; }

//        [Required(ErrorMessage = "Veuillez entrer le nom de l'entreprise.")]
        [StringLength(255)]
        public String entreprise { get; set; }

        [Display(Name = "Adresse de l'entreprise")]
        [StringLength(500)]
//        [Required(ErrorMessage = "Veuillez entrer l'adresse de l'entreprise.")]
        public String adresse_entreprise { get; set; }


        public virtual ApplicationUser ApplicationUser { get; set; }

        public ICollection<Offre> Offres { get; set; }

    }
}