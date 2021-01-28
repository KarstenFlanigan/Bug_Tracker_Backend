using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bug_Tracker_Backend.Model
{
    public class Developer
    {
        [Key]
        public int DeveloperID { get; set; }
        public string DeveloperFirstName { get; set; }

        public string DeveloperLastName { get; set; }

        public string DeveloperPhone { get; set; }

        public string DeveloperEmail { get; set; }

        //Many Relationship
        public ICollection<Ticket> Tickets { get; set; }

        //Many Relationship
        public ICollection<Application> Applications { get; set; }
    }
}
