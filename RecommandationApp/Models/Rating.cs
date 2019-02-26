using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RecommandationApp.Models
{
    public class Rating
    {        
        public int Id { get; set; }
        public double value { get; set; }
        public Offre Offre { get; set; }
        public Client Client { get; set; }
    }
}