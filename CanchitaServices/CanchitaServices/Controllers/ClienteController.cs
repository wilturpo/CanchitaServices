using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CanchitaServices.Models.Repositories;
using Domain;
using Domain.IRepositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CanchitaServices.Controllers
{
    [Route("api/[controller]")]
    public class ClienteController : Controller
    {
        private IClienteRepository repositorio;
        public ClienteController(IClienteRepository repo)
        {
            repositorio = repo;
        }
        // GET: api/<controller>
        [HttpGet]
        public IQueryable<TCliente> Get()
        {
            return repositorio.Items;
        }

        // GET api/<controller>/5
        [HttpGet("{ClienteId}")]
        public TCliente Get(Guid ClienteId)
        {
            return repositorio.Items.Where(p => p.CliId == ClienteId).FirstOrDefault();
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]TCliente cliente)
        {
            await repositorio.Save(cliente);
            return Ok(true);
        }

        // PUT api/<controller>/5
        [HttpPut("{ClienteId}")]
        public async Task<IActionResult> Put(Guid ClienteId, [FromBody]TCliente cliente)
        {
            cliente.CliId = ClienteId;
            await repositorio.Save(cliente);
            return Ok(true);
        }


        // DELETE api/<controller>/5
        [HttpDelete("{ClienteId}")]
        public IActionResult Delete(Guid ClienteId)
        {
            repositorio.Delete(ClienteId);
            return Ok(true);
        }
    }
}
