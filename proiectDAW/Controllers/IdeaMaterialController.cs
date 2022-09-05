using Microsoft.AspNetCore.Authorization;
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
    public class IdeaMaterialController : ControllerBase
    {
        //controllerul depinde de un manager, manager-ul de un context
        private readonly IIdeaMaterialManager _ideamManager;
        public IdeaMaterialController(IIdeaMaterialManager ideamManager)
        {
            _ideamManager = ideamManager;
        }

        [HttpGet("GetGroupBy")] // ?id=1
        [Authorize]
        public async Task<IActionResult> GetGroupBy()
        {
            //afiseaza pentru fiecare idee  cate materiale sunt necesare
            _ideamManager.GetGroupBy();

            return Ok();
        }
        [HttpDelete("DeleteIdeaMaterial")]
        [Authorize("Admin")]
        public async Task<IActionResult> Delete(IdeaMaterial obj)
        {
            _ideamManager.DeleteIdeaM(obj);
            return Ok();
        }

        [HttpPost("AddDIYIdeaMaterial")]
        [Authorize("Admin")]
        public async Task<IActionResult> AddDIYIdeaMaterial([FromBody] IdeaMaterial im)
        {
            _ideamManager.AddIdeaM(im);
            return Ok();
        }
        [HttpPut("ideamaterial/modify/{new_number}")]
        [Authorize("Admin")]
        public async Task<IActionResult> Update([FromBody] IdeaMaterial im, [FromRoute]int new_number)
        {
            //modifica numarul de bucati dintr-un material cu cel dat 
            if(new_number<=0)
            { return BadRequest("Number of pieces should be positive!"); }
            
            _ideamManager.UpdateIdeaM(im, new_number);

            return Ok();
        }

    }
}
