using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace RecommandationApp.Models
{
    public class Offre
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string AdresseRecomo { get; set; }

        public string TelRecomo { get; set; }
        public string Image1 { get; set; }

        public byte[] image { get; set; }        

        [ForeignKey("Representant")]
        public String IdRepresentant { get; set; }

        [ForeignKey("CategoryM")]
        public int IdCategoryM { get; set; }


        public virtual Representant Representant { get; set; }

        public virtual CategoryM CategoryM { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public ICollection<Rating> Ratings { get; set; }

        public double ratingValue()
        {
            double val = 0.0;
            foreach (var r in Ratings)
            {
                val = val + r.value;
            }

            return val/ Ratings.Count;
        }

    }
}