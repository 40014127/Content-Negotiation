using Content.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Content.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {

        [HttpGet("{id}")]
        public IEnumerable<string> Get()
        {
            return new string[]
                    { "Hello LTTS!",
                    "Hello Galaxy!",
                    "Hello Universe!"
                    };
        }

        [HttpGet]
        public ActionResult Get([FromQuery] int count)
        {
            string[] recep = { "CCC", "DDD", "BBB" };
            if (!recep.Any())
            {
                return NotFound();
            }
            return Ok(recep.Take(count));

        }

        [HttpPost("{id}")]
        public string Post(int id)
        {
            return "Hello World!";
        }


        [HttpPut("{id}")]
        public string Put(int id)
        {
            return "Hello Galaxy!";
        }


        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return "Hello Universe!";
        }
    }
}
