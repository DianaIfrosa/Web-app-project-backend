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
    public class CategoriesController : ControllerBase
    {
        //controllerul depinde de un manager, manager-ul de un context
        private readonly ICategoryManager _categManager;
        public CategoriesController(ICategoryManager categManager)
        {
            _categManager = categManager;
        }

        [HttpGet("GetCategorySelect")]
        public async Task<IActionResult> GetCategoriesSelect()
        {
            var categ = _categManager.CategoriesSelect();
            return Ok(categ);
        }
        [HttpGet("GetCategoryJoin")]
        public async Task<IActionResult> GetCategoriesJoin()
        {
            var join =  _categManager.CategoriesJoin();
            return Ok(join);
        }
        [HttpPost("AddCategory")]
        [Authorize ("Admin")]
        public async Task<IActionResult> AddCategory([FromBody] Category categ)
        {
            if (categ.PopularityScore>10 || categ.PopularityScore<1)
            { return BadRequest("Popularity score should be between 1 and 10!"); }

            _categManager.AddCategory(categ);

            return Ok();
        }
        [HttpDelete("DeleteCategory")]
        [Authorize("Admin")]
        public async Task<IActionResult> DeleteCategory(Category categ)
        {
            _categManager.DeleteCategory(categ);
            return Ok();
        }
        [HttpPut]// ?id=1
        [Authorize("Admin")]
        public async Task<IActionResult> UpdateCategory([FromQuery] int id, [FromBody] Category categ)
        {
            //modifica o categorie cu id-ul dat crescandu-i popularity score cu 1
            _categManager.UpdateCategory(id, categ);
            return Ok();
        }

    }
}
