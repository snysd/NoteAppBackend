using NotesApi.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace NotesApi.Services
{
    public class NoteService
    {
        private readonly IMongoCollection<Note> _notes;

        public NoteService(INoteDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _notes = database.GetCollection<Note>(settings.NotesCollectionName);
        }

        public List<Note> Get()
        {
            var val = _notes.Find(book => true).ToList();
            return val;
        }
            

        public Note Get(string id) =>
            _notes.Find<Note>(note => note.Id == id).FirstOrDefault();

        public Note Create(Note note)
        {
            _notes.InsertOne(note);
            return note;
        }

        public void Update(string id, Note noteIn) =>
            _notes.ReplaceOne(note => note.Id == id, noteIn);

        public void Remove(Note noteIn) =>
            _notes.DeleteOne(note => note.Id == noteIn.Id);

        public void Remove(string id) => 
            _notes.DeleteOne(note => note.Id == id);
    }
}