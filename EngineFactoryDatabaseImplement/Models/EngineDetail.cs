using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EngineFactoryDatabaseImplement.Models
{
    public class EngineDetail
    {
        public int Id { get; set; }
        public int EngineId { get; set; }
        public int DetailId { get; set; }
        [Required]
        public int Count { get; set; }
        public virtual Detail Detail { get; set; }
        public virtual Engine Engine { get; set; }
    }
}
