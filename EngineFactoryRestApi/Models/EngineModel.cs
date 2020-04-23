using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EngineFactoryRestApi.Models
{
    public class EngineModel
    {
        public int Id { get; set; }
        public string EngineName { get; set; }
        public decimal Price { get; set; }
    }
}
