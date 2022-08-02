using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace repoLayer.Entity
{
    public class NoteEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public long noteid { get; set; }

        public string title { get; set; }

        public string description { get; set; }

        public DateTime reminder { get; set; }
        public bool isDeleted { get; set; }

        public string color { get; set; }

        public bool image { get; set; }
        public bool isPinned { get; set; }
        public bool IsArchieved { get; set; }

        public bool IsTrash { get; set; }

        public DateTime? createdAt { get; set; }   //question mark to define this attribute as nullable.

        public DateTime? editedAt { get; set; }

        [ForeignKey("user")] //steps to give Foreign key constraint.
        public long UserId { get; set; }//UserId is the Foreign key constraint

        public virtual UserEntity user { get; set; }



    }
}
