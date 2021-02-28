using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockApp.DB.Models
{
    public class YearChangeRateSummary
    {
        public int ID { get; set; }

        [Required, Column(TypeName = "date")]
        public DateTime Date { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal LowLimit { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal HighLimit { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Step { get; set; }

        [Required]
        public int Count { get; set; }

        [Required, Column(TypeName = "decimal(10,4)")]
        public decimal Percent { get; set; }
    }
}
