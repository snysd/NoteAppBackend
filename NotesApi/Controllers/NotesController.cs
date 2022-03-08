using NotesApi.Models;
using NotesApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace NotesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly NoteService _noteService;

        public NotesController(NoteService noteService)
        {
            _noteService = noteService;
        }

        [HttpGet]
        public ActionResult<List<Note>> Get() =>
            _noteService.Get();

        [HttpGet("{id:length(24)}", Name = "GetNote")]
        public ActionResult<Note> Get(string id)
        {
            var note = _noteService.Get(id);

            if (note == null)
            {
                return NotFound();
            }

            return note;
        }

        [HttpPost]
        public ActionResult<List<Note>> Create(Note note)
        {
            _noteService.Create(note);

            return _noteService.Get();
        }

        [HttpPut("{id:length(24)}")]
        public ActionResult<List<Note>> Update(string id, Note noteIn)
        {
            var note = _noteService.Get(id);

            if (note == null)
            {
                return NotFound();
            }

            _noteService.Update(id, noteIn);

            return _noteService.Get();
        }

        [HttpDelete("{id:length(24)}")]
        public ActionResult<List<Note>> Delete(string id)
        {
            var note = _noteService.Get(id);

            if (note == null)
            {
                return NotFound();
            }

            _noteService.Remove(note.Id);

            return _noteService.Get();
        }
    }
}