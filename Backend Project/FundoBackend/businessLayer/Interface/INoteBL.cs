using commonLayer.model;
using repoLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace businessLayer.Interface
{
    public interface INoteBL
    {
        public NoteEntity AddNote(NoteModel note, long userId);

        public bool isDeletedNote(long noteid);
        public NoteEntity UpdateNote(NoteModel note, long noteid);
        public NoteEntity isPinORNot(long noteid);
        public NoteEntity isArchieved(long noteid);
        public NoteEntity Color(long noteid, string color);

        //public NoteEntity UploadImage(long noteid, IFormFile img);

        //public NoteEntity Upload(NoteModel note1);


    }
}
