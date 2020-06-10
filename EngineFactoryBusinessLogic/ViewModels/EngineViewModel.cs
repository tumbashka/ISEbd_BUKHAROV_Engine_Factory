using EngineFactoryBusinessLogic.Attributes;
using EngineFactoryBusinessLogic.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace EngineFactoryBusinessLogic.ViewModels
{
    [DataContract]
    public class EngineViewModel : BaseViewModel
    {
        [Column(title: "Название двигателя", gridViewAutoSize: GridViewAutoSize.Fill)]
        [DataMember]
        public string EngineName { get; set; }
        [Column(title: "Цена", width: 50)]
        [DataMember]
        public decimal Price { get; set; }
        [DataMember]
        public Dictionary<int, (string, int)> EngineDetails { get; set; }
        public override List<string> Properties() => new List<string>
        {
            "Id",
            "EngineName",
            "Price"
        };
    }
}
