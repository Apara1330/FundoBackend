using System;
using System.Collections.Generic;
using System.Text;

namespace commonLayer.model
{
    public class NoteModel
    {
        public string title { get; set; }

        public string description { get; set; }

        public DateTime reminder { get; set; }

        public string color { get; set; }

        public bool image { get; set; }
        public bool isDeleted { get; set; }
        public bool IsArchieved { get; set; }

        public bool isPinned { get; set; }
  
        public bool IsTrash { get; set; }

        public DateTime? createdAt { get; set; }   //question mark to define this attribute as nullable.

        public DateTime? editedAt { get; set; }

    }
}
