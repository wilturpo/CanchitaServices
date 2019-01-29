using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.IRepositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CanchitaServices.Controllers
{
    [Route("api/[controller]")]
    public class TurnoController : Controller
    {
        private ITurnoRepository repositorio;
        public TurnoController(ITurnoRepository repo)
        {
            repositorio = repo;
        }
        // GET: api/<controller>
        [HttpGet]
        public IQueryable<TTurno> Get()
        {
            return repositorio.Items;
        }

        // GET api/<controller>/5
        [HttpGet("{TurnoId}")]
        public TTurno Get(Guid TurnoId)
        {
            return repositorio.Items.Where(p => p.TurnoId == TurnoId).FirstOrDefault();
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]TTurno turno)
        {
            await repositorio.Save(turno);
            return Ok(true);
        }

        // PUT api/<controller>/5
        [HttpPut("{TurnoId}")]
        public async Task<IActionResult> Put(Guid TurnoId, [FromBody]TTurno turno)
        {
            turno.TurnoId = TurnoId;
            await repositorio.Save(turno);
            return Ok(true);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{TurnoId}")]
        public IActionResult Delete(Guid TurnoId)
        {
            repositorio.Delete(TurnoId);
            return Ok(true);
        }
    }
}
