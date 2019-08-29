using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HackATL_EEVM_backend.Models.Entities
{
    public class AgendaEvents
    {
        public string Id { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public string Time { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public string Day { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
