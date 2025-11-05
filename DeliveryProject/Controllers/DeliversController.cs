using DeliveryProject.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DeliveryProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliversController : ControllerBase
    {
        public static List<Delivers> listDelivers=new List<Delivers> { new Delivers { Id = 1, Address = "kdfjlk", Email = "djso@gmail.com", Name = "yossi", PhoneNumber = "0876543234" },
                                                                       new Delivers{ Id = 2, Address = "yeuausa", Email = "do@gmail.com", Name = "sisisi", PhoneNumber = "08767657234"} };
        // GET: api/<DeliversController>
        [HttpGet]
        public IEnumerable<Delivers> Get()
        {
            return listDelivers;
        }

        // GET api/<DeliversController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var d=listDelivers.Find(x=>x.Id == id);
            if(d==null)
            {
                return NotFound();
            }
           return Ok(d);
        }

        // POST api/<DeliversController>
        [HttpPost]
        public ActionResult Post([FromBody] Delivers value)
        {
            var d = listDelivers.Find(p => p.Id == value.Id);
            if (d == null)
            {
                listDelivers.Add(value);
                return Ok(value);
            }
            return Conflict();

        }

        // PUT api/<DeliversController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Delivers value)
        {

            var d = listDelivers.Find(pac => pac.Id == value.Id);
            if (d == null)
            {
                return BadRequest();

            }
            d.Email = value.Email;
            d.Name = value.Name;
            d.Address = value.Address;
            d.PhoneNumber = value.PhoneNumber;
            return Ok(d);
        }

        // DELETE api/<DeliversController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var d = listDelivers.Find(p => p.Id == id);
            if (d == null)
            {
                BadRequest();
            }
            return NoContent();
        }
    }
}
