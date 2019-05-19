using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Tne.Web.Dal
{
   public enum CounterType
    {
        First,
        Second,
        Third
    }

    public enum TransformatorType
    {
        First2,
        Second2,
        Third2
    }

    /// <summary>
    /// Абстрактный класс для реализации в EF  через дискриминатор (все 3 типа сущности в одной таблице)
    /// </summary>
    public abstract  class AbstractCounter :BaseEntity
    {
      
        [Column(TypeName = "date")]
        public DateTime CheckDate { get; set; }

        [ForeignKey("PointOfMeasure")]
        public int PointOfMeasureId { get; set; }

        public PointOfMeasure PointOfMeasure { get; set; }
    }

    /// <summary>
    /// Счетчик электроэнергии
    /// </summary>
    public class Counter : AbstractCounter
    {
        public CounterType CounterType { get; set; }
    }


    /// <summary>
    /// Трансформатор тока
    /// </summary>
    public class CurrentTransformator : AbstractCounter
    {
        public TransformatorType CurrentTransformatorType { get; set; }
        public int Ktt { get; set; }
    }


    /// <summary>
    /// Трансформатор напряжения
    /// </summary>
    public class VoltageTransformator : AbstractCounter
    {
        public TransformatorType CurrentTransformatorType { get; set; }
        public int Ktt { get; set; }
    }


}
