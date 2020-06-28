using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace speedplanner.Domain.Models
{
    public class Role
    {
        public int Id { get; set; }
        public int Type { get; set; } //0 admin 1 student

        //Relations

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
