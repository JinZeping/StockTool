using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockApp.DB.Models
{
    /// <summary>
    /// 每月交易数据
    /// </summary>
    public class MonthTradeRecord
    {
        public int ID { get; set; }

        [Required, Column(TypeName = "date")]
        public DateTime Date { get; set; }

        /// <summary>
        /// 开盘价
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal? Begin { get; set; }

        /// <summary>
        /// 收盘价
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal? End { get; set; }

        /// <summary>
        /// 最高价
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal? Max { get; set; }

        /// <summary>
        /// 最低价
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal? Min { get; set; }

        /// <summary>
        /// 涨跌额
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal? Change { get; set; }

        /// <summary>
        /// 涨跌幅（%）
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal? ChangeRate { get; set; }

        /// <summary>
        /// 成交量（手）
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal? TradeHand { get; set; }

        /// <summary>
        /// 成交金额（万元）
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal? TradeAmount { get; set; }

        /// <summary>
        /// 振幅（）%
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal? Amplitude { get; set; }

        /// <summary>
        /// 换手率（）%
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal? TurnoverRate { get; set; }

        [Required]
        public int StockID { get; set; }
        public Stock Stock { get; set; }
    }
}
