using businessLayer.Interface;
using commonLayer.model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace FundoBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        INoteBL note;

        public NotesController(INoteBL note)
        {
            this.note = note;
        }
        [Authorize]
        [HttpPost("AddNote")]
         public IActionResult AddNotes(NoteModel note1)
        {
            try
            {
                long userid = Convert.ToInt32(User.Claims.First(e => e.Type == "id").Value); //to claim UserID
                var result = note.AddNote(note1,userid);
                if (result != null)
                {
                    return this.Ok(new
                    {
                        success = true,
                        message = "Note is added Successfull",
                        response = result
                    });
                }
                else
                {
                    return this.BadRequest(new
                    {
                        success = false,
                        message = "Unable to add note",

                    });
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpDelete("DeleteNote")]
        public IActionResult DeleteNotes(long note1)
        {
            try
            {
                if (note.isDeletedNote(note1))
                {
                    return this.Ok(new { Success = true, message = "Note Deleted Successfully" });
                }
                else
                {
                    return this.Ok(new { Success = false, message = "Unable to delete note" });
                }
            }
            catch (Exception ex)
            {
                return this.BadRequest(new { Success = false, message = ex.Message });
            }
        }


        [Authorize]
        [HttpPut("UpdateNote")]
        public IActionResult UpdateNotes(NoteModel note1, long noteid)
        {
            try
            {
                //long userid = Convert.ToInt32(User.Claims.First(e => e.Type == "id").Value); //to claim UserID
                var result = note.UpdateNote(note1, noteid);
                if (result != null)
                {
                    return this.Ok(new
                    {
                        success = true,
                        message = "Note is updated Successfull",
                        response = result
                    });
                }
                else
                {
                    return this.BadRequest(new
                    {
                        success = false,
                        message = "Unable to update note",

                    });
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        [Authorize]
        [HttpPut("Pin")]
         public IActionResult IsPinornot(long noteid)
        {
            try
            {
                var result = note.isPinORNot(noteid);
                if (result!=null)
                {
                    return this.Ok(new 
                    {
                        success = true,
                        message = "Note is unPinned ",
                        Response=result
                    });
                }
                else
                {
                    return this.BadRequest(new 
                    {
                        success = false,
                        message = "Note Pinned Successfully"
                    });
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        [Authorize]
        [HttpPut("Archive")]
        public IActionResult isArchieved(long noteid)
        {
            try
            {
                var result = note.isArchieved(noteid);
                if (result != null)
                {
                    return this.Ok(new 
                    {
                        success = true,
                        message = "Note Unarchived ", 
                        Response = result
                    });
                }
                else
                {
                    return this.BadRequest(new 
                    {
                        success = false,
                        message = "Note Archived Successfully"
                       
                    });
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        [Authorize]
        [HttpPut("Color")]
        public IActionResult Color(long noteid, string color)
        {
            try
            {
                var result = note.Color(noteid, color);
                if (result != null)
                {
                    return this.Ok(new 
                    {
                        success = true,
                        message = "Color is changed ", 
                        Response = result 
                    });
                }
                else
                {
                    return this.BadRequest(new 
                    {
                        success = false,
                        message = "Unable to change color"
                    
                    });
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        /*
       [Authorize]
       [HttpPut("Upload")]
       public IActionResult UploadImage(long noteid, IFormFile img)
       {
           try
           {
               var result = note.UploadImage(noteid, img);
               if (result != null)
               {
                   return this.Ok(new { message = "uploaded ", Response = result });
               }
               else
               {
                   return this.BadRequest(new { message = "Not uploaded" });
               }
           }
           catch (Exception)
           {

               throw;
           }
       }



       [HttpPut("Trash")]
       public IActionResult Trash(NoteModel note1)
       {
           try
           {
               long userid = Convert.ToInt32(User.Claims.First(e => e.Type == "id").Value); //to claim UserID
               var result = note.UpdateNote(note1, userid);
               if (result != null)
               {
                   return this.Ok(new
                   {
                       success = true,
                       message = "Note is Trashed Successfull",
                       response = result
                   });
               }
               else
               {
                   return this.BadRequest(new
                   {
                       success = false,
                       message = "Unable to Trash note",

                   });
               }
           }
           catch (Exception ex)
           {

               throw ex;
           }
       }

       [HttpGet("ByUser")]
       public IActionResult ByUser(NoteModel note1)
       {
           try
           {
               long userid = Convert.ToInt32(User.Claims.First(e => e.Type == "id").Value); //to claim UserID
               var result = note.UpdateNote(note1, userid);
               if (result != null)
               {
                   return this.Ok(new
                   {
                       success = true,
                       message = "Note by User found Successfull",
                       response = result
                   });
               }
               else
               {
                   return this.BadRequest(new
                   {
                       success = false,
                       message = "Unable to find note ByUser",

                   });
               }
           }
           catch (Exception ex)
           {

               throw ex;
           }
       }
       [HttpGet("AllNotes")]
       public IActionResult AllNotes(NoteModel note1)
       {
           try
           {
               long userid = Convert.ToInt32(User.Claims.First(e => e.Type == "id").Value); //to claim UserID
               var result = note.UpdateNote(note1, userid);
               if (result != null)
               {
                   return this.Ok(new
                   {
                       success = true,
                       message = "All notes Successfull",
                       response = result
                   });
               }
               else
               {
                   return this.BadRequest(new
                   {
                       success = false,
                       message = "Unable to shown all note",

                   });
               }
           }
           catch (Exception ex)
           {

               throw ex;
           }
       }

        [HttpPut("UploadNote")]
       public IActionResult Upload(NoteModel note1)
       {
           try
           {
               long userid = Convert.ToInt32(User.Claims.First(e => e.Type == "id").Value); //to claim UserID
               var result = note.UpdateNote(note1, userid);
               if (result != null)
               {
                   return this.Ok(new
                   {
                       success = true,
                       message = "Note is Upload Successfull",
                       response = result
                   });
               }
               else
               {
                   return this.BadRequest(new
                   {
                       success = false,
                       message = "Unable to Upload note",

                   });
               }
           }
           catch (Exception ex)
           {

               throw ex;
           }
       }

        */

    }
}
