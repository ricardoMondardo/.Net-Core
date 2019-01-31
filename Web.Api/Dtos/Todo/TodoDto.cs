using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Api.Dtos.Todo
{
    public class TodoDto
    {
        public string Text { get; set; }
        public bool Active { get; set; }
    }
}
