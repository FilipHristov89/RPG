using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Data.Models
{
    public class Heroes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string CharacterClass { get; set; } = null!;

        [Required]
        public int CharacterStrength { get; set; }

        [Required]
        public int CharacterAgility { get; set; }

        [Required]
        public int CharacterIntelligence {get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
