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
    public class OrderLogic : IOrderLogic
    {
        public void CreateOrUpdate(OrderBindingModel model)
        {
            {
                using (var context = new EngineFactoryDatabase())
                {
                    Order element;
                    if (model.Id.HasValue)
                    {
                        element = context.Orders.FirstOrDefault(rec => rec.Id ==
                       model.Id);
                        if (element == null)
                        {
                            throw new Exception("Элемент не найден");
                        }
                    }
                    else
                    {
                        element = new Order();
                        context.Orders.Add(element);
                    }
                    element.EngineId = model.EngineId == 0 ? element.EngineId : model.EngineId;
                    element.Count = model.Count;
                    element.Sum = model.Sum;
                    element.Status = model.Status;
                    element.DateCreate = model.DateCreate;
                    element.DateImplement = model.DateImplement;
                    context.SaveChanges();
                }
            }
        }
        public void Delete(OrderBindingModel model)
        {
            using (var context = new EngineFactoryDatabase())
            {
                Order element = context.Orders.FirstOrDefault(rec => rec.Id ==
model.Id);
                if (element != null)
                {
                    context.Orders.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }
        public List<OrderViewModel> Read(OrderBindingModel model)
        {
            using (var context = new EngineFactoryDatabase())
            {
                return context.Orders
            .Include(rec => rec.Engine)
            .Where(rec => model == null || rec.Id == model.Id)
            .Select(rec => new OrderViewModel
            {
                Id = rec.Id,
                EngineName = rec.Engine.EngineName,
                Count = rec.Count,
                Sum = rec.Sum,
                Status = rec.Status,
                DateCreate = rec.DateCreate,
                DateImplement = rec.DateImplement
            })
            .ToList();
            }
        }
    }
}
