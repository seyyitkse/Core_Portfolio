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
    public class MessageManager:IMessageService
    {
        IMessageDal _messagedal;

        public MessageManager(IMessageDal messagedal)
        {
            _messagedal = messagedal;
        }

        public void TAdd(Message entity)
        {
            _messagedal.Insert(entity);
        }

        public void TDelete(Message entity)
        {
            _messagedal.Delete(entity);
        }

        public Message TGetByID(int id)
        {
            return _messagedal.GetByID(id);
        }

        public List<Message> TGetList()
        {
            return _messagedal.GetList();
        }

        public void TUpdate(Message entity)
        {
            _messagedal.Update(entity);
        }

        //void IGenericService<Message>.TAdd(Message entity)
        //{
        //    _messagedal.Insert(entity);
        //}

        //void IGenericService<Message>.TDelete(Message entity)
        //{
        //    _messagedal.Delete(entity);
        //}

        //Message IGenericService<Message>.TGetByID(int id)
        //{
        //    return _messagedal.GetByID(id);
        //}

        //List<Message> IGenericService<Message>.TGetList()
        //{
        //    return _messagedal.GetList();
        //}

        //void IGenericService<Message>.TUpdate(Message entity)
        //{
        //    _messagedal.Update(entity);
        //}
    }
}
