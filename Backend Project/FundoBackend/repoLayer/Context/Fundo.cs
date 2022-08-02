using Microsoft.EntityFrameworkCore;
using repoLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace repoLayer.Context
{
     public class Fundo : DbContext
    {
        public Fundo(DbContextOptions options)
            : base(options)
        {
        }
        public DbSet<UserEntity> UsersEntity { get; set; }

        public DbSet<NoteEntity> NotesTable { get; set; }  //NoteTable is migration name here an it should be unique
        public DbSet<CollabEntity> Collaborators { get; set; }
        public DbSet<LabelEntity> Labels { get; set; }
    }
}
