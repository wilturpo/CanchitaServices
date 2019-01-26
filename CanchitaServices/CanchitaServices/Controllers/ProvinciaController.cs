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
    public class ProvinciaController : Controller
    {
        private IProvinciaRepository repositorio;
        public ProvinciaController(IProvinciaRepository repo)
        {
            repositorio = repo;
        }
        // GET: api/<controller>
        [HttpGet]
        public IQueryable<TProvincia> Get()
        {
            return repositorio.Items;
        }

        // GET api/<controller>/5
        [HttpGet("{ProvinciaId}")]
        public TProvincia Get(Guid ProvinciaId)
        {
            return repositorio.Items.Where(p => p.ProvId == ProvinciaId).FirstOrDefault();
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]TProvincia provincia)
        {
            await repositorio.Save(provincia);
            return Ok(true);
        }

        // PUT api/<controller>/5
        [HttpPut("{ProvinciaId}")]
        public async Task<IActionResult> Put(Guid ProvinciaId, [FromBody]TProvincia provincia)
        {
            provincia.ProvId = ProvinciaId;
            await repositorio.Save(provincia);
            return Ok(true);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{ProvinciaId}")]
        public IActionResult Delete(Guid ProvinciaId)
        {
            repositorio.Delete(ProvinciaId);
            return Ok(true);
        }
    }
}
