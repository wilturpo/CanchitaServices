using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CanchitaServices.Models.Repositories;
using Domain;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CanchitaServices.Controllers
{
    [Route("api/[controller]")]
    public class LocalController : Controller
    {
        private ILocalRepository repositorio;
        public LocalController(ILocalRepository repo)
        {
            repositorio = repo;
        }
        // GET: api/<controller>
        [HttpGet]
        public IQueryable<TLocal> Get()
        {
            return repositorio.Items;
        }

        // GET api/<controller>/5
        [HttpGet("{LocalId}")]
        public TLocal Get(Guid LocalId)
        {
            return repositorio.Items.Where(p => p.LocalId == LocalId).FirstOrDefault();
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]TLocal local)
        {
            await repositorio.Save(local);
            return Ok(true);
        }

        // PUT api/<controller>/5
        [HttpPut("{LocalId}")]
        public async Task<IActionResult> Put(Guid LocalId, [FromBody]TLocal local)
        {
            local.LocalId = LocalId;
            await repositorio.Save(local);
            return Ok(true);
        }


        // DELETE api/<controller>/5
        [HttpDelete("{LocalId}")]
        public IActionResult Delete(Guid LocalId)
        {
            repositorio.Delete(LocalId);
            return Ok(true);
        }
    }
}
