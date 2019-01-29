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
    public class TurnoController : Controller
    {
        private ITurnoService Service;
        public TurnoController(ITurnoService service)
        {
            Service = service;
        }
        // GET: api/<controller>
        [HttpGet]
        public IList<TurnoDTO> Get()
        {
            return Service.GetAll();
        }

        // GET api/<controller>/5
        [HttpGet("{TurnoId}")]

        public TurnoDTO Get(Guid TurnoId)
        {

            return Service.GetAll().Where(p => p.TurnoId == TurnoId).FirstOrDefault();
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]TurnoDTO turno)
        {
            await Service.Insert(turno);
            return Ok(true);
        }

        // PUT api/<controller>/5
        [HttpPut("{TurnoId}")]
        public async Task<IActionResult> Put(Guid TurnoId, [FromBody]TurnoDTO turno)
        {
            turno.TurnoId = TurnoId;
            await Service.Insert(turno);
            return Ok(true);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{TurnoId}")]
        public IActionResult Delete(Guid TurnoId)
        {
            Service.Delete(TurnoId);
            return Ok(true);
        }
    }
}
