using EngineFactoryBusinessLogic.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace EngineFactoryBusinessLogic.ViewModels
{
    public class ReportOrdersViewModel
    {
        public DateTime DateCreate { get; set; }
        public string EngineName { get; set; }
        public int Count { get; set; }
        public decimal Sum { get; set; }
        public OrderStatus Status { get; set; }
    }
}
