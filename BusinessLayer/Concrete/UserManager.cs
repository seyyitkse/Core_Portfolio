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
    public class UserManager : IUserService
    {
        IUserDal _userdal;

        public UserManager(IUserDal userdal)
        {
            _userdal = userdal;
        }

        public void TAdd(User entity)
        {
            _userdal.Insert(entity);
        }

        public void TDelete(User entity)
        {
            _userdal.Delete(entity);
        }

        public User TGetByID(int id)
        {
            return _userdal.GetByID(id);
        }

        public List<User> TGetList()
        {
            return _userdal.GetList();
        }

        public void TUpdate(User entity)
        {
            _userdal.Update(entity);
        }
    }
}
