using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ToDoListManager : IGenericService<ToDoList>
    {
        IToDoListDal _todolist;

        public ToDoListManager(IToDoListDal todolist)
        {
            _todolist = todolist;
        }

        public void TAdd(ToDoList entity)
        {
            _todolist.Insert(entity);
        }

        public void TDelete(ToDoList entity)
        {
            _todolist.Delete(entity);
        }

        public ToDoList TGetByID(int id)
        {
            return _todolist.GetByID(id);
        }

        public List<ToDoList> TGetList()
        {
            return _todolist.GetList();
        }

        public void TUpdate(ToDoList entity)
        {
            _todolist.Update(entity);
        }
    }
}
