using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockApp.DB.Models
{
    public class YearFinancialBrief
    {
        public int ID { get; set; }

        [Required, Column(TypeName = "date")]
        public DateTime Date { get; set; }

        #region 利润表摘要

        /// <summary>
        /// 营业收入（万元）
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal? OperatingIncome { get; set; }

        /// <summary>
        /// 营业成本（万元）
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal? OperatingCosts { get; set; }

        /// <summary>
        /// 营业利润（万元）
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal? OperatingProfit { get; set; }

        /// <summary>
        /// 利润总额（万元）
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal? TotalProfit { get; set; }

        /// <summary>
        /// 所得税费用（万元）
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal? IncomeTax { get; set; }

        /// <summary>
        /// 净利润（万元）
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal? NetProfit { get; set; }

        /// <summary>
        /// 基本每股收益
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal? BasicEarningPerShare { get; set; }

        #endregion

        #region 资产负债表摘要

        /// <summary>
        /// 货币资金（万元）
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal? Money { get; set; }

        /// <summary>
        /// 应收账款（万元）
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal? Receivables { get; set; }

        /// <summary>
        /// 存货（万元）
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal? Inventory { get; set; }

        /// <summary>
        /// 流动资产合计（万元）
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal? TotalCurrentAssets { get; set; }

        /// <summary>
        /// 固定资产净额（万元）
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal? NetFixedAssets { get; set; }

        /// <summary>
        /// 资产总计（万元）
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal? TotalAssets { get; set; }

        /// <summary>
        /// 流动负债合计（万元）
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal? TotalCurrentLiabilities { get; set; }
        /// <summary>
        /// 非流动负债合计（万元）
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal? TotalNonCurrentLiabilities { get; set; }

        /// <summary>
        /// 负债合计（万元）
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal? TotalLiabilities { get; set; }

        /// <summary>
        /// 所有者权益（股东权益）合计（万元）
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal? TotalOwnerEquity { get; set; }

        #endregion

        #region 现金流量表摘要

        /// <summary>
        /// 期初现金及现金等价物余额（万元）
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal? BeginBalanceOfCashAndCashEquivalents { get; set; }

        /// <summary>
        /// 期末现金及现金等价物余额（万元）
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal? EndBalanceOfCashAndCashEquivalents { get; set; }

        /// <summary>
        /// 经营活动产生的现金流量净额（万元）
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal? NetCashFlowFromOperating { get; set; }

        /// <summary>
        /// 投资活动产生的现金流量净额（万元）
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal? NetCashFlowFromInvestment { get; set; }

        /// <summary>
        /// 筹资活动产生的现金流量净额（万元）
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal? NetCashFlowFromFinancing { get; set; }

        /// <summary>
        /// 现金及现金等价物净增加额（万元）
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal? NetIncreaseInCashAndCashEquivalents { get; set; }

        #endregion

        [Required]
        public int StockID { get; set; }
        public Stock Stock { get; set; }
    }
}
