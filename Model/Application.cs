using Bug_Tracker_Backend.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bug_Tracker_Backend
{
    public class Application
    {
        [Key]
        public int ApplicationID { get; set; }
        public string ApplicationName { get; set; }
        
        //Many Relationship
        public ICollection<Ticket> Tickets { get; set; }

        //Many Relationship
        public ICollection<Developer> Developers { get; set; }
        
    }
}
