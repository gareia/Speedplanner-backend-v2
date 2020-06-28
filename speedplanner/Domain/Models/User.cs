using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace speedplanner.Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        //public InscriptionProcess InscriptionProcess { get; set; }
        public Profile Profile { get; set; }
        public Role Role { get; set; }
        /*
        public Statistic Statistic { get; set; }*/
    }
}
