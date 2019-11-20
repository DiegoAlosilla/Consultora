using ConsultoraAPI.Models.Entities;
using ConsultoraAPI.Models.Service;
using ConsultoraAPI.Models.ServiceImpl;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsultoraAPI.Controllers
{
    [Route("api/usuario")]
    [ApiController]
    public class UsuarioController : Controller
    {
        private IUsuarioService usuarioService;
        

        public UsuarioController()
        {
            this.usuarioService = new UsuarioService();
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Usuario>> Get()
        {
            var usuarios = usuarioService.FindAll();
            return usuarios.ToList();
        }

        // GET api/values/5
        [HttpGet("get/{id}")]
        public ActionResult<Usuario> GetById(int id)
        {
            var usuario = usuarioService.FindById(id);
            return usuario;
        }

        // POST api/values
        [HttpPost("create")]
        public ActionResult Post([FromBody] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                usuarioService.Save(usuario);
                return Ok(new CreatedAtRouteResult("create Usuario", new { id = usuario.Id }, usuario));
            }
            return BadRequest(ModelState);
        }

        // PUT api/values/5
        [HttpPut("update/{id}")]
        public ActionResult Put(int id, [FromBody] Usuario usuario)
        {
            if (usuario.Id != id)
            {
                return BadRequest();
            }
            usuarioService.Update(usuario);
            return View(usuario);
        }

        // DELETE api/values/5
        [HttpDelete("delete/{id}")]
        public ActionResult Delete(int id)
        {
            var usuario = usuarioService.FindById(id);
            if (usuario == null)
            {
                return NotFound();
            }
            usuarioService.Delete(id);
            return View();
        }

    }
}