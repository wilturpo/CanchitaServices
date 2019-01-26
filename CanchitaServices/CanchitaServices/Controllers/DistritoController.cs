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
    public class DistritoController : Controller
    {
        private IDistritoRepository repositorio;
        public DistritoController(IDistritoRepository repo)
        {
            repositorio = repo;
        }
        // GET: api/<controller>
        [HttpGet]
        public IQueryable<TDistrito> Get()
        {
            return repositorio.Items;
        }

        // GET api/<controller>/5
        [HttpGet("{DistritoId}")]
        public TDistrito Get(Guid DistritoId)
        {
            return repositorio.Items.Where(p => p.DistId == DistritoId).FirstOrDefault();
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]TDistrito distrito)
        {
            await repositorio.Save(distrito);
            return Ok(true);
        }

        // PUT api/<controller>/5
        [HttpPut("{DistritoId}")]
        public async Task<IActionResult> Put(Guid DistritoId, [FromBody]TDistrito distrito)
        {
            distrito.DistId = DistritoId;
            await repositorio.Save(distrito);
            return Ok(true);
        }


        // DELETE api/<controller>/5
        [HttpDelete("{DistritoId}")]
        public IActionResult Delete(Guid DistritoId)
        {
            repositorio.Delete(DistritoId);
            return Ok(true);
        }
    }
}
