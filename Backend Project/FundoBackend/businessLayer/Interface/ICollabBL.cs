using repoLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace businessLayer.Interface
{
    public interface ICollabBL
    {
        public CollabEntity AddCollab(long noteid, long userid, string email);

        public bool Remove(long collabid);
        IEnumerable<CollabEntity> GetAllByNoteID(long noteid);
    }
}
