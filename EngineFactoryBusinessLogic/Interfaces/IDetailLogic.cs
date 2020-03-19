using EngineFactoryBusinessLogic.BindingModels;
using EngineFactoryBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace EngineFactoryBusinessLogic.Interfaces
{
    public interface IDetailLogic
    {
        List<DetailViewModel> Read(DetailBindingModel model);
        void CreateOrUpdate(DetailBindingModel model);
        void Delete(DetailBindingModel model);
    }
}
