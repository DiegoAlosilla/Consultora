using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsultoraAPI.Models.Entities;
using ConsultoraAPI.Models.Service;
using ConsultoraAPI.Models.ServiceImpl;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConsultoraAPI.Controllers
{
    [Route("api/proyecto")]
    [ApiController]
    public class ProyectoController : Controller
    {
        private IProyectoService proyectoService;

        public ProyectoController()
        {
            this.proyectoService = new ProyectoService();
        }

        // GET api/values
        [HttpGet]        
        public ActionResult<IEnumerable<Proyecto>> Get()
        {
            var proyectos = proyectoService.FindAll();
            return proyectos.ToList();
        }

        // GET api/values/5
        [HttpGet("get/{id}")]
        public ActionResult<Proyecto> GetById(int id)
        {
            var proyecto = proyectoService.FindById(id);
            return proyecto;
        }

        // POST api/values
        [HttpPost("create")]
        public ActionResult Post([FromBody] Proyecto proyecto)
        {
            if (ModelState.IsValid)
            {
                proyectoService.Save(proyecto);
                return Ok(new CreatedAtRouteResult("create Proyecto", new { id = proyecto.Id }, proyecto));
            }
            return BadRequest(ModelState);
        }

        // PUT api/values/5
        [HttpPut("update/{id}")]
        public ActionResult Put(int id, [FromBody] Proyecto proyecto)
        {
            if(proyecto.Id != id)
            {
                return BadRequest();
            }
            proyectoService.Update(proyecto);
            return View(proyecto);
        }

        // DELETE api/values/5
        [HttpDelete("delete/{id}")]
        public ActionResult Delete(int id)
        {
            var proyecto = proyectoService.FindById(id);
            if(proyecto == null)
            {
                return NotFound();
            }
            proyectoService.Delete(id);
            return View();
        }

    }
}