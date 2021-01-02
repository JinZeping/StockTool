using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockApp.DB.Models
{
    public class Exchange
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string NameAbbr { get; set; }

        public List<Stock> Stocks { get; set; }
    }
}
