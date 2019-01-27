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
    public class DepartamentoController : Controller
    {
        private IDepartamentoServices Service;
        public DepartamentoController(IDepartamentoServices service)
        {
            Service = service;
        }
        // GET: api/<controller>
        [HttpGet]
        public IList<DepartamentoDTO> Get()
        {
            return Service.GetAll();
        }

        // GET api/<controller>/5
        [HttpGet("{DepartamentoId}")]

        public DepartamentoDTO Get(Guid DepartamentoId)
        {

            return Service.GetAll().Where(p => p.DptoId == DepartamentoId).FirstOrDefault();
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]DepartamentoDTO departamento)
        {
            await Service.Insert(departamento);
            return Ok(true);
        }

        // PUT api/<controller>/5
        [HttpPut("{DepartamentoId}")]
        public async Task<IActionResult> Put(Guid DepartamentoId, [FromBody]DepartamentoDTO departamento)
        {
            departamento.DptoId = DepartamentoId;
            await Service.Insert(departamento);
            return Ok(true);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{DepartamentoId}")]
        public IActionResult Delete(Guid DepartamentoId)
        {
            Service.Delete(DepartamentoId);
            return Ok(true);
        }

    }
}
