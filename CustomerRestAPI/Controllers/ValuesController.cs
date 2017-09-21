using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CustomerAppBLL.BusinessObjects;

namespace CustomerRestAPI.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        // Read in CRUD
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        // Read in CRUD
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value -- " + id;
        }

        // POST api/values
        // Create in CRUD
        //BO from JSON using Modelbinding
        [HttpPost]
        public void Post([FromBody]CustomerBO cust)
        {
        }

        // PUT api/values/5
        // Update in CRUD
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
