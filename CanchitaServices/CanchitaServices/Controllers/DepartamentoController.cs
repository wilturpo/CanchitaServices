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
    public class DepartamentoController : Controller
    {
        private IDepartamentoRepository repositorio;
        public DepartamentoController(IDepartamentoRepository repo)
        {
            repositorio = repo;
        }    
        // GET: api/<controller>
        [HttpGet]
        public IQueryable<TDepartamento> Get()
        {
            return repositorio.Items;
        }

        // GET api/<controller>/5
        [HttpGet("{DepartamentoId}")]
        public TDepartamento Get(Guid DepartamentoId)
        {
            return repositorio.Items.Where(p => p.DptoId == DepartamentoId).FirstOrDefault();
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]TDepartamento departamento)
        {
            await repositorio.Save(departamento);
            return Ok(true);
        }

        // PUT api/<controller>/5
        [HttpPut("{DepartamentoId}")]
        public async Task<IActionResult> Put(Guid DepartamentoId, [FromBody]TDepartamento departamento)
        {
            departamento.DptoId = DepartamentoId;
            await repositorio.Save(departamento);
            return Ok(true);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{DepartamentoId}")]
        public IActionResult Delete(Guid DepartamentoId)
        {
            repositorio.Delete(DepartamentoId);
            return Ok(true);
        }
    }
}
