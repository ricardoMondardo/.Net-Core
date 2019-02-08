using System.Linq;
using Web.Core.Models;

namespace Web.Server.Services.Interface
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
