using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using exercise.Context;
using exercise.Models;
using System.Data;

namespace exercise.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class UserController : ControllerBase
    {
        private ContextAPI db;
        public UserController()
        {
            this.db = new ContextAPI();
        }

        [HttpGet]
        public async Task<ActionResult<List<Habitante>>> Get()
        {
            try
            {
                List<Habitante> habitantes = this.db.Habitantes.ToList();
                return habitantes;
            }
            catch(Exception ex)
            {
                return NotFound();
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Habitante>> Get(long id)
        {
            try
            {
                Habitante habitante = await this.db.Habitantes.FindAsync(id);

                if (id == 0)
                {
                    throw new Exception("Invalid ID");
                }
                else if (habitante == null)
                {
                    return NotFound();
                }
                else
                {
                    return habitante;
                }
            }
            catch(Exception ex)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Habitante habitante)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else if (habitante == null)
            {
                return NotFound();
            }
            this.db.Habitantes.Add(habitante);
            await db.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            Habitante habitante = await this.db.Habitantes.FindAsync(id);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else if (id == 0)
            {
                return BadRequest();
            }
            else if (habitante == null)
            {
                return NotFound();
            }
            this.db.Habitantes.Remove(habitante);
            await db.SaveChangesAsync();
            
            return NoContent();
        }
    }
}