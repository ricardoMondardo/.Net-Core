using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Api.Helpers.Pagging;
using Web.Repository.Models;

namespace Web.Api.Services.Interface
{
    public interface ITodoService
    {
        void Add(Todo todo);
        void SetDone(string id);
        Todo Get(string id);
        IQueryable<Todo> GetAllQueryable();
        void Remove(string id);
    }
}
