using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bizland.core.Models
{
    public class TeamMember:BaseEntity
    {
        [Required]
        [StringLength(20)]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        public string Profession { get; set; }
        [StringLength(100)]
        public string? ImageUrl { get; set; }

        public string InstaUrl { get; set; }
        public string FbUrl { get; set; }
        public string TwitterUrl { get; set; }
        public string LinkedinUrl { get; set; }
        [NotMapped] 
        public IFormFile? ImageFile { get; set; }
    }
}
