using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Consultora.Data;
using Consultora.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Consultora.Controllers
{

    [Route("api/proyecto")]
    [ApiController]
    public class ProyectoController : ControllerBase
    {
        private readonly ProyectosDAO _repository;

        public ProyectoController(ProyectosDAO repository)
        {
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }


        // GET api/proyecto
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Proyecto>>> Get()
        {
            return await _repository.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Proyecto>> Get(int id)
        {
            var response = await _repository.GetById(id);
            if (response == null) { return NotFound(); }
            return response;
        }

        // POST api/values
        [HttpPost]
        public async Task Post([FromBody] Proyecto value)
        {
            await _repository.Insert(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task Put([FromRoute] int id,[FromBody] Proyecto value)
        {
            await _repository.Update(value);

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _repository.DeleteById(id);
        }
    }
}