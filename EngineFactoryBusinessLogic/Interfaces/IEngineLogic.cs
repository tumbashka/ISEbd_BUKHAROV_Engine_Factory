using EngineFactoryBusinessLogic.BindingModels;
using EngineFactoryBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace EngineFactoryBusinessLogic.Interfaces
{
    public interface IEngineLogic
    {
        List<EngineViewModel> Read(EngineBindingModel model);
        void CreateOrUpdate(EngineBindingModel model);
        void Delete(EngineBindingModel model);

    }
}
