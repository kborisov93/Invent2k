using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Invent2k.Models
{
    [Table("items")]
    public class Item
    {
        private string no;

        [Key]
        [MinLength(3, ErrorMessage = "№ е твърде къс.")]
        [MaxLength(10, ErrorMessage = "№ е твърде дълъг.")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("no")]
        public string No
        {
            get { return no?.ToUpper(); }
            set { no = value?.ToUpper(); }
        }

        [MaxLength(50, ErrorMessage = "Описанието е твърде дълго.")]
        [Column("descr")]
        public string Description { get; set; }

        [Column("item_category_code")]
        [MinLength(3, ErrorMessage = "Кодът е твърде къс.")]
        [MaxLength(10, ErrorMessage = "Кодът е твърде дълъг.")]
        public string ItemCategoryCode { get; set; }

        public ItemCategory ItemCategory { get; set; }

        public ICollection<TechSpec> TechSpecs { get; set; } = new List<TechSpec>();

        [Required]
        [Column("track_location")]
        public bool TrackLocation { get; set; } = false;

        [Required]
        [Column("track_serial")]
        public bool TrackSerial { get; set; } = false;

        [Required]
        [Column("track_lot")]
        public bool TrackLot { get; set; } = false;
    }
}
