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
    public class OrdersController : Controller
    {
        BLLFacade facade = new BLLFacade();
        // GET: api/Orders
        [HttpGet]
        public IEnumerable<OrderBO> Get()
        {
            return facade.OrderService.GetAll();
        }

        //GET: api/orders/5
        [HttpGet("{id}")]
        public OrderBO Get(int id)
        {
            return facade.OrderService.Get(id);
        }

        // POST: api/Orders
        [HttpPost]
        public IActionResult Post([FromBody]OrderBO order)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(facade.OrderService.Create(order));
        }
        
        // PUT: api/Orders/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]OrderBO order)
        {
            if(id != order.Id)
            {
                return BadRequest("Path Id does not match Order Id in JSON");
            }
            try
            {
                return Ok(facade.OrderService.Update(order));
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
            facade.OrderService.Delete(id);
        }
    }
}
