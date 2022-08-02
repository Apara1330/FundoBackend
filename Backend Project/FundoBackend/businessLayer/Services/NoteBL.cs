using businessLayer.Interface;
using commonLayer.model;
using repoLayer.Entity;
using repoLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace businessLayer.Services
{
    public class NoteBL : INoteBL
    {
        INoteRL noteRL;
        public NoteBL(INoteRL noteRL)
        {
            this.noteRL = noteRL;
        }

        public NoteEntity AddNote(NoteModel note, long userId)
        {
            try
            {
                return noteRL.AddNote(note,userId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool isDeletedNote(long noteid)
        {
            try
            {
                return noteRL.isDeletedNote(noteid);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public NoteEntity UpdateNote(NoteModel note, long noteid)
        {
            try
            {
                return noteRL.UpdateNote(note, noteid);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public NoteEntity isPinORNot(long noteid)
        {
            try
            {
                return this.noteRL.isPin(noteid);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public NoteEntity isArchieved(long noteid)
        {
            try
            {
                return noteRL.isArchieved(noteid);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public NoteEntity Color(long noteid, string color)
        {
            try
            {
                return this.noteRL.Color(noteid, color);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /*public NoteEntity UploadImage(long noteid, IFormFile img)
        {
            try
            {
                return this.noterl.UploadImage(noteid, img);
            }
            catch (Exception)
            {

                throw;
            }
        }*/


        /*
        public NoteEntity Upload(NoteModel note1)
        {
            throw new NotImplementedException();
        }*/
    }
}
