﻿using EngineFactoryBusinessLogic.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EngineFactoryDatabaseImplement.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int? ImplementerId { get; set; }
        public int EngineId { get; set; }
        [Required]
        public int Count { get; set; }
        [Required]
        public decimal Sum { get; set; }
        [Required]
        public OrderStatus Status { get; set; }
        [Required]
        public DateTime DateCreate { get; set; }
        public DateTime? DateImplement { get; set; }
        public Engine Engine { get; set; }
        public Client Client { get; set; }
        public Implementer Implementer { get; set; }
    }
}
