﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EngineFactoryBusinessLogic.BindingModels;
using EngineFactoryBusinessLogic.BusinessLogic;
using EngineFactoryBusinessLogic.Interfaces;
using EngineFactoryBusinessLogic.ViewModels;
using EngineFactoryRestApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EngineFactoryRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly IOrderLogic _order;
        private readonly IEngineLogic _engine;
        private readonly MainLogic _main;
        public MainController(IOrderLogic order, IEngineLogic engine, MainLogic main)
        {
            _order = order;
            _engine = engine;
            _main = main;
        }
        [HttpGet]
        public List<EngineModel> GetEngineList() => _engine.Read(null)?.Select(rec =>
       Convert(rec)).ToList();
        [HttpGet]
        public EngineModel GetEngine(int engineId) => Convert(_engine.Read(new
       EngineBindingModel
        { Id = engineId })?[0]);
        [HttpGet]
        public List<OrderViewModel> GetOrders(int clientId) => _order.Read(new
       OrderBindingModel
        { ClientId = clientId });
        [HttpPost]
        public void CreateOrder(CreateOrderBindingModel model) =>
       _main.CreateOrder(model);
        private EngineModel Convert(EngineViewModel model)
        {
            if (model == null) return null;
            return new EngineModel
            {
                Id = model.Id,
                EngineName = model.EngineName,
                Price = model.Price
            };
        }
    }
}
