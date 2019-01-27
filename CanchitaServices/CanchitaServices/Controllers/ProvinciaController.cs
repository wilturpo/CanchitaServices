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
    public class ProvinciaController : Controller
    {
        private IProvinciaService Service;
        public ProvinciaController(IProvinciaService service)
        {
            Service = service;
        }
        // GET: api/<controller>
        [HttpGet]
        public IList<ProvinciaDTO> Get()
        {
            return Service.GetAll();
        }

        // GET api/<controller>/5
        [HttpGet("{ProvinciaId}")]

        public ProvinciaDTO Get(Guid ProvinciaId)
        {
            return Service.GetAll().Where(p => p.ProvId == ProvinciaId).FirstOrDefault();
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]ProvinciaDTO provincia)
        {
            await Service.Insert(provincia);
            return Ok(true);
        }

        // PUT api/<controller>/5
        [HttpPut("{ProvinciaId}")]
        public async Task<IActionResult> Put(Guid ProvinciaId, [FromBody]ProvinciaDTO provincia)
        {
            provincia.ProvId = ProvinciaId;
            await Service.Insert(provincia);
            return Ok(true);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{ProvinciaId}")]
        public IActionResult Delete(Guid ProvinciaId)
        {
            Service.Delete(ProvinciaId);
            return Ok(true);
        }
    }
}
