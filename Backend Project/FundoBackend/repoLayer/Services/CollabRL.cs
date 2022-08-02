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
    public class CollabRL : ICollabRL
    {
        private readonly Fundo context;
        private readonly IConfiguration Iconfiguration;

        public CollabRL(Fundo context, IConfiguration Iconfiguration)
        {
            this.context = context;
            this.Iconfiguration = Iconfiguration;
        }

        public CollabEntity AddCollab(long noteid, long userid, string email)
        {
            try
            {
                CollabEntity Entity = new CollabEntity();
                Entity.Noteid = noteid;

                Entity.CollabEmail = email;

                Entity.Userid = userid;

                this.context.Collaborators.Add(Entity);
                int result = this.context.SaveChanges();
                if (result > 0)
                {
                    return Entity;
                }
                return null;

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
                var result = this.context.Collaborators.FirstOrDefault(x => x.CollabId == collabid);
                context.Remove(result);
                int deletednote = this.context.SaveChanges();
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

        public IEnumerable<CollabEntity> GetAllByNoteID(long noteid)
        {
            return context.Collaborators.Where(n => n.Noteid == noteid).ToList();
        }
    }
}
