﻿using EngineFactoryBusinessLogic.BindingModels;
using EngineFactoryBusinessLogic.Enums;
using EngineFactoryBusinessLogic.Interfaces;
using EngineFactoryBusinessLogic.ViewModels;
using EngineFactoryListImplement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EngineFactoryListImplement.Implements
{
    public class OrderLogic : IOrderLogic
    {
        private readonly DataListSingleton source;
        public OrderLogic()
        {
            source = DataListSingleton.GetInstance();
        }
        public void CreateOrUpdate(OrderBindingModel model)
        {
            Order tempOrder = model.Id.HasValue ? null : new Order
            {
                Id = 1
            };
            foreach (var Order in source.Orders)
            {
                if (!model.Id.HasValue && Order.Id >= tempOrder.Id)
                {
                    tempOrder.Id = Order.Id + 1;
                }
                else if (model.Id.HasValue && Order.Id == model.Id)
                {
                    tempOrder = Order;
                }
            }
            if (model.Id.HasValue)
            {
                if (tempOrder == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, tempOrder);
            }
            else
            {
                source.Orders.Add(CreateModel(model, tempOrder));
            }
        }
        public void Delete(OrderBindingModel model)
        {
            for (int i = 0; i < source.Orders.Count; ++i)
            {
                if (source.Orders[i].Id == model.Id.Value)
                {
                    source.Orders.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
        public List<OrderViewModel> Read(OrderBindingModel model)
        {
            List<OrderViewModel> result = new List<OrderViewModel>();
            foreach (var order in source.Orders)
            {
                if (model != null)
                {
                    if (order.Id == model.Id || (model.DateFrom.HasValue && model.DateTo.HasValue && order.DateCreate >= model.DateFrom && order.DateCreate <= model.DateTo)
                         || model.ClientId.HasValue && order.ClientId == model.ClientId
                        || model.FreeOrders.HasValue && model.FreeOrders.Value
                    || model.ImplementerId.HasValue && order.ImplementerId == model.ImplementerId && order.Status == OrderStatus.Выполняется)
                    {
                        result.Add(CreateViewModel(order));
                        break;
                    }
                    continue;
                }
                result.Add(CreateViewModel(order));
            }
            return result;
        }
        private Order CreateModel(OrderBindingModel model, Order order)
        {
            order.EngineId = model.EngineId == 0 ? order.EngineId : model.EngineId;
            order.ClientId = (int)model.ClientId;
            order.Count = model.Count;
            order.ImplementerId = model.ImplementerId;
            order.Sum = model.Sum;
            order.Status = model.Status;
            order.DateCreate = model.DateCreate;
            order.DateImplement = model.DateImplement;
            return order;
        }
        private OrderViewModel CreateViewModel(Order order)
        {
            string engineName = "";
            for (int j = 0; j < source.Engines.Count; ++j)
            {
                if (source.Engines[j].Id == order.EngineId)
                {
                    engineName = source.Engines[j].EngineName;
                    break;
                }
            }
            return new OrderViewModel
            {
                Id = order.Id,
                EngineName = engineName,
                Count = order.Count,
                Sum = order.Sum,
                Status = order.Status,
                DateCreate = order.DateCreate,
                DateImplement = order.DateImplement
            };
        }
    }
}
