using repoLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace repoLayer.Interface
{
    public interface ICollabRL
    {
        public CollabEntity AddCollab(long noteid, long userid, string email);

        public bool Remove(long collabid);
        IEnumerable<CollabEntity> GetAllByNoteID(long noteid);
    }
}
