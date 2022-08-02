using businessLayer.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using repoLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FundoBackend.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CollabController : ControllerBase
    {
        ICollabBL collab;

        public CollabController(ICollabBL collab)
        {
            this.collab = collab;
        }
        [Authorize]
        [HttpPost("Add")]
        public IActionResult AddCollab(long noteid, string email)
        {
            try
            {
                int userid = Convert.ToInt32(User.Claims.First(e => e.Type == "id").Value);
                var result = collab.AddCollab(noteid, userid, email);
                if (result != null)
                {
                    return this.Ok(new
                    {
                        success = true,
                        message = "Collaborator Added Successfully",
                        Response = result
                    });
                }
                else
                {
                    return this.BadRequest(new
                    {
                        success = false,
                        message = "Unable to add"
                    });
                }
            }
            catch (Exception ex)
            {
                return this.BadRequest(new
                {
                    success = false,
                    message = ex.Message
                });
            }
        }

        [Authorize]
        [HttpDelete("Remove")]
        public IActionResult Remove(long collabid)
        {
            try
            {
                if (collab.Remove(collabid))
                {
                    return this.Ok(new 
                    { 
                        Success = true, 
                        message = "Deleted Successfully" 
                    });
                }
                else
                {
                    return this.BadRequest(new 
                    { 
                        Success = false,
                        message = "Unable to Delete" 
                    });
                }
            }
            catch (Exception ex)
            {
                return this.BadRequest(new 
                { 
                    Success = false, 
                    message = ex.Message 
                });
            }
        }

        [HttpGet("ByNoteId")]
        public IEnumerable<CollabEntity> GetAllByNoteID(long noteid)
        {
            try
            {
                return collab.GetAllByNoteID(noteid);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
