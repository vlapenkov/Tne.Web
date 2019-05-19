using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Tne.Web.Dal;
using Tne.Web.Models;
using Tne.Web.Services;

namespace Tne.Web.Controllers
{
        
    public class HomeController : Controller
    {
        AppDbContext _dbContext;
        IJsonGetter _jsonGetter;
        public HomeController(AppDbContext dbContext , IJsonGetter jsonGetter)
        {
            _dbContext = dbContext;
            _jsonGetter = jsonGetter;

        }


        private string ConcatUrl(HttpRequest request, string urlPart, int id) => $"{request.Scheme}://{request.Host}{request.PathBase}/api/tneapi/{urlPart}?id={id}";

        /// <summary>
        /// Основной и единственный action
        /// </summary>
        /// <param name="id">id объекта потребления</param>
        /// typeId - тип счетчиков
        /// <returns></returns>
        public async Task<IActionResult> Index( int? id , int typeId=1)
        {
            string json;
            var vm = new CounterVm
            {
                Id = id,
                ObjectsOfConsumption = await _dbContext.ObjectOfConsumption.ToListAsync(),           
                TypeId= typeId

            };

            if (id.HasValue)
            {

                var urlPart = "";
                switch (typeId)
                {
                    case 1:
                        urlPart = "expiredCounters";

                        json = await _jsonGetter.GetAsync(ConcatUrl(Request,urlPart,id.Value));
                        vm.Counters = JsonConvert.DeserializeObject<IEnumerable<Counter>>(json);
                        break;
                    case 2:
                        urlPart = "ExpiredCurrentTransformers";
                        json = await _jsonGetter.GetAsync(ConcatUrl(Request, urlPart, id.Value));
                        vm.Counters = JsonConvert.DeserializeObject<IEnumerable<CurrentTransformator>>(json);
                        break;
                    default:
                        urlPart = "ExpiredVoltageTransformers";
                        json = await _jsonGetter.GetAsync(ConcatUrl(Request, urlPart, id.Value));
                        vm.Counters = JsonConvert.DeserializeObject<IEnumerable<VoltageTransformator>>(json);
                        break;
                }
              

                

            }
            
            return View(vm);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
