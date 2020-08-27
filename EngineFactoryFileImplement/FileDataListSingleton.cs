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
        private readonly string ClientFileName = "C:\\Users\\Михан\\Documents\\EngineFactory\\Client.xml";
        private readonly string ImplementerFileName = "C:\\Users\\Михан\\Documents\\EngineFactory\\Implementer.xml";
        private readonly string MessageInfoFileName = "C:\\Users\\Михан\\Documents\\EngineFactory\\MessageInfo.xml";
        public List<Detail> Details { get; set; }
        public List<Order> Orders { get; set; }
        public List<Engine> Engines { get; set; }
        public List<EngineDetail> EngineDetails { get; set; }
        public List<Client> Clients { get; set; }
        public List<Implementer> Implementers { get; set; }
        public List<MessageInfo> MessageInfoes { get; set; }
        private FileDataListSingleton()
        {
            Details = LoadDetails();
            Orders = LoadOrders();
            Engines = LoadEngines();
            EngineDetails = LoadEngineDetails();
            Clients = LoadClients();
            Implementers = LoadImplementers();
            MessageInfoes = LoadMessageInfoes();
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
            SaveClients();
            SaveImplementers();
            SaveMessageInfoes();
        }
        private List<Implementer> LoadImplementers()
        {
            var list = new List<Implementer>();

            if (File.Exists(ImplementerFileName))
            {
                XDocument xDocument = XDocument.Load(ImplementerFileName);
                var xElements = xDocument.Root.Elements("Implementer").ToList();

                foreach (var elem in xElements)
                {
                    list.Add(new Implementer
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        ImplementerFIO = elem.Element("ImplementerFIO").Value,
                        WorkingTime = Convert.ToInt32(elem.Element("WorkingTime").Value),
                        PauseTime = Convert.ToInt32(elem.Element("PauseTime").Value)
                    });
                }
            }
            return list;
        }
        private List<MessageInfo> LoadMessageInfoes()
        {
            var list = new List<MessageInfo>();

            if (File.Exists(MessageInfoFileName))
            {
                XDocument xDocument = XDocument.Load(MessageInfoFileName);
                var xElements = xDocument.Root.Elements("MessageInfo").ToList();

                foreach (var elem in xElements)
                {
                    list.Add(new MessageInfo
                    {
                        MessageId = elem.Attribute("MessageId").Value,
                        ClientId = Convert.ToInt32(elem.Element("ClientId").Value),
                        SenderName = elem.Element("SenderName").Value,
                        DateDelivery = Convert.ToDateTime(elem.Element("DateDelivery").Value),
                        Subject = elem.Element("Subject").Value,
                        Body = elem.Element("Body").Value
                    });
                }
            }

            return list;
        }

        private void SaveMessageInfoes()
        {
            if (MessageInfoes != null)
            {
                var xElement = new XElement("MessageInfoes");

                foreach (var messageInfo in MessageInfoes)
                {
                    xElement.Add(new XElement("MessageInfo",
                    new XAttribute("Id", messageInfo.MessageId),
                    new XElement("ClientId", messageInfo.ClientId),
                    new XElement("SenderName", messageInfo.SenderName),
                    new XElement("DateDelivery", messageInfo.DateDelivery),
                    new XElement("Subject", messageInfo.Subject),
                    new XElement("Body", messageInfo.Body)));
                }

                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(MessageInfoFileName);
            }
        }
        private List<Client> LoadClients()
        {
            var list = new List<Client>();
            if (File.Exists(ClientFileName))
            {
                XDocument xDocument = XDocument.Load(ClientFileName);
                var xElements = xDocument.Root.Elements("Client").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Client
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        ClientFIO = elem.Element("ClientFIO").Value,
                        Email = elem.Element("Email").Value,
                        Password = elem.Element("Password").Value
                    });
                }
            }
            return list;
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
                        ClientId = Convert.ToInt32(elem.Element("ClientId").Value),
                        ImplementerId = Convert.ToInt32(elem.Attribute("ImplementerId").Value),
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
        private void SaveImplementers()
        {
            if (Implementers != null)
            {
                var xElement = new XElement("Implementers");

                foreach (var implementer in Implementers)
                {
                    xElement.Add(new XElement("Implementer",
                    new XAttribute("Id", implementer.Id),
                    new XElement("ImplementerFIO", implementer.ImplementerFIO),
                    new XElement("WorkingTime", implementer.WorkingTime),
                    new XElement("PauseTime", implementer.PauseTime)));
                }

                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(ImplementerFileName);
            }
        }
        private void SaveClients()
        {
            if (Clients != null)
            {
                var xElement = new XElement("Clients");

                foreach (var client in Clients)
                {
                    xElement.Add(new XElement("Client",
                    new XAttribute("Id", client.Id),
                    new XElement("ClientFIO", client.ClientFIO),
                    new XElement("Email", client.Email),
                    new XElement("Password", client.Password)));
                }

                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(ClientFileName);
            }
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
                    new XElement("ClientId", order.ClientId),
                    new XElement("ImplementerId", order.ImplementerId),
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



