using EngineFactoryBusinessLogic.BindingModels;
using EngineFactoryBusinessLogic.Interfaces;
using EngineFactoryBusinessLogic.ViewModels;
using EngineFactoryFileImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EngineFactoryFileImplement.Implements
{
    public class EngineLogic : IEngineLogic
    {
        private readonly FileDataListSingleton source;
        public EngineLogic()
        {
            source = FileDataListSingleton.GetInstance();
        }
        public void CreateOrUpdate(EngineBindingModel model)
        {
            Engine element = source.Engines.FirstOrDefault(rec => rec.EngineName ==
           model.EngineName && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть двигатель с таким названием");
            }
            if (model.Id.HasValue)
            {
                element = source.Engines.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
            }
            else
            {
                int maxId = source.Engines.Count > 0 ? source.Details.Max(rec =>
               rec.Id) : 0;
                element = new Engine { Id = maxId + 1 };
                source.Engines.Add(element);
            }
            element.EngineName = model.EngineName;
            element.Price = model.Price;
            source.EngineDetails.RemoveAll(rec => rec.EngineId == model.Id &&
           !model.EngineDetails.ContainsKey(rec.DetailId));
            var updateDetails = source.EngineDetails.Where(rec => rec.EngineId ==
           model.Id && model.EngineDetails.ContainsKey(rec.DetailId));
            foreach (var updateDetail in updateDetails)
            {
                updateDetail.Count =
               model.EngineDetails[updateDetail.DetailId].Item2;
                model.EngineDetails.Remove(updateDetail.DetailId);
            }
            int maxPCId = source.EngineDetails.Count > 0 ?
           source.EngineDetails.Max(rec => rec.Id) : 0; foreach (var pc in model.EngineDetails)
            {
                source.EngineDetails.Add(new EngineDetail
                {
                    Id = ++maxPCId,
                    EngineId = element.Id,
                    DetailId = pc.Key,
                    Count = pc.Value.Item2
                });
            }
        }
        public void Delete(EngineBindingModel model)
        {
            source.EngineDetails.RemoveAll(rec => rec.EngineId == model.Id);
            Engine element = source.Engines.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                source.Engines.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
        public List<EngineViewModel> Read(EngineBindingModel model)
        {
            return source.Engines
            .Where(rec => model == null || rec.Id == model.Id)
            .Select(rec => new EngineViewModel
            {
                Id = rec.Id,
                EngineName = rec.EngineName,
                Price = rec.Price,
                EngineDetails = source.EngineDetails
            .Where(recPC => recPC.EngineId == rec.Id)
            .ToDictionary(recPC => recPC.DetailId, recPC =>
            (source.Details.FirstOrDefault(recC => recC.Id ==
           recPC.DetailId)?.DetailName, recPC.Count))
            })
            .ToList();
        }

    }
}
