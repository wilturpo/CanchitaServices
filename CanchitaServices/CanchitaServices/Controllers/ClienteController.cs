using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;
using Application.IServices;
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
        private IClienteService Service;
        public ClienteController(IClienteService service)
        {
            Service = service;
        }
        // GET: api/<controller>
        [HttpGet]
        public IList<ClienteDTO> Get()
        {
            return Service.GetAll();
        }

        // GET api/<controller>/5
        [HttpGet("{ClienteId}")]

        public ClienteDTO Get(Guid ClienteId)
        {

            return Service.GetAll().Where(p => p.CliId == ClienteId).FirstOrDefault();
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]ClienteDTO cliente)
        {
            await Service.Insert(cliente);
            return Ok(true);
        }

        // PUT api/<controller>/5
        [HttpPut("{ClienteId}")]
        public async Task<IActionResult> Put(Guid ClienteId, [FromBody]ClienteDTO cliente)
        {
            cliente.CliId = ClienteId;
            await Service.Insert(cliente);
            return Ok(true);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{ClienteId}")]
        public IActionResult Delete(Guid ClienteId)
        {
            Service.Delete(ClienteId);
            return Ok(true);
        }
    }
}




