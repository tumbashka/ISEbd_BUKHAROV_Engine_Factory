using EngineFactoryBusinessLogic.BindingModels;
using EngineFactoryBusinessLogic.Interfaces;
using EngineFactoryBusinessLogic.ViewModels;
using EngineFactoryListImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineFactoryListImplement.Implements
{
    public class EngineLogic : IEngineLogic
    {
        private readonly DataListSingleton source;
        public EngineLogic()
        {
            source = DataListSingleton.GetInstance();
        }
        public void CreateOrUpdate(EngineBindingModel model)
        {
            Engine tempEngine = model.Id.HasValue ? null : new Engine { Id = 1 };
            foreach (var engine in source.Engines)
            {
                if (engine.EngineName == model.EngineName && engine.Id != model.Id)
                {
                    throw new Exception("Уже есть двигатель с таким названием");
                }
                if (!model.Id.HasValue && engine.Id >= tempEngine.Id)
                {
                    tempEngine.Id = engine.Id + 1;
                }
                else if (model.Id.HasValue && engine.Id == model.Id)
                {
                    tempEngine = engine;
                }
            }
            if (model.Id.HasValue)
            {
                if (tempEngine == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, tempEngine);
            }
            else
            {
                source.Engines.Add(CreateModel(model, tempEngine));
            }
        }
        public void Delete(EngineBindingModel model)
        {
            // удаляем записи по компонентам при удалении изделия
            for (int i = 0; i < source.EngineDetails.Count; ++i)
            {
                if (source.EngineDetails[i].EngineId == model.Id)
                {
                    source.EngineDetails.RemoveAt(i--);
                }
            }
            for (int i = 0; i < source.Engines.Count; ++i)
            {
                if (source.Engines[i].Id == model.Id)
                {
                    source.Engines.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
        private Engine CreateModel(EngineBindingModel model, Engine engine)
        {
            engine.EngineName = model.EngineName;
            engine.Price = model.Price;
            //обновляем существуюущие компоненты и ищем максимальный идентификатор
            int maxPCId = 0;
            for (int i = 0; i < source.EngineDetails.Count; ++i)
            {
                if (source.EngineDetails[i].Id > maxPCId)
                {
                    maxPCId = source.EngineDetails[i].Id;
                }
                if (source.EngineDetails[i].EngineId == engine.Id)
                {
                    // если в модели пришла запись компонента с таким id
                    if
                    (model.EngineDetails.ContainsKey(source.EngineDetails[i].DetailId))
                    {
                        // обновляем количество
                        source.EngineDetails[i].Count =
                        model.EngineDetails[source.EngineDetails[i].DetailId].Item2;
                        // из модели убираем эту запись, чтобы остались только не  просмотренные
                        model.EngineDetails.Remove(source.EngineDetails[i].DetailId);
                    }
                    else
                    {
                        source.EngineDetails.RemoveAt(i--);
                    }
                }
            }
            // новые записи
            foreach (var pc in model.EngineDetails)
            {
                source.EngineDetails.Add(new EngineDetail
                {
                    Id = ++maxPCId,
                    EngineId = engine.Id,
                    DetailId = pc.Key,
                    Count = pc.Value.Item2
                });
            }
            return engine;
        }
        public List<EngineViewModel> Read(EngineBindingModel model)
        {
            List<EngineViewModel> result = new List<EngineViewModel>();
            foreach (var detail in source.Engines)
            {
                if (model != null)
                {
                    if (detail.Id == model.Id)
                    {
                        result.Add(CreateViewModel(detail));
                        break;
                    }
                    continue;
                }
                result.Add(CreateViewModel(detail));
            }
            return result;
        }
        private EngineViewModel CreateViewModel(Engine engine)
        {
            // требуется дополнительно получить список компонентов для изделия с названиями и их количество

            Dictionary<int, (string, int)> engineDetails = new Dictionary<int,
(string, int)>();
            foreach (var pc in source.EngineDetails)
            {
                if (pc.EngineId == engine.Id)
                {
                    string detailName = string.Empty;
                    foreach (var detail in source.Details)
                    {
                        if (pc.DetailId == detail.Id)
                        {
                            detailName = detail.DetailName;
                            break;
                        }
                    }
                    engineDetails.Add(pc.DetailId, (detailName, pc.Count));
                }
            }
            return new EngineViewModel
            {
                Id = engine.Id,
                EngineName = engine.EngineName,
                Price = engine.Price,
                EngineDetails = engineDetails
            };
        }
    }
}
