using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace speedplanner.Resources
{
    public class RoleResource
    {
        public int Id { get; set; }
        public int Type { get; set; } //0 admin 1 student
        public int UserId { get; set; }
    }
}
