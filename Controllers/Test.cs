using System.Collections.Generic;

namespace teamakari2018
{
    [Route("api/[controller]")]
    public class Test: Controller    
    {
        // GET api/CalendarInfo/20171111
        [HttpGet("{Value}")]        
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

    }
}
