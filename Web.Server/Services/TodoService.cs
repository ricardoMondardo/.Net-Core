using System;
using System.Linq;
using Web.Server.Services.Interface;
using Web.Repository.Interfaces;
using Web.Repository.Models;

namespace Web.Server.Services
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

        public void Remove(string id)
        {
            var todo = _unitOfWork.Todos.Get(id);

            _unitOfWork.Todos.Remove(todo);
            _unitOfWork.Save();
        }

        public void SetDone(string id)
        {
            throw new NotImplementedException();
        }
    }
}
