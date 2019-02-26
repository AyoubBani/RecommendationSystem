using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RecommandationApp.Models
{
    public class Client
    {
        [ForeignKey("ApplicationUser")]
        public String Id { get; set; }

//        [Required]
        [StringLength(25)]
        public String nom { get; set; }

//        [Required]
        [StringLength(25)]
        public String prenom { get; set; }

//        [Required]
        [StringLength(10)]
        public String sex { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "Date de Naissance")]
        public DateTime dateNaissance { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        public String profileImage { get; set; }

//        public ICollection<Comment> Comments { get; set; }
    }
}