using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebCosultora.API;
using WebCosultora.Models;


//https://www.tutorialsteacher.com/webapi/implement-get-method-in-web-api

namespace WebCosultora.Controllers
{
    public class ProyectoController : Controller
    {

        ConsultoraAPI client = new ConsultoraAPI();

        // GET: Proyectos
        public ActionResult Index()
        {
            IEnumerable<Proyecto> proyectos = null;
            var response = client.Initial().GetAsync("proyecto");
            response.Wait();
            var result = response.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<Proyecto>>();
                readTask.Wait();
                proyectos = readTask.Result;
            }
            else //web api sent error response 
            {
                proyectos = Enumerable.Empty<Proyecto>();
                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
            }

            return View(proyectos);
        }

        // GET: Proyecto/Details/5
        public ActionResult Details(int id)
        {
            Proyecto proyecto = new Proyecto();
            var responseTask = client.Initial().GetAsync("proyecto/get/"+id.ToString());
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<Proyecto>();
                readTask.Wait();
                proyecto = readTask.Result;
            }
            return View(proyecto);
        }

        // GET: Proyecto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Proyecto/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Proyecto proyecto)
        {
            var postTask = client.Initial().PostAsJsonAsync("proyecto/create", proyecto);
            postTask.Wait();
            var result = postTask.Result;
            if(result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
            return View(proyecto);
        }

        // GET: Proyecto/Edit/5
        public ActionResult Edit(int? id)
        {
            Proyecto proyecto = new Proyecto();
            var responseTask = client.Initial().GetAsync($"proyecto/get/{id}");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<Proyecto>();
                readTask.Wait();
                proyecto = readTask.Result;
            }
            return View(proyecto);
        }

        // POST: Proyecto/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Proyecto proyecto)
        {

            var putTask = client.Initial().PutAsJsonAsync("proyecto/update/" + proyecto.Id.ToString(), proyecto);
            putTask.Wait();
            var result = putTask.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(proyecto);

        }

        // GET: Proyecto/Delete/5
        public ActionResult Delete(int id)
        {
            Proyecto proyecto = new Proyecto();
            var responseTask = client.Initial().GetAsync($"proyecto/get/{id}");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<Proyecto>();
                readTask.Wait();
                proyecto = readTask.Result;
            }
            return View(proyecto);
        }

        // POST: Proyecto/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Proyecto proyecto)
        {
            var responseTask = client.Initial().DeleteAsync($"proyecto/delete/{id}");
            responseTask.Wait();          
            return RedirectToAction("Index");
        }
    }
}