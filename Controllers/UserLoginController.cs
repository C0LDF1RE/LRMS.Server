using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LRMS.Server.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UserLoginController : ControllerBase
    {
        private readonly UserInfoDbContext _db;

        public UserLoginController(UserInfoDbContext db)
        {
            _db = db;
        }

        public ActionResult<IEnumerable<string>> Getuserinfo()
        {
            var metadata = _db.user_login.FirstOrDefault();

            // 获取数据库里某个值

            return new JsonResult(metadata);
        }
        // private static readonly string[] Summaries = new[]
        // {
        //     "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        // };

        // private readonly ILogger<TestController> _logger;

        // public TestController(ILogger<TestController> logger)
        // {
        //     _logger = logger;
        // }

        // [HttpGet]
        // public IEnumerable<WeatherForecast> Get()
        // {
        //     var rng = new Random();
        //     return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //     {
        //         Date = DateTime.Now.AddDays(index),
        //         TemperatureC = rng.Next(-20, 55),
        //         Summary = Summaries[rng.Next(Summaries.Length)]
        //     })
        //     .ToArray();
        // }
    }
}
