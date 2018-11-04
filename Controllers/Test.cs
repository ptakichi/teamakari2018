using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace teamakari2018
{
    [Route("api/[controller]")]
    public class Test: Controller    
    {
        // GET api/Test/Value
        [HttpGet("{Value}")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

    }
}
