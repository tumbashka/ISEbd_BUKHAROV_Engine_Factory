using EngineFactoryBusinessLogic.Enums;
using EngineFactoryFileImplement.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace EngineFactoryFileImplement
{
    public class FileDataListSingleton
    {
        private static FileDataListSingleton instance;
        private readonly string DetailFileName = "C:\\Users\\Михан\\Documents\\EngineFactory\\Detail.xml";
        private readonly string OrderFileName = "C:\\Users\\Михан\\Documents\\EngineFactory\\Order.xml";
        private readonly string EngineFileName = "C:\\Users\\Михан\\Documents\\EngineFactory\\Engine.xml";
        private readonly string EngineDetailFileName = "C:\\Users\\Михан\\Documents\\EngineFactory\\EngineDetail.xml";
        public List<Detail> Details { get; set; }
        public List<Order> Orders { get; set; }
        public List<Engine> Engines { get; set; }
        public List<EngineDetail> EngineDetails { get; set; }
        private FileDataListSingleton()
        {
            Details = LoadDetails();
            Orders = LoadOrders();
            Engines = LoadEngines();
            EngineDetails = LoadEngineDetails();
        }
        public static FileDataListSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new FileDataListSingleton();
            }
            return instance;
        }
        ~FileDataListSingleton()
        {
            SaveDetails();
            SaveOrders();
            SaveEngines();
            SaveEngineDetails();
        }
        private List<Detail> LoadDetails()
        {
            var list = new List<Detail>();
            if (File.Exists(DetailFileName))
            {
                XDocument xDocument = XDocument.Load(DetailFileName);
                var xElements = xDocument.Root.Elements("Detail").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Detail
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        DetailName = elem.Element("DetailName").Value
                    });
                }
            }
            return list;
        }
        private List<Order> LoadOrders()
        {
            var list = new List<Order>();
            if (File.Exists(OrderFileName))
            {
                XDocument xDocument = XDocument.Load(OrderFileName);
                var xElements = xDocument.Root.Elements("Order").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Order
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        EngineId = Convert.ToInt32(elem.Element("EngineId").Value),
                        Count = Convert.ToInt32(elem.Element("Count").Value),
                        Sum = Convert.ToDecimal(elem.Element("Sum").Value),
                        Status = (OrderStatus)Enum.Parse(typeof(OrderStatus),
                   elem.Element("Status").Value),
                        DateCreate =
                   Convert.ToDateTime(elem.Element("DateCreate").Value),
                        DateImplement =
                   string.IsNullOrEmpty(elem.Element("DateImplement").Value) ? (DateTime?)null :
                   Convert.ToDateTime(elem.Element("DateImplement").Value),
                    });
                }
            }
            return list;
        }
        private List<Engine> LoadEngines()
        {
            var list = new List<Engine>();
            if (File.Exists(EngineFileName))
            {
                XDocument xDocument = XDocument.Load(EngineFileName); var xElements = xDocument.Root.Elements("Engine").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Engine
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        EngineName = elem.Element("EngineName").Value,
                        Price = Convert.ToDecimal(elem.Element("Price").Value)
                    });
                }
            }
            return list;
        }
        private List<EngineDetail> LoadEngineDetails()
        {
            var list = new List<EngineDetail>();
            if (File.Exists(EngineDetailFileName))
            {
                XDocument xDocument = XDocument.Load(EngineDetailFileName);
                var xElements = xDocument.Root.Elements("EngineDetail").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new EngineDetail
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        EngineId = Convert.ToInt32(elem.Element("EngineId").Value),
                        DetailId = Convert.ToInt32(elem.Element("DetailId").Value),
                        Count = Convert.ToInt32(elem.Element("Count").Value)
                    });
                }
            }
            return list;
        }
        private void SaveDetails()
        {
            if (Details != null)
            {
                var xElement = new XElement("Details");
                foreach (var Detail in Details)
                {
                    xElement.Add(new XElement("Detail",
                    new XAttribute("Id", Detail.Id),
                    new XElement("DetailName", Detail.DetailName)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(DetailFileName);
            }
        }
        private void SaveOrders()
        {
            if (Orders != null)
            {
                var xElement = new XElement("Orders");
                foreach (var order in Orders)
                {
                    xElement.Add(new XElement("Order",
                    new XAttribute("Id", order.Id),
                    new XElement("EngineId", order.EngineId),
                    new XElement("Count", order.Count),
                    new XElement("Sum", order.Sum),
                    new XElement("Status", order.Status),
                    new XElement("DateCreate", order.DateCreate),
                    new XElement("DateImplement", order.DateImplement)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(OrderFileName);
            }
        }
        private void SaveEngines()
        {
            if (Engines != null)
            {
                var xElement = new XElement("Engines");
                foreach (var Engine in Engines)
                {
                    xElement.Add(new XElement("Engine",
                    new XAttribute("Id", Engine.Id),
                    new XElement("EngineName", Engine.EngineName),
                    new XElement("Price", Engine.Price)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(EngineFileName);
            }
        }
        private void SaveEngineDetails()
        {
            if (EngineDetails != null)
            {
                var xElement = new XElement("EngineDetails");
                foreach (var EngineDetail in EngineDetails)
                {
                    xElement.Add(new XElement("EngineDetail",
                    new XAttribute("Id", EngineDetail.Id),
                    new XElement("EngineId", EngineDetail.EngineId),
                    new XElement("DetailId", EngineDetail.DetailId),
                    new XElement("Count", EngineDetail.Count)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(EngineDetailFileName);
            }
        }
    }
}



