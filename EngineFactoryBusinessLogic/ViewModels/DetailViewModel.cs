using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Text;

namespace EngineFactoryBusinessLogic.ViewModels
{
    public class DetailViewModel
    {
        public int Id { get; set; }
        [DisplayName("Название детали")]
        public string DetailName { get; set; }
    }
}
