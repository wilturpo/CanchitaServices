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
    public class DistritoController : Controller
    {
        private IDistritoService Service;
        public DistritoController(IDistritoService service)
        {
            Service = service;
        }
        // GET: api/<controller>
        [HttpGet]
        public IList<DistritoDTO> Get()
        {
            return Service.GetAll();
        }

        // GET api/<controller>/5
        [HttpGet("{DistritoId}")]

        public DistritoDTO Get(Guid DistritoId)
        {

            return Service.GetAll().Where(p => p.DistId == DistritoId).FirstOrDefault();
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]DistritoDTO distrito)
        {
            await Service.Insert(distrito);
            return Ok(true);
        }

        // PUT api/<controller>/5
        [HttpPut("{DistritoId}")]
        public async Task<IActionResult> Put(Guid DistritoId, [FromBody]DistritoDTO distrito)
        {
            distrito.DistId = DistritoId;
            await Service.Insert(distrito);
            return Ok(true);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{DistritoId}")]
        public IActionResult Delete(Guid DistritoId)
        {
            Service.Delete(DistritoId);
            return Ok(true);
        }
    }
}
