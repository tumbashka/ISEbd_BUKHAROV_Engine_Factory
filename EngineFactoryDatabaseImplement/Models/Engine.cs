using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EngineFactoryDatabaseImplement.Models
{
    public class Engine
    {
        public int Id { get; set; }
        [Required]
        public string EngineName { get; set; }
        [Required]
        public decimal Price { get; set; }
        public virtual List<EngineDetail> EngineDetails { get; set; }
        public virtual List<Order> Orders  { get; set; }

    }
}
