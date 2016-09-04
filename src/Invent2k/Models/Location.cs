using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Invent2k.Models
{
    [Table("locations")]
    public class Location
    {
        private string code;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [MinLength(2, ErrorMessage = "Кодът е твърде кратко."), MaxLength(10, ErrorMessage = "Кодът е твърде дълъг.")]
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
