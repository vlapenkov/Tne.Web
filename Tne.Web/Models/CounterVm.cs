using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Tne.Web.Dal;

namespace Tne.Web.Models
{
    /// <summary>
    /// Модель 
    /// </summary>
    public class CounterVm
    {
        // id объекта потребления
        [Required(ErrorMessage ="Выберите id ")]
        public int? Id { get; set; }

        // список объектов потребления
        public IEnumerable<ObjectOfConsumption> ObjectsOfConsumption { get; set; }

        // список счетчиков / трансформаторов
        public IEnumerable<AbstractCounter> Counters { get; set; } = new List<AbstractCounter>();

        // 1 - счетчики, 2 - трансф тока, 3- трансф напряжения
        public int? TypeId { get; set; }

    }
}
