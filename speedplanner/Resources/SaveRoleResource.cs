using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace speedplanner.Resources
{
    public class SaveRoleResource
    {
        [Required]
        [MaxLength(1)]
        public int Type { get; set; } //0 admin 1 student
        [Required]
        public int UserId { get; set; }
    }
}
