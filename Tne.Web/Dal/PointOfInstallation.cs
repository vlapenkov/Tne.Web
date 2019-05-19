﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Tne.Web.Dal
{
    /// <summary>
    /// Точка поставки
    /// </summary>
    public class PointOfInstallation :BaseEntity
    {        
       
        [MaxLength(100)]
        public string Name { get; set; }

        public int MaxVolume { get; set; }

        [ForeignKey("ObjectOfConsumption")]
        public int ObjectOfConsumptionId { get; set; }
        public ObjectOfConsumption ObjectOfConsumption { get; set; }

        public ICollection<MeteringDevice> Records { get; set; }
    }
}
