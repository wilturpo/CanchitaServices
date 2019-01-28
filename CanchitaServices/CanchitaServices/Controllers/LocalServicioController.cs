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
    public class LocalServicioController : Controller
    {
        private ILocalServicioService Service;
        public LocalServicioController(ILocalServicioService service)
        {
            Service = service;
        }
        // GET: api/<controller>
        [HttpGet]
        public IList<LocalServicioDTO> Get()
        {
            return Service.GetAll();
        }

        // GET api/<controller>/5
        [HttpGet("{LocalServicioId}")]

        public LocalServicioDTO Get(Guid LocalServicioId)
        {

            return Service.GetAll().Where(p => p.LocServId == LocalServicioId).FirstOrDefault();
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]LocalServicioDTO localServicio)
        {
            await Service.Insert(localServicio);
            return Ok(true);
        }

        // PUT api/<controller>/5
        [HttpPut("{LocalServicioId}")]
        public async Task<IActionResult> Put(Guid LocalServicioId, [FromBody]LocalServicioDTO localServicio)
        {
            localServicio.LocalId = LocalServicioId;
            await Service.Insert(localServicio);
            return Ok(true);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{LocalServicioId}")]
        public IActionResult Delete(Guid LocalServicioId)
        {
            Service.Delete(LocalServicioId);
            return Ok(true);
        }

    }
}
