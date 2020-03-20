using System;
using System.Collections.Generic;
using System.Text;

namespace EngineFactoryBusinessLogic.ViewModels
{
    public class ReportEngineDetailViewModel
    {
        public string DetailName { get; set; }
        public int TotalCount { get; set; }
        public List<Tuple<string, int>> Engines { get; set; }
    }
}
