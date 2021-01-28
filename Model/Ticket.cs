using Bug_Tracker_Backend.Model;
using System;
using System.ComponentModel.DataAnnotations;

namespace Bug_Tracker_Backend
{
    public class Ticket
    {
        [Key]
        public int TicketID { get; set; }

        public string TicketName { get; set; }

        public string TicketDescription { get; set; }

        public string Severity { get; set; }
        public DateTime DateCreated { get; set; }

        public DateTime DateDue { get; set; }

        //1 to Relationship with Application
        public int ApplicationID { get; set; }
        public Application Application { get; set; }

        //1 to Relationship with Developer
        public int DeveloperID { get; set; }
        public Developer Developer { get; set; }
      
        public string UserName { get; set; }
    }
}
