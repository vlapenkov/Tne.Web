using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Tne.Web.Dal
{
    /// <summary>
    /// Объект потребления
    /// </summary>
    public class ObjectOfConsumption :BaseEntity
    {
      

        [MaxLength(100)]
        public string Name { get; set; }


        [ForeignKey("ChidOrganization")]
        public int ChidOrganizationId { get; set; }
        public ChidOrganization ChidOrganization { get; set; }

        public ICollection<PointOfInstallation> PointsOfInstallation { get; set; }
        public ICollection<PointOfMeasure> PointsOfMeasure { get; set; }
    }
}
