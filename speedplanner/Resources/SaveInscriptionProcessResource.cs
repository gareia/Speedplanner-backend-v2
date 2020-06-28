using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace speedplanner.Resources
{
    public class SaveInscriptionProcessResource
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public int PeriodId { get; set; }
    }
}
