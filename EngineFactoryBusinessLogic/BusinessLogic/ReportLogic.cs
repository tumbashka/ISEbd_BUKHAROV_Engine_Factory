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
            var details = detailLogic.Read(null);
            var engines = engineLogic.Read(null);
            var list = new List<ReportEngineDetailViewModel>();
            foreach (var detail in details)
            {
                var record = new ReportEngineDetailViewModel
                {
                    DetailName = detail.DetailName,
                    Engines = new List<Tuple<string, int>>(),
                    TotalCount = 0
                };
                foreach (var engine in engines)
                {
                    if (engine.EngineDetails.ContainsKey(detail.Id))
                    {
                        record.Engines.Add(new Tuple<string, int>(engine.EngineName,
                       engine.EngineDetails[detail.Id].Item2));
                        record.TotalCount +=
                       engine.EngineDetails[detail.Id].Item2;
                    }
                }
                list.Add(record);
            }
            return list;
        }
        /// <summary>
        /// Получение списка заказов за определенный период
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
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
        public void SaveDetailsToWordFile(ReportBindingModel model)
        {
            SaveToWord.CreateDoc(new WordInfo
            {
                FileName = model.FileName,
                Title = "Список деталь",
                Details = detailLogic.Read(null)
            });
        }
        /// <summary>
        /// Сохранение компонент с указаеним продуктов в файл-Excel
        /// </summary>
        /// <param name="model"></param>
        public void SaveEngineDetailToExcelFile(ReportBindingModel model)
        {
            SaveToExcel.CreateDoc(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Список деталь",
                EngineDetails = GetEngineDetail()
            });
        }
        /// <summary>
        /// Сохранение заказов в файл-Pdf
        /// </summary>
        /// <param name="model"></param>
        public void SaveOrdersToPdfFile(ReportBindingModel model)
        {
            SaveToPdf.CreateDoc(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Список заказов",
                DateFrom = model.DateFrom.Value,
                DateTo = model.DateTo.Value,
                Orders = GetOrders(model)
            });
        }
    }
}
