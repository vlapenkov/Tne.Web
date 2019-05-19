using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tne.Web.Dal
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
