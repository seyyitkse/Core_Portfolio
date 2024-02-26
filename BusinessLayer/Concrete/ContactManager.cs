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
    public class ContactManager:IContactService
    {
        IContactDal _contactdal;

        public ContactManager(IContactDal contactdal)
        {
            _contactdal = contactdal;
        }

        public void TAdd(Contact entity)
        {
            _contactdal.Insert(entity);
        }

        public void TDelete(Contact entity)
        {
            _contactdal.Delete(entity);
        }

        public Contact TGetByID(int id)
        {
            return _contactdal.GetByID(id);
        }

        public List<Contact> TGetList()
        {
            return _contactdal.GetList();
        }

        public void TUpdate(Contact entity)
        {
            _contactdal.Update(entity);
        }
    }
}
