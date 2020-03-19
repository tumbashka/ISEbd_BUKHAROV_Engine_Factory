using System;
using System.Collections.Generic;
using System.Text;

namespace EngineFactoryBusinessLogic.BindingModels
{
    public class EngineBindingModel
    {
        public int? Id { get; set; }
        public string EngineName { get; set; }
        public decimal Price { get; set; }
        public Dictionary<int, (string, int)> EngineDetails { get; set; }
    }
}
