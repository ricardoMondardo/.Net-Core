using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Repository.Models;

namespace Web.Api.Services.Interface
{
    public interface ITodoService
    {
        void Add(Todo todo);
        void SetDone(string id);
    }
}
