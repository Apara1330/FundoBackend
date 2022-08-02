using businessLayer.Interface;
using repoLayer.Entity;
using repoLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace businessLayer.Services
{
    public class CollabBL : ICollabBL
    {
        ICollabRL collabRL;
        
        public CollabBL(ICollabRL collabRL)
        {
            this.collabRL = collabRL;
        }

        public CollabEntity AddCollab(long noteid, long userid, string email)
        {
            try
            {
                return this.collabRL.AddCollab(noteid, userid, email);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Remove(long collabid)
        {
            try
            {
                return this.collabRL.Remove(collabid);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<CollabEntity> GetAllByNoteID(long noteid)
        {
            try
            {
                return this.collabRL.GetAllByNoteID(noteid);
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
