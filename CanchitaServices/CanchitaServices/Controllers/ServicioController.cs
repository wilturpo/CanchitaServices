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
    public class ServicioController : Controller
    {
        private IServicioService Service;
        public ServicioController(IServicioService service)
        {
            Service = service;
        }
        // GET: api/<controller>
        [HttpGet]
        public IList<ServicioDTO> Get()
        {
            return Service.GetAll();
        }

        // GET api/<controller>/5
        [HttpGet("{ServicioId}")]

        public ServicioDTO Get(Guid ServicioId)
        {

            return Service.GetAll().Where(p => p.ServId == ServicioId).FirstOrDefault();
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]ServicioDTO servicio)
        {
            await Service.Insert(servicio);
            return Ok(true);
        }

        // PUT api/<controller>/5
        [HttpPut("{ServicioId}")]
        public async Task<IActionResult> Put(Guid ServicioId, [FromBody]ServicioDTO servicio)
        {
            servicio.ServId = ServicioId;
            await Service.Insert(servicio);
            return Ok(true);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{ServicioId}")]
        public IActionResult Delete(Guid ServicioId)
        {
            Service.Delete(ServicioId);
            return Ok(true);
        }

    }
}
