using EngineFactoryBusinessLogic.BindingModels;
using EngineFactoryBusinessLogic.Interfaces;
using EngineFactoryBusinessLogic.ViewModels;
using EngineFactoryDatabaseImplements;
using EngineFactoryDatabaseImplements.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EngineFactoryDatabaseImplement.Implements
{
    public class EngineLogic : IEngineLogic
    {
        public void CreateOrUpdate(EngineBindingModel model)
        {
            using (var context = new EngineFactoryDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Engine element = context.Engines.FirstOrDefault(rec =>
                       rec.EngineName == model.EngineName && rec.Id != model.Id);
                        if (element != null)
                        {
                            throw new Exception("Уже есть двигатель с таким названием");
                        }
                        if (model.Id.HasValue)
                        {
                            element = context.Engines.FirstOrDefault(rec => rec.Id ==
                           model.Id);
                            if (element == null)
                            {
                                throw new Exception("Элемент не найден");
                            }
                        }
                        else
                        {
                            element = new Engine();
                            context.Engines.Add(element);
                        }
                        element.EngineName = model.EngineName;
                        element.Price = model.Price;
                        context.SaveChanges();
                        if (model.Id.HasValue)
                        {
                            var productDetails = context.EngineDetails.Where(rec
                           => rec.EngineId == model.Id.Value).ToList();
                            // удалили те, которых нет в модели
                            context.EngineDetails.RemoveRange(productDetails.Where(rec =>
                            !model.EngineDetails.ContainsKey(rec.DetailId)).ToList());
                            context.SaveChanges();
                            // обновили количество у существующих записей
                            foreach (var updateDetail in productDetails)
                            {
                                updateDetail.Count =
                               model.EngineDetails[updateDetail.DetailId].Item2;

                                model.EngineDetails.Remove(updateDetail.DetailId);
                            }
                            context.SaveChanges();
                        }
                        // добавили новые
                        foreach (var pc in model.EngineDetails)
                        {
                            context.EngineDetails.Add(new EngineDetail
                            {
                                EngineId = element.Id,
                                DetailId = pc.Key,
                                Count = pc.Value.Item2
                            });
                            context.SaveChanges();
                        }
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
        public void Delete(EngineBindingModel model)
        {
            using (var context = new EngineFactoryDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        // удаяем записи по деталям при удалении двигателя
                        context.EngineDetails.RemoveRange(context.EngineDetails.Where(rec =>
                        rec.EngineId == model.Id));
                        Engine element = context.Engines.FirstOrDefault(rec => rec.Id == model.Id);
                        if (element != null)
                        {
                            context.Engines.Remove(element);
                            context.SaveChanges();
                        }
                        else
                        {
                            throw new Exception("Элемент не найден");
                        }
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
        public List<EngineViewModel> Read(EngineBindingModel model)
        {
            using (var context = new EngineFactoryDatabase())
            {
                return context.Engines
                .Where(rec => model == null || rec.Id == model.Id)
                .ToList()
               .Select(rec => new EngineViewModel
               {
                   Id = rec.Id,
                   EngineName = rec.EngineName,
                   Price = rec.Price,
                   EngineDetails = context.EngineDetails
                .Include(recPC => recPC.Detail)
               .Where(recPC => recPC.EngineId == rec.Id)
               .ToDictionary(recPC => recPC.DetailId, recPC =>
                (recPC.Detail?.DetailName, recPC.Count))
               })
               .ToList();
            }
        }
    }
}
