using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RecommandationApp.Models
{
    public class CategoryM
    {
        [Key]
        public int Id { get; set; }

        public String Category { get; set; }

        public ICollection<Offre> Offres { get; set; }
    }
}