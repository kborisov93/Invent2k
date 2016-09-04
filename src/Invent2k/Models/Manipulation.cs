using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Invent2k.Models
{
    [Table("manipulations")]
    public class Manipulation
    {
        private string user;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public long Id { get; set; }

        [Required]
        [Column("date")]
        public DateTime Date { get; set; }

        [Required]
        [MaxLength(10)]
        [Column("item_no")]
        public string ItemNo { get; set; }

        public virtual Item Item { get; set; }

        [Required]
        [Column("unit_of_measure")]
        public UnitOfMeasure UnitOfMeasure { get; set; }

        [Required]
        [Column("qty")]
        public decimal Quantity { get; set; }

        [MaxLength(50)]
        [Column("serial_no")]
        public string SerialNo { get; set; }

        [Column("lot_no")]
        [MaxLength(50)]
        public string LotNo { get; set; }

        [MaxLength(10)]
        [Column("reason_code")]
        public string ReasonCode { get; set; }

        public virtual Reason Reason { get; set; }

        [MaxLength(10)]
        [Column("location_code")]
        public string LocationCode { get; set; }

        public virtual Location Location { get; set; }

        public virtual Attribute Attribute { get; set; }

        [Required]
        [MaxLength(300)]
        [Column("user")]
        public string User
        {
            get { return user?.ToUpper(); }
            set { user = value?.ToUpper(); }
        }

    }
}
