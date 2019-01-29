using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;
using Application.IServices;
using Domain;
using Domain.IRepositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CanchitaServices.Controllers
{
    [Route("api/[controller]")]
    public class PrecioController : Controller
    {
        private IPrecioService Service;
        public PrecioController(IPrecioService service)
        {
            Service = service;
        }
        // GET: api/<controller>
        [HttpGet]
        public IList<PrecioDTO> Get()
        {
            return Service.GetAll();
        }

        // GET api/<controller>/5
        [HttpGet("{PrecioId}")]

        public PrecioDTO Get(Guid PrecioId)
        {

            return Service.GetAll().Where(p => p.PrecId == PrecioId).FirstOrDefault();
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]PrecioDTO precio)
        {
            await Service.Insert(precio);
            return Ok(true);
        }

        // PUT api/<controller>/5
        [HttpPut("{PrecioId}")]
        public async Task<IActionResult> Put(Guid PrecioId, [FromBody]PrecioDTO precio)
        {
            precio.PrecId = PrecioId;
            await Service.Insert(precio);
            return Ok(true);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{PrecioId}")]
        public IActionResult Delete(Guid PrecioId)
        {
            Service.Delete(PrecioId);
            return Ok(true);
        }
    }
}
