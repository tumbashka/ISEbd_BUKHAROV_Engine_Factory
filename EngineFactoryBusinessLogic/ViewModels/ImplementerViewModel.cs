using EngineFactoryBusinessLogic.Attributes;
using EngineFactoryBusinessLogic.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace EngineFactoryBusinessLogic.ViewModels
{
    public class ImplementerViewModel : BaseViewModel
    {
        [Column(title: "ФИО исполнителя", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string ImplementerFIO { get; set; }
        [Column(title: "Время на заказ", width: 100)]
        public int WorkingTime { get; set; }
        public override List<string> Properties() => new List<string>
        {
            "Id",
            "ImplementerFIO",
            "WorkingTime",
            "PauseTime"
        };
    }
}
