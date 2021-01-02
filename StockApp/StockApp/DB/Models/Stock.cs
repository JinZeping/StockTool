using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockApp.DB.Models
{
    public class Stock
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Number { get; set; }
        [Required]
        public string Board { get; set; }
        [Required, Column(TypeName = "date")]
        public DateTime ListingDate { get; set; }

        [Required]
        public int ExchangeID { get; set; }
        public Exchange Exchange { get; set; }

        public List<DayTradeRecord> DayTradeRecords { get; set; }
    }
}
