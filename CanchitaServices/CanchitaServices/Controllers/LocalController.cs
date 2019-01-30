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
    public class LocalController : Controller
    {
        private ILocalService Service;
        public LocalController(ILocalService service)
        {
            Service = service;
        }
        // GET: api/<controller>
        [HttpGet]
        public IList<LocalDTO> Get()
        {
            return Service.GetAll();
        }

        // GET api/<controller>/5
        [HttpGet("{LocalId}")]

        public LocalDTO Get(Guid LocalId)
        {

            return Service.GetAll().Where(p => p.LocalId == LocalId).FirstOrDefault();
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]LocalDTO local)
        {
            //await Service.Insert(local);
            //return Ok(true);
            if (!ModelState.IsValid)
            {
                throw new Exception("Model is not Valid");
            }
            await Service.Insert(local);
            return Ok(true);
        }

        // PUT api/<controller>/5
        [HttpPut("{LocalId}")]
        public async Task<IActionResult> Put(Guid LocalId, [FromBody]LocalDTO local)
        {
            local.LocalId = LocalId;
            await Service.Insert(local);
            return Ok(true);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{LocalId}")]
        public IActionResult Delete(Guid LocalId)
        {
            Service.Delete(LocalId);
            return Ok(true);
        }
    }
}
