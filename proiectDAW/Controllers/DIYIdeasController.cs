using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using proiectDAW.BLL.Interfaces;
using proiectDAW.DAL;
using proiectDAW.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proiectDAW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DIYIdeasController : ControllerBase
    {
        //controllerul depinde de un manager, manager-ul de un context
        private readonly IDIYIdeaManager _ideaManager;
        public DIYIdeasController( IDIYIdeaManager ideaManager)
        {
            _ideaManager = ideaManager;
        }
        [EnableCors()]
        [HttpGet("ShowIdeas")]
        public async Task<IActionResult> GetShowDIYIdea()
        {
            var list = await _ideaManager.ShowDIYIdea();
            return Ok(list);
        }

        [HttpGet("ideas/{id}")]
        // [Authorize]
        public async Task<IActionResult> GetIdea([FromRoute] int id)
        {
            var idea=  _ideaManager.GetIdea(id);
            //ia ideea cu id-ul dat in ruta (daca exista, daca nu ia pe cel default (aici null))
            return Ok(idea);
        }
        [HttpGet("GetPopularIdeas")]
        public async Task<IActionResult> GetPopularIdeas()
        {
            //selecteaza ideile care se afla intr-o categorie populara (score>=8) sortate descresc dupa score
            var ideas = _ideaManager.GetPopularIdeas();
            
            return Ok(ideas);
        }

        [HttpPost("AddDIYIdea")]
        [Authorize("Admin")]
        public async Task<IActionResult> AddDIYIdea([FromBody] DIYIdea idea)
        {
            if (idea.Time>180) //nu pot adauga idei care dureaza mai mult de 3 ore
            { return BadRequest("Allocated time should be less than 3 hours!"); }
            else if (idea.Description.Length<30) //sau care au descriere prea scurta
            { return BadRequest("Description should be more complex!"); }

            _ideaManager.AddDIYIdea(idea);
            
            return Ok();
        }
        [HttpDelete("DeleteDIYIdea")]
        [Authorize("Admin")]
        public async Task<IActionResult> DeleteIdea(DIYIdea idea)
        {
            _ideaManager.DeleteIdea(idea);
            return Ok();
        }
        [HttpPut]// ?id=1
        [Authorize("Admin")]
        public async Task<IActionResult> UpdateIdea([FromQuery] int id, [FromBody] DIYIdea idea)
        {
            //modifica o idee cu id-ul dat
            _ideaManager.UpdateIdea(id, idea);
            return Ok();
        }
    }
}
