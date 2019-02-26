using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecommandationApp.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public String Text { get; set; }
        public Client Client { get; set; }
        public int Offre { get; set; }
    }
}