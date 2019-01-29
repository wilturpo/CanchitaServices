using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;
using Application.IServices;
using Domain;
using Domain.IRepositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CanchitaServices.Controllers
{
    [Route("api/[controller]")]
    public class CanchaController : Controller
    {
        private ICanchaService Service;
        public CanchaController(ICanchaService service)
        {
            Service = service;
        }
        // GET: api/<controller>
        [HttpGet]
        public IList<CanchaDTO> Get()
        {
            return Service.GetAll();
        }

        // GET api/<controller>/5
        [HttpGet("{CanchaId}")]

        public CanchaDTO Get(Guid CanchaId)
        {

            return Service.GetAll().Where(p => p.CanchaId == CanchaId).FirstOrDefault();
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CanchaDTO cancha)
        {
            await Service.Insert(cancha);
            return Ok(true);
        }

        // PUT api/<controller>/5
        [HttpPut("{CanchaId}")]
        public async Task<IActionResult> Put(Guid CanchaId, [FromBody]CanchaDTO cancha)
        {
            cancha.CanchaId = CanchaId;
            await Service.Insert(cancha);
            return Ok(true);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{CanchaId}")]
        public IActionResult Delete(Guid CanchaId)
        {
            Service.Delete(CanchaId);
            return Ok(true);
        }
    }
}
