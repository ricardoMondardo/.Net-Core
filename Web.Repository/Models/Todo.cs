using System;
using System.Collections.Generic;
using System.Text;

namespace Web.Repository.Models
{
    public class Todo : IEntityBase
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public bool Active { get; set; }
        public string UserId { get; set; }

      
    }
}
