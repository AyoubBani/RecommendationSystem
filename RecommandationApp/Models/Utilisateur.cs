using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace RecommandationApp.Models
{
    public class Utilisateur
    {
        public int ID { get; set; }
        [Required, StringLength(60, MinimumLength = 3)]
        public string nom { get; set; }
        [Required, StringLength(60, MinimumLength = 3)]
        public string prenom { get; set; }
        [Display(Name = "Date de Naissance"), DataType(DataType.Date)]
        public DateTime dateNaissance { get; set; }        
    }

    public class UtilisateurDBContext : DbContext
    {
        public DbSet<Utilisateur> Utilisateurs { get; set; }
    }

}