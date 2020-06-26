using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace speedplanner.Resources
{
    public class SaveEducationProviderResource
    {
        [Required]
        [MaxLength(40)]
        [Key]
        public string Name { get; set; }

        [Required]
        public int NumberOfCareers { get; set; }
    }
}
