using DeliveryProject.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DeliveryProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipientsController : ControllerBase
    {
        public static List<Recipients> listRecipient = new List<Recipients> { new Recipients { Id=1,Name="nusi",Address="yus 2",Email="skf@gmail.com",PhoneNumber="0987656787"},
                                                                       new Recipients{ Id = 2, Address = "yeuausa", Email = "do@gmail.com", Name = "sisisi", PhoneNumber = "08767657234"} };
        // GET: api/<RecipientsController>
        [HttpGet]
        public IEnumerable<Recipients> Get()
        {
            return listRecipient;
        }

        // GET api/<RecipientsController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var r = listRecipient.Find(x => x.Id == id);
            if (r == null)
            {
                return NotFound();
            }
            return Ok(r);
        }

        // POST api/<RecipientsController>
        [HttpPost]
        public ActionResult Post([FromBody] Recipients value)
        {
            var r = listRecipient.Find(x => x.Id == value.Id);
            if (r == null)
            {
                listRecipient.Add(value);
                return Ok(value);
            }
            return Conflict();
        }

        // PUT api/<RecipientsController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Recipients value)
        {
            var r = listRecipient.Find(x => x.Id == value.Id);
            if (r == null)
            {
                return BadRequest();

            }
            r.Email = value.Email;
            r.Name = value.Name;
            r.Address = value.Address;
            r.PhoneNumber = value.PhoneNumber;
            return Ok(r);
        }

        // DELETE api/<RecipientsController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var r = listRecipient.Find(x => x.Id == id);
            if (r == null)
            {
                BadRequest();
            }
            return NoContent();
        }
    }
}
