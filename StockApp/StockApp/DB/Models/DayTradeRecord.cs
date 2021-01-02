using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockApp.DB.Models
{
    public class DayTradeRecord
    {
        public int ID { get; set; }
        [Required, Column(TypeName = "date")]
        public DateTime Date { get; set; }
        [Required, Column(TypeName = "decimal(10,2)")]
        public decimal Begin { get; set; }
        [Required, Column(TypeName = "decimal(10,2)")]
        public decimal End { get; set; }
        [Required, Column(TypeName = "decimal(10,2)")]
        public decimal Max { get; set; }
        [Required, Column(TypeName = "decimal(10,2)")]
        public decimal Min { get; set; }
        [Required, Column(TypeName = "decimal(10,2)")]
        public decimal Change{ get; set; }
        [Required, Column(TypeName = "decimal(10,2)")]
        public decimal ChangeRate { get; set; }
        [Required]
        public int TradeHand { get; set; }
        [Required]
        public int TradeAmount { get; set; }
        [Required, Column(TypeName = "decimal(10,2)")]
        public decimal Amplitude { get; set; }
        [Required, Column(TypeName = "decimal(10,2)")]
        public decimal TurnoverRate { get; set; }

        [Required]
        public int StockID { get; set; }
        public Stock Stock { get; set; }
    }
}
