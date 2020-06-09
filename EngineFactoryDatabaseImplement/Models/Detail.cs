using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EngineFactoryDatabaseImplement.Models
{
    public class Detail
    {
        public int Id { get; set; }
        [Required]
        public string DetailName { get; set; }
        [ForeignKey("DetailId")]
        public virtual List<EngineDetail> EngineDetails { get; set; }
    }
}
