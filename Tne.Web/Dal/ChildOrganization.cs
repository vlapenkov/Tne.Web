using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tne.Web.Dal;

namespace Tne.Web
{
    public class ChidOrganization:BaseOrganization
    {
       
        [ForeignKey("Organization")]
        public int OrganizationId { get; set; }
        public virtual Organization Organization { get; set; }

        public ICollection<ObjectOfConsumption> ObjectsOfConsumption { get; set; }
    }
}