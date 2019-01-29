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
    public class PrecioController : Controller
    {
        private IPrecioRepository repositorio;
        public PrecioController(IPrecioRepository repo)
        {
            repositorio = repo;
        }
        // GET: api/<controller>
        [HttpGet]
        public IQueryable<TPrecio> Get()
        {
            return repositorio.Items;
        }

        // GET api/<controller>/5
        [HttpGet("{PrecioId}")]
        public TPrecio Get(Guid PrecioId)
        {
            return repositorio.Items.Where(p => p.PrecId == PrecioId).FirstOrDefault();
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]TPrecio precio)
        {
            await repositorio.Save(precio);
            return Ok(true);
        }

        // PUT api/<controller>/5
        [HttpPut("{PrecioId}")]
        public async Task<IActionResult> Put(Guid PrecioId, [FromBody]TPrecio precio)
        {
            precio.PrecId = PrecioId;
            await repositorio.Save(precio);
            return Ok(true);
        }


        // DELETE api/<controller>/5
        [HttpDelete("{PrecioId}")]
        public IActionResult Delete(Guid PrecioId)
        {
            repositorio.Delete(PrecioId);
            return Ok(true);
        }
    }
}
