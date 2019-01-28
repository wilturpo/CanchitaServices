using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;
using Application.IServices;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CanchitaServices.Controllers
{
    [Route("api/[controller]")]
    public class ImagenController : Controller
    {
        private IImagenService Service;
        public ImagenController(IImagenService service)
        {
            Service = service;
        }
        // GET: api/<controller>
        [HttpGet]
        public IList<ImagenDTO> Get()
        {
            return Service.GetAll();
        }

        // GET api/<controller>/5
        [HttpGet("{ImagenId}")]

        public ImagenDTO Get(Guid ImagenId)
        {

            return Service.GetAll().Where(p => p.ImaId == ImagenId).FirstOrDefault();
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]ImagenDTO imagen)
        {
            await Service.Insert(imagen);
            return Ok(true);
        }

        // PUT api/<controller>/5
        [HttpPut("{ImagenId}")]
        public async Task<IActionResult> Put(Guid ImagenId, [FromBody]ImagenDTO imagen)
        {
            imagen.ImaId = ImagenId;
            await Service.Insert(imagen);
            return Ok(true);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{ImagenId}")]
        public IActionResult Delete(Guid DepartamentoId)
        {
            Service.Delete(DepartamentoId);
            return Ok(true);
        }

    }
}
