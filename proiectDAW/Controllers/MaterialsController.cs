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
    public class MaterialsController : ControllerBase
    {
        //controllerul depinde de un manager, manager-ul de un context
        private readonly IMaterialManager _matManager;
        public MaterialsController(IMaterialManager matManager)
        {
            _matManager = matManager;
        }
        [HttpPost("AddMaterial")]
        [Authorize("Admin")]
        public async Task<IActionResult> AddMaterial([FromBody] Material material)
        { 
            if(string.IsNullOrEmpty(material.Name))
            { return BadRequest("Name should not be null!"); }

            _matManager.AddMaterial(material);

            return Ok();
        }
        [HttpDelete("DeleteMaterial")]
        [Authorize("Admin")]
        public async Task<IActionResult> Delete(Material material)
        {
             _matManager.DeleteMaterial(material);
            return Ok();
        }
        [HttpGet("materials/{id}")]
        [Authorize]
        public async Task<IActionResult> GetMaterial([FromRoute] int id)
        {
            //ia materialul cu id-ul dat in ruta (daca exista, daca nu ia pe cel default (aici null))
            
            var material = _matManager.GetMaterial(id);
            return Ok(material);
        }
        [HttpPut]// ?id=1?price=40
        [Authorize("Admin")]
        public async Task<IActionResult> Update([FromQuery] int id, [FromQuery] float price)
        {
            //modifica pretul unui material cu id-ul dat
         
            _matManager.UpdateMaterial(id, price);
            return Ok();
        }

    }
}
