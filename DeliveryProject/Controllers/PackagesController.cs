using DeliveryProject.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DeliveryProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PackagesController : ControllerBase
    {
        public static List<Packages> listPackage=new List<Packages> { new Packages { Code = 1,  DeliverID = 2,Description = "toys", RecipientID = 1, Status= StausP.onHold } };
        // GET: api/<PackagesController>
        [HttpGet]
        public IEnumerable<Packages> Get()
        {
            return listPackage;
        }
        //האם חבילה נמצאת 
        // GET api/<PackagesController>/5
        [HttpGet("{code}")]
        public ActionResult Get(int code)
        {
            var pc = listPackage.Find(p => p.Code == code);
            if (pc == null)
            {
                return NotFound();
            }
            return Ok(pc);
        }
        ////קבלת החבילות של משלוחן לפי תז
        //[HttpGet("packageForDeliver/{id}")]
        //public List<Packages> Get(int id)
        //{
        //    List<Packages> lp=listPackage.Filter(p => p.DeliverID == id);
        //    return lp;
        //}
        ////קבלת חבילות לנמען לפי תז
        //[HttpGet("packageForRecipient/{id}")]
        //public List<Packages> Get(int id)
        //{
        //    List<Packages> lp = listPackage.Filter(p => p.RecipientID == id);
        //    return lp;
        //}
        //// POST api/<PackagesController>
        [HttpPost]
        public ActionResult Post([FromBody] Packages value)
        {
            var pac=listPackage.Find(p=>p.Code == value.Code);
            if (pac == null)
            {
                listPackage.Add(value);
                return Ok(value);
            }
            return Conflict();
        }

        // PUT api/<PackagesController>/5
        [HttpPut("{code}")]
        public ActionResult Put(int code, [FromBody] Packages value)
        {
            var pac=listPackage.Find(pac=>pac.Code == code);
            if(pac == null)
            {
                return BadRequest();

            }
            pac.Status = value.Status;
            pac.Description = value.Description;
            pac.DeliverID=value.DeliverID;
            pac.RecipientID=value.RecipientID;
            return Ok(pac);
        }

        // DELETE api/<PackagesController>/5
        [HttpDelete("{code}")]
        public ActionResult Delete(int code)
        {
            var pac=listPackage.Find(p => p.Code == code);
            if (pac == null)
            {
                BadRequest();
            }
            return NoContent();
        }
    }
}
