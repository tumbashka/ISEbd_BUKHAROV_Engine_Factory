using EngineFactoryListImplement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EngineFactoryListImplement
{
    public class DataListSingleton
    {
        private static DataListSingleton instance;
        public List<Detail> Details { get; set; }
        public List<Order> Orders { get; set; }
        public List<Engine> Engines { get; set; }
        public List<EngineDetail> EngineDetails { get; set; }
        public List<Client> Clients { get; set; }
        private DataListSingleton()
        {
            Details = new List<Detail>();
            Orders = new List<Order>();
            Engines = new List<Engine>();
            EngineDetails = new List<EngineDetail>();
            Clients = new List<Client>();
        }
        public static DataListSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new DataListSingleton();
            }
            return instance;
        }
    }
}
