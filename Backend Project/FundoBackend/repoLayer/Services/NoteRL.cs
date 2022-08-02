using commonLayer.model;
using Microsoft.Extensions.Configuration;
using repoLayer.Context;
using repoLayer.Entity;
using repoLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace repoLayer.Services
{
    public class NoteRL : INoteRL
    {
        Fundo fundoContext;
        //private readonly string key;
        //public  string _secret;
        //public  string _expDate;

        private readonly IConfiguration config;

        public NoteRL(Fundo fundooContext, IConfiguration config)
        {
            this.fundoContext = fundooContext;
            this.config = config;
        }

        public NoteEntity AddNote(NoteModel note, long userId)
        {
            try
            {
                NoteEntity noteEntity = new NoteEntity();
                
                noteEntity.title = note.title;
                noteEntity.description = note.description;
                noteEntity.reminder = note.reminder;
                noteEntity.color = note.color;
                noteEntity.image = note.image;
                noteEntity.IsArchieved = note.IsArchieved;
                noteEntity.isPinned = note.isPinned;
                noteEntity.isDeleted = note.isDeleted;//trash
                noteEntity.createdAt = note.createdAt;
                noteEntity.editedAt = note.editedAt;
                noteEntity.UserId = userId;
                
               

                fundoContext.NotesTable.Add(noteEntity);
                int result = fundoContext.SaveChanges();
                if (result > 0)
                {
                    return noteEntity;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool isDeletedNote(long noteid)
        {
            try
            {
                var result = this.fundoContext.NotesTable.FirstOrDefault(x => x.noteid == noteid);
                fundoContext.Remove(result);
                int deletednote = this.fundoContext.SaveChanges();
                if (deletednote > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        
        public NoteEntity UpdateNote(NoteModel noteEntity, long noteid)
        {
            try
            {
                NoteEntity note = this.fundoContext.NotesTable.Where(u => u.noteid == noteid).FirstOrDefault();
                if (note != null)
                {
                    note.title = note.title;
                    note.color = note.color;
                    note.image = note.image;
                    //note.isArchieved = note.isArchieved;
                    note.isPinned = note.isPinned;
                    note.isDeleted = note.isDeleted;//trash
                  
                    this.fundoContext.NotesTable.Update(note);
                    this.fundoContext.SaveChanges();
                    return note;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

   
        public NoteEntity isPin(long noteid)
        {
            try
            {
                NoteEntity result = this.fundoContext.NotesTable.FirstOrDefault(x => x.noteid == noteid);
                if (result.isPinned == true)
                {
                    result.isPinned = false;
                    this.fundoContext.SaveChanges();
                    return result;
                }
                result.isPinned = true;
                this.fundoContext.SaveChanges();
                return null;
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
                NoteEntity result = this.fundoContext.NotesTable.FirstOrDefault(x => x.noteid == noteid);
                if (result.IsArchieved == true)
                {
                    result.IsArchieved = false;
                    this.fundoContext.SaveChanges();
                    return result;
                }
                result.IsArchieved = true;
                this.fundoContext.SaveChanges();
                return null;
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
                NoteEntity note = this.fundoContext.NotesTable.FirstOrDefault(x => x.noteid == noteid);
                if (note.color != null)
                {
                    note.color = color;
                    this.fundoContext.SaveChanges();
                    return note;
                }
                return null;
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
                var noteId = this.context.Notes.FirstOrDefault(e => e.NoteID == noteid);
                if (noteId != null)
                {
                    Account acc = new Account(CLOUD_NAME, API_KEY, API_Secret);
                    cloud = new Cloudinary(acc);
                    var imagePath = img.OpenReadStream();
                    var uploadParams = new ImageUploadParams()
                    {
                        File = new FileDescription(img.FileName, imagePath)
                    };
                    var uploadresult = cloud.Upload(uploadParams);
                    noteId.Image = img.FileName;
                    context.Notes.Update(noteId);
                    int upload = context.SaveChanges();
                    if (upload > 0)
                    {
                        return noteId;
                    }
                }
                return null;

            }
            catch (Exception)
            {

                throw;
            }
        }*/
    }
}


       /*public NoteEntity Trash(NoteModel note, long userId)
       {
           try
           {
               NoteEntity noteEntity = new NoteEntity();

               noteEntity.title = note.title;
               noteEntity.description = note.description;
               noteEntity.reminder = note.reminder;
               noteEntity.color = note.color;
               noteEntity.image = note.image;
               noteEntity.isArchieved = note.isArchieved;
               noteEntity.isPinned = note.isPinned;
               noteEntity.isDeleted = note.isDeleted;
               noteEntity.createdAt = note.createdAt;
               noteEntity.editedAt = note.editedAt;
               noteEntity.UserId = userId;



               fundoContext.NotesTable.Remove(noteEntity);
               int result = fundoContext.SaveChanges();
               if (result > 0)
               {
                   return noteEntity;
               }
               else
               {
                   return null;
               }
           }
           catch (Exception ex)
           {

               throw ex;
           }
       }



public NoteEntity ByUser(NoteModel note, long userId)
{
    throw new NotImplementedException();
}

public NoteEntity AllNotes(NoteModel note, long userId)
{
    throw new NotImplementedException();
}*/


