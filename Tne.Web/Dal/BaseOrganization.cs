﻿using System.ComponentModel.DataAnnotations;
using Tne.Web.Dal;

namespace Tne.Web
{
    public abstract class BaseOrganization :BaseEntity
    {        
        
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string Address { get; set; }
    }
}