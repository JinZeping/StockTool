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
    /// 年度财务报告概要
    /// </summary>
    public class YearFinancialSummary
    {
        public int ID { get; set; }

        [Required, Column(TypeName = "date")]
        public DateTime Date { get; set; }

        /// <summary>
        /// 基本每股收益（元）
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal? PrimaryEarningsPerShare { get; set; }

        /// <summary>
        /// 每股净资产（元）
        /// </summary>
        [Column(TypeName = "decimal(18,2")]
        public decimal? NetAssetsPerShare { get; set; }

        /// <summary>
        /// 每股经营活动现金净流量额（元）
        /// </summary>
        [Column(TypeName = "decimal(18,2")]
        public decimal? OperatingNetCashFlowPerShare { get; set; }

        /// <summary>
        /// 主营业务收入（万元）
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal? MainBusinessIncome { get; set; }

        /// <summary>
        /// 主营业务利润（万元）
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal? MainBusinessProfit { get; set; }

        /// <summary>
        /// 营业利润（万元）
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal? BusinessProfit { get; set; }

        /// <summary>
        /// 投资收益（万元）
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal? InvestmentReturn { get; set; }

        /// <summary>
        /// 营业外收支净额（万元）
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal? NetNonOperatingIncome { get; set; }

        /// <summary>
        /// 利润总额（万元）
        /// </summary>
        [Column(TypeName = "decimal(18,2")]
        public decimal? TotalProfit { get; set; }

        /// <summary>
        /// 净利润（万元）
        /// </summary>
        [Column(TypeName = "decimal(18,2")]
        public decimal? NetProfit { get; set; }

        /// <summary>
        /// 净利润（扣除非经常性损益后）（万元）
        /// </summary>
        [Column(TypeName = "decimal(18,2")]
        public decimal? NetProfitAfterDeductingNonRecurring { get; set; }

        /// <summary>
        /// 经营活动产生的现金流量净额（万元）
        /// </summary>
        [Column(TypeName = "decimal(18,2")]
        public decimal? NetCashFlowFromOperatingActivities { get; set; }

        /// <summary>
        /// 现金及现金等价物净增加额（万元）
        /// </summary>
        [Column(TypeName = "decimal(18,2")]
        public decimal? NetIncreaseInCashAndEquivalents { get; set; }

        /// <summary>
        /// 总资产（万元）
        /// </summary>
        [Column(TypeName = "decimal(18,2")]
        public decimal? TotalAssets { get; set; }

        /// <summary>
        /// 流动资产（万元）
        /// </summary>
        [Column(TypeName = "decimal(18,2")]
        public decimal? CurrentAssets { get; set; }

        /// <summary>
        /// 总负债（万元）
        /// </summary>
        [Column(TypeName = "decimal(18,2")]
        public decimal? TotalLiabilities { get; set; }

        /// <summary>
        /// 流动负债（万元）
        /// </summary>
        [Column(TypeName = "decimal(18,2")]
        public decimal? CurrentLiabilities { get; set; }

        /// <summary>
        /// 所有者权益/股东权益不含少数股东权益（万元）
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal? OwnerEquity { get; set; }

        /// <summary>
        /// 净资产收益率加权（%）
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal? WeightedReturnOnEquity { get; set; }

        [Required]
        public int StockID { get; set; }
        public Stock Stock { get; set; }
    }
}
