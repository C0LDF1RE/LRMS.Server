using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace LRMS.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserLoginController : ControllerBase
    {
        private readonly UserInfoDbContext _db;

        public UserLoginController(UserInfoDbContext db)
        {
            _db = db;
        }

        [HttpPost]
        public async Task<IActionResult> LogIn([FromBody] UserLoginModel md)
        {
            var metas = from m in _db.user_login
                        where m.username == md.username
                        select m;
            await Task.Delay(0);
            UserLoginModel meta = metas.FirstOrDefault();
            if (meta == null)
            {
                return new JsonResult("No account.");
            }
            if (meta.password == md.password)
            {
                Debug.WriteLine("I am here  " + meta.username + "  " + meta.password);
                return new JsonResult("OK!");
            }
            else
            {
                return new JsonResult("Password not matched.");
            }

            // 获取数据库里某个值
            // await Task.Delay(0);

            // return new JsonResult(metadata);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserLoginModel metadata)
        {
            // UserLoginModel metadata = new UserLoginModel()
            // {
            //     uid = new Random().Next(10000),
            //     username = "test",
            //     password = "123456",
            //     avatar = null,
            //     registry_date = DateTime.Now,
            //     Last_login_date = DateTime.Now,
            //     login_count = 0
            // };
            if (!ModelState.IsValid)
            {
                return new JsonResult("Error");
            }
            _db.user_login.Add(metadata);
            await _db.SaveChangesAsync();
            return new JsonResult(metadata);
        }

    }
}
