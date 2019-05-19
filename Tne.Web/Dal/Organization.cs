using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tne.Web
{
    public class Organization : BaseOrganization
    {
    
        public ICollection<ChidOrganization> ChildOrganizations { get; set; }
    }

}