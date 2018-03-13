using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using Model;

namespace Mango.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class PersonaController : Controller
    {

        private readonly IPersonaService _personaService;

        public PersonaController(IPersonaService personaService)
        {
            _personaService = personaService;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Json(
                _personaService.GetAll()
                );
        }




        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Json(
                _personaService.Get(id)
             );
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Persona Model)
        {
            return Json(
                _personaService.Add(Model)
             );

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Persona model)
        {
            return Json(
               _personaService.Add(model)
            );
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Json(
              _personaService.Delete(id)
           );
        }


    }
}