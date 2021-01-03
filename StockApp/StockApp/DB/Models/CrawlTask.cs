﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockApp.DB.Models
{
    public class CrawlTask
    {
        public int ID { get; set; }
        [Required]
        public CrawlTaskType Type { get; set; }
        [Required]
        public CrawlTaskState State { get; set; }

        [Required]
        public int StockID { get; set; }
        public Stock Stock { get; set; }
    }

    public enum CrawlTaskType : int
    {
        CrawlDayTradeRecord = 0
    }

    public enum CrawlTaskState : int
    {
        Created = 0,
        Doing = 1,
        Done = 2
    }
}