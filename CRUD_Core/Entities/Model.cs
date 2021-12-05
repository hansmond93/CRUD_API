using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD_Core.Entities
{
    public class Model
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public bool IsCompleted { get; set; }
    }
}
