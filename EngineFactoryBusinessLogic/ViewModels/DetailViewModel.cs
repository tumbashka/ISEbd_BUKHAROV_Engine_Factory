using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Text;
using EngineFactoryBusinessLogic.Attributes;
using EngineFactoryBusinessLogic.Enums;

namespace EngineFactoryBusinessLogic.ViewModels
{
    public class DetailViewModel : BaseViewModel
    {
        [Column(title: "Название детали", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string DetailName { get; set; }
        public override List<string> Properties() => new List<string>
        {
            "Id",
            "DetailName"
        };
    }
}
