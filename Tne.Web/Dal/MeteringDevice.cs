using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Tne.Web.Dal
{
    /// <summary>
    /// Прибор учета 
    /// (связь по времени между точками поставки и точками измерения)
    /// </summary>
    public class MeteringDevice
    {
        // дата начала
        [Key, Column(Order = 1, TypeName = "date")]        
        public DateTime StartDate { get; set; }

        // дата окончания или null
        [Column(TypeName = "date")]
        public DateTime? EndDate { get; set; }

       // [ForeignKey("PointOfMeasure")]
        [Key, Column(Order = 2)]
        public int PointOfMeasureId { get; set; }
        public PointOfMeasure PointOfMeasure { get; set; }

       // [ForeignKey("PointOfInstallation")]
        [Key, Column(Order = 3)]
        public int PointOfInstallationId { get; set; }
        public PointOfInstallation PointOfInstallation { get; set; }

    }
}
