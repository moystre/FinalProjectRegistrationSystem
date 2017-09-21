using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CustomerAppBLL;
using CustomerAppBLL.BusinessObjects;

namespace CustomerRestAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class CustomersController : Controller
    {
        BLLFacade facade = new BLLFacade();

        // GET: api/Customers
        [HttpGet]
        public IEnumerable<CustomerBO> Get()
        {
            return facade.CustomerService.GetAll();
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public CustomerBO Get(int id)
        {
            return facade.CustomerService.Get(id);
        }
        
        // POST: api/Customers
        [HttpPost]
        public IActionResult Post([FromBody]CustomerBO cust)
        {
            /*if(!TryValidateModel(cust))
            {
                return BadRequest("Object not valid");
            }*/
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(facade.CustomerService.Create(cust));
        }
        
        // PUT: api/Customers/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]CustomerBO cust)
        {
            if(id != cust.Id)
            {
                return BadRequest("Path ID does not match Customer ID in JSON");
            }

            try
            {
                return Ok(facade.CustomerService.Update(cust));
            }
            catch(InvalidOperationException e)
            {
                return NotFound(e.Message);
            }
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            facade.CustomerService.Delete(id);
        }
    }
}
