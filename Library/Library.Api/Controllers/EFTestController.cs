using Library.Data.EF;
using Library.Data.EF.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EFTestController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            using (var context = new ApplicationDbContext())
            {
                context.Add(Book.Create("Lśnienie", Name.Create("Stephen", "King", null).Value).Value);
                context.SaveChanges();
            }

            return Ok();
        }
    }
}
