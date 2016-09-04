using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Invent2k.Models
{
    [Table("item_categories")]
    public class ItemCategory
    {
        private string code;

        [Key]
        [MinLength(3, ErrorMessage = "Кодът е твърде къс.")]
        [MaxLength(10, ErrorMessage = "Кодът е твърде дълъг.")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("code")]
        public string Code
        {
            get { return code?.ToUpper(); }
            set { code = value?.ToUpper(); }
        }

        [MaxLength(50, ErrorMessage = "Описанието е твърде дълго.")]
        [Column("descr")]
        public string Description { get; set; }
    }
}
