using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;
using Application.IServices;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CanchitaServices.Controllers
{
    [Route("api/[controller]")]
    public class AlquilerController : Controller
    {
        private IAlquilerService Service;
        public AlquilerController(IAlquilerService service)
        {
            Service = service;
        }
        // GET: api/<controller>
        [HttpGet]
        public IList<AlquilerDTO> Get()
        {
            return Service.GetAll();
        }

        // GET api/<controller>/5
        [HttpGet("{AlquilerId}")]

        public AlquilerDTO Get(Guid AlquilerId)
        {

            return Service.GetAll().Where(p => p.AlquiId == AlquilerId).FirstOrDefault();
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]AlquilerDTO alquiler)
        {
            await Service.Insert(alquiler);
            return Ok(true);
        }

        // PUT api/<controller>/5
        [HttpPut("{AlquilerId}")]
        public async Task<IActionResult> Put(Guid AlquilerId, [FromBody]AlquilerDTO alquiler)
        {
            alquiler.AlquiId = AlquilerId;
            await Service.Insert(alquiler);
            return Ok(true);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{AlquilerId}")]
        public IActionResult Delete(Guid AlquilerId)
        {
            Service.Delete(AlquilerId);
            return Ok(true);
        }
    }
}
