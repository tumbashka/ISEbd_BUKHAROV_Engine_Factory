using System;
using System.Collections.Generic;
using System.Text;

namespace EngineFactoryBusinessLogic.BindingModels
{
    public class CreateOrderBindingModel
    {
        public int EngineId { get; set; }
        public int Count { get; set; }
        public decimal Sum { get; set; }

    }
}
