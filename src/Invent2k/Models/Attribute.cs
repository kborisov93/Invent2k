using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Invent2k.Models
{
    [Table("attributes")]
    public class Attribute
    {
        [MaxLength(10)]
        [Column("item_no")]
        public string ItemNo { get; set; }

        public Item Item { get; set; }

        [MaxLength(50)]
        [Column("serial_no")]
        public string SerialNo { get; set; }
        
        [MinLength(17, ErrorMessage = "Мак адресът съдържа твърде малко символи")]
        [MaxLength(17, ErrorMessage = "Мак адресът съдържа твърде много символи")]
        [Column("mac_address")]
        public string MacAddress { get; set; }

        [MaxLength(50, ErrorMessage = "Мрежовото име съдържа много символи")]
        [Column("network_name")]
        public string NetworkName { get; set; }
    }
}
