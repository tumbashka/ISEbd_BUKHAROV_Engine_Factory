using EngineFactoryBusinessLogic.BindingModels;
using EngineFactoryBusinessLogic.HelperModels;
using EngineFactoryBusinessLogic.Interfaces;
using EngineFactoryBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;


namespace EngineFactoryBusinessLogic.BusinessLogic
{
    public class ReportLogic
    {
        private readonly IDetailLogic detailLogic;
        private readonly IEngineLogic engineLogic;
        private readonly IOrderLogic orderLogic;
        public ReportLogic(IEngineLogic engineLogic, IDetailLogic detailLogic,
       IOrderLogic orderLLogic)
        {
            this.engineLogic = engineLogic;
            this.detailLogic = detailLogic;
            this.orderLogic = orderLLogic;
        }
        public List<ReportEngineDetailViewModel> GetEngineDetail()
        {
            var Details = detailLogic.Read(null);
            var Engines = engineLogic.Read(null);
            var list = new List<ReportEngineDetailViewModel>();
            foreach (var Detail in Details)
            {
                foreach (var Engine in Engines)
                {
                    if (Engine.EngineDetails.ContainsKey(Detail.Id))
                    {
                        var record = new ReportEngineDetailViewModel
                        {
                            EngineName = Engine.EngineName,
                            DetailName = Detail.DetailName,                            
                            Count = Engine.EngineDetails[Detail.Id].Item2
                        };
                        list.Add(record);
                    }
                }
            }
            return list;
        }
        public List<ReportOrdersViewModel> GetOrders(ReportBindingModel model)
        {
            return orderLogic.Read(new OrderBindingModel
            {
                DateFrom = model.DateFrom,
                DateTo = model.DateTo
            })
            .Select(x => new ReportOrdersViewModel
            {
                DateCreate = x.DateCreate,
                EngineName = x.EngineName,
                Count = x.Count,
                Sum = x.Sum,
                Status = x.Status
            })
           .ToList();
        }
        /// <summary>
        /// Сохранение компонент в файл-Word
        /// </summary>
        /// <param name="model"></param>
        public void SaveEnginesToWordFile(ReportBindingModel model)
        {
            SaveToWord.CreateDoc(new WordInfo
            {
                FileName = model.FileName,
                Title = "Список двигателей",
                Engines = engineLogic.Read(null)
            });
        }
        /// <summary>
        /// Сохранение компонент с указаеним продуктов в файл-Excel
        /// </summary>
        /// <param name="model"></param>
        public void SaveOrdersToExcelFile(ReportBindingModel model)
        {
            SaveToExcel.CreateDoc(new ExcelInfo
            {
                DateFrom = model.DateFrom.Value,
                DateTo = model.DateTo.Value,
                FileName = model.FileName,
                Title = "Список заказов",
                Orders = GetOrders(model)
            });
        }
        public void SaveEnginesToPdfFile(ReportBindingModel model)
        {
            SaveToPdf.CreateDoc(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Список двигателей по деталям",
                EngineDetails = GetEngineDetail(),
            });
        }
    }
}
