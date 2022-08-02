using commonLayer.model;
using repoLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace repoLayer.Interface
{
    public interface INoteRL
    {
        public NoteEntity AddNote(NoteModel note, long userId);
        public  bool isDeletedNote(long noteid);
        public NoteEntity UpdateNote(NoteModel note, long noteid);
        
        public NoteEntity isPin(long noteid);
        public NoteEntity isArchieved(long noteid);
        public NoteEntity Color(long noteid, string color);

        //public NoteEntity UploadImage(long noteid, IFormFile img);
        /* public NoteEntity Color(NoteModel note, long userId);
         public NoteEntity Trash(NoteModel note, long userId);
         public NoteEntity Upload(NoteModel note, long userId);
         public NoteEntity ByUser(NoteModel note, long userId);
         public NoteEntity AllNotes(NoteModel note, long userId);*/

    }
}
