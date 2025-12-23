using Delivery.Core.Services;
using Delivery.Core.Models;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Delivery.Core.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DeliveryProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PackagesController : ControllerBase
    {
        private readonly IPackageService _packageServ;
        private readonly IMapper _mapper;
        public PackagesController(IPackageService packageServ, IMapper mapper)
        {
            _packageServ = packageServ;
            _mapper = mapper;

        }

        // GET: api/<PackagesController>
        [HttpGet]
        public IEnumerable<PackagesDTO> Get()
        {
            var plst= _packageServ.GetPackages();
            var DTOlst=new List<PackagesDTO>();
            DTOlst=_mapper.Map<List<PackagesDTO>>(plst);
            return DTOlst;
        }
        //האם חבילה נמצאת 
        // GET api/<PackagesController>/5
        [HttpGet("{code}")]
        public ActionResult Get(int code)
        {
            var pc = _packageServ.GetPackageByID(code);
            var pDTO=_mapper.Map<PackagesDTO>(pc);
            if (pc == null)
            {
                return NotFound();
            }
            return Ok(pDTO);
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
            var package = new Packages { Description = value.Description, Status = value.Status, DeliverID = value.DeliverID, RecipientID = value.RecipientID };
            var pac = _packageServ.GetPackageByID(value.Id);
            if (pac == null)
            {
               _packageServ.AddPackage(value);
                return Ok(value);
            }
            return Conflict();
        }

        // PUT api/<PackagesController>/5
        [HttpPut("{code}")]
        public ActionResult Put(int code, [FromBody] Packages value)
        {
            var package = new Packages {Description=value.Description,Status=value.Status,DeliverID=value.DeliverID,RecipientID=value.RecipientID };
            var pac= _packageServ.GetPackageByID(code);
            if(pac == null)
            {
                return BadRequest();

            }
            pac.Status = package.Status;
            pac.Description = package.Description;
            pac.DeliverID= package.DeliverID;
            pac.RecipientID= package.RecipientID;
            return Ok(pac);
        }

        // DELETE api/<PackagesController>/5
        [HttpDelete("{code}")]
        public ActionResult Delete(int code)
        {
            var pac= _packageServ.GetPackageByID(code);
            if (pac == null)
            {
                BadRequest();
            }
            return NoContent();
        }
    }
}
