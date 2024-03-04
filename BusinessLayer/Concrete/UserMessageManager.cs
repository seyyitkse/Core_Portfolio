using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class UserMessageManager : IUserMessageService
    {
        IUserMessageDal _usermessage;

        public UserMessageManager(IUserMessageDal usermessage)
        {
            _usermessage = usermessage;
        }

        public List<UserMessage> GetUserMessageWithUserService()
        {
            return _usermessage.GetUserMessagesWithUsers();
        }

        public void TAdd(UserMessage entity)
        {
            _usermessage.Insert(entity);
        }

        public void TDelete(UserMessage entity)
        {
            _usermessage.Delete(entity);
        }

        public UserMessage TGetByID(int id)
        {
            return _usermessage.GetByID(id);
        }

        public List<UserMessage> TGetList()
        {
            return _usermessage.GetList();
        }

        public void TUpdate(UserMessage entity)
        {
            _usermessage.Update(entity);
        }
    }
}
