using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tne.Web.Dal;

namespace Tne.Web.Services
{
    /// <summary>
    /// Репозиторий для получения счетчиков и трансформаторов
    /// </summary>
    public class CountersRepository 
    {
        AppDbContext _dbContext;
        public CountersRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Предположим , что срок истечения - год 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>

      public  IQueryable<T> Get<T>(int id) where T: AbstractCounter
        {
          return  _dbContext.Set<T>().Include(item => item.PointOfMeasure).Where(p => p.CheckDate.AddYears(1) < DateTime.Now.Date && p.PointOfMeasure.ObjectOfConsumptionId == id);
        }


    }
}
