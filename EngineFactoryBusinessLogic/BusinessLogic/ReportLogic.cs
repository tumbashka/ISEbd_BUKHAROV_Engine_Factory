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
            var Engines = engineLogic.Read(null);
            var list = new List<ReportEngineDetailViewModel>();
            foreach (var Engine in Engines)
            {
                foreach (var ed in Engine.EngineDetails)
                {
                    var record = new ReportEngineDetailViewModel
                    {
                        EngineName = Engine.EngineName,
                        DetailName = ed.Value.Item1,
                        Count = ed.Value.Item2
                    };
                    list.Add(record);
                }
            }
            return list;
        }
        public List<IGrouping<DateTime, OrderViewModel>> GetOrders(ReportBindingModel model)
        {
            var list = orderLogic
                        .Read(new OrderBindingModel
                        {
                            DateFrom = model.DateFrom,
                            DateTo = model.DateTo
                        })
                        .GroupBy(rec => rec.DateCreate.Date)
                        .OrderBy(recG => recG.Key)
                        .ToList();
            return list;
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
