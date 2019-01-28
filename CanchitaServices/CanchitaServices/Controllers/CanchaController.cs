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
    public class CanchaController : Controller
    {
        private ICanchaRepository repositorio;
        public CanchaController(ICanchaRepository repo)
        {
            repositorio = repo;
        }
        // GET: api/<controller>
        [HttpGet]
        public IQueryable<TCancha> Get()
        {
            return repositorio.Items;
        }

        // GET api/<controller>/5
        [HttpGet("{CanchaId}")]
        public TCancha Get(Guid CanchaId)
        {
            return repositorio.Items.Where(p => p.CanchaId == CanchaId).FirstOrDefault();
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]TCancha cancha)
        {
            await repositorio.Save(cancha);
            return Ok(true);
        }

        // PUT api/<controller>/5
        [HttpPut("{CanchaId}")]
        public async Task<IActionResult> Put(Guid CanchaId, [FromBody]TCancha cancha)
        {
            cancha.CanchaId = CanchaId;
            await repositorio.Save(cancha);
            return Ok(true);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{CanchaId}")]
        public IActionResult Delete(Guid CanchaId)
        {
            repositorio.Delete(CanchaId);
            return Ok(true);
        }
    }
}
