using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tne.Web.Dal;
using Tne.Web.Services;

namespace Tne.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TneApiController : ControllerBase
    {
        AppDbContext _dbContext;
        CountersRepository _repo;

        public TneApiController(AppDbContext dbContext , CountersRepository repo)
        {
            _dbContext = dbContext;
            _repo = repo;
        }
        // GET: api/TneApi
        [HttpGet("MeteringDevices")]
        public IQueryable<MeteringDevice> MeteringDevices(int year) => _dbContext.MeteringDevices.Where(p => p.StartDate.Year == year);


        // GET: api/TneApi/ExpiredCounters?id=1
        // предположим что нужно проверять раз в год
        [HttpGet("ExpiredCounters")]
        public IQueryable<Counter> ExpiredCounters(int id) => _repo.Get<Counter>(id);


        // GET: api/TneApi/ExpiredCurrentTransformers?id=2
        // предположим что нужно проверять раз в год
        [HttpGet("ExpiredCurrentTransformers")]
        public IQueryable<CurrentTransformator> ExpiredTransformers(int id) => _repo.Get<CurrentTransformator>(id);


        // GET: api/TneApi/ExpiredVoltageTransformers?id=2
        // предположим что нужно проверять раз в год
        [HttpGet("ExpiredVoltageTransformers")]
        public IQueryable<VoltageTransformator> ExpiredVoltageTransformers(int id) => _repo.Get<VoltageTransformator>(id);


    }
}
