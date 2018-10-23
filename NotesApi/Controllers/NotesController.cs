using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NotesApi.Data;

namespace NotesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly NoteContext _noteContext;

        public NotesController(NoteContext noteContext)
        {
            _noteContext = noteContext;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAsync()
        {
            var list = await _noteContext.Notes.ToListAsync();
            return Ok(list);
        }


        /// <summary>
        /// An example of how messy it can get without an ORM tooling in place
        /// </summary>
        /// <param name="connection">A valid SqlServer connection</param>
        /// <returns>Collection of Note objects</returns>
        private static IEnumerable<Note> GetList(SqlConnection connection)
        {
            using (connection)
            {
                var list = new List<Note>();
                var command = new SqlCommand("SELECT * FROM Notes;", connection);
                connection.Open();

                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var id = reader.GetInt32(0);
                        var content = reader.GetString(1);
                        list.Add(new Note{Id = id, Content = content});
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                    return null;
                }
                reader.Close();
                return list;
            }
        }

        [HttpGet("{id}")]
        [Route("")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var element = await _noteContext.Notes.FirstOrDefaultAsync(n => n.Id.Equals(id));
            return Ok(element);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> PostAsync([FromBody] Note note)
        {
            await _noteContext.Notes.AddAsync(note);
            await _noteContext.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("{id}")]
        [Route("")]
        public async Task<IActionResult> Put(int id, [FromBody] Note note)
        {
            var element = await _noteContext.Notes.FirstOrDefaultAsync(n => n.Id.Equals(id));
            if (element != null)
                _noteContext.Notes.Update(note);
            else
                return BadRequest("Cannot find element");

            await _noteContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        [Route("")]
        public async Task<IActionResult> Delete(int id)
        {
            var element = await _noteContext.Notes.FirstOrDefaultAsync(n => n.Id.Equals(id));

            if (element != null)
                _noteContext.Notes.Update(element);
            else
                return BadRequest("Cannot find element");

            _noteContext.Notes.Remove(element);
            return Ok();
        }
    }
}
