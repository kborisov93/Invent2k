using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Invent2k.Models
{
    [Table("tech_specs")]
    public class TechSpec
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [MaxLength(10)]
        [Column("item_no")]
        public string ItemNo { get; set; }

        public virtual Item Item { get; set; }

        [Required]
        [Column("parameter")]
        [MinLength(1, ErrorMessage = "Параметърът е твърде къс."), MaxLength(20, ErrorMessage = "Параметърът е твърде дълъг.")]
        public string Parameter { get; set; }

        [Required]
        [Column("value")]
        [MinLength(1, ErrorMessage = "Параметърът е твърде къс."), MaxLength(20, ErrorMessage = "Параметърът е твърде дълъг.")]
        public string Value { get; set; }

    }
}
