using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Api.Dtos.Todo;
using Web.Api.Helpers.Pagging;
using Web.Api.Services.Interface;
using Web.Repository.Interfaces;
using Web.Repository.Models;

namespace Web.Api.Services
{
    public class TodoService : ITodoService
    {
        private IUnitOfWork _unitOfWork;

        public TodoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void Add(Todo todo)
        {
            _unitOfWork.Todos.Add(todo);
            _unitOfWork.Save();
        }

        public Todo Get(string id)
        {
            return _unitOfWork.Todos.Get(id);
        }

        public IQueryable<Todo> GetAllQueryable()
        {
            return _unitOfWork.Todos.Find().AsQueryable();
        }

        public void SetDone(string id)
        {
            throw new NotImplementedException();
        }
    }
}
