using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace EngineFactoryBusinessLogic.ViewModels
{
    public class EngineViewModel
    {
        public int Id { get; set; }
        [DisplayName("Название двигателя")]
        public string EngineName { get; set; }
        [DisplayName("Цена")]
        public decimal Price { get; set; }
        public Dictionary<int, (string, int)> EngineDetails { get; set; }
    }
}
