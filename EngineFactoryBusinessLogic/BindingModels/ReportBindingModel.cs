using System;
using System.Collections.Generic;
using System.Text;

namespace EngineFactoryBusinessLogic.BindingModels
{
    public class ReportBindingModel
    {
        public string FileName { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
    }
}
