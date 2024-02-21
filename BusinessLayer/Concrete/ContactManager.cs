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

        void IGenericService<Contact>.TAdd(Contact entity)
        {
            _contactdal.Insert(entity);
        }

        void IGenericService<Contact>.TDelete(Contact entity)
        {
            _contactdal.Delete(entity);
        }

        Contact IGenericService<Contact>.TGetByID(int id)
        {
            return _contactdal.GetByID(id);
        }

        List<Contact> IGenericService<Contact>.TGetList()
        {
            return _contactdal.GetList();
        }

        void IGenericService<Contact>.TUpdate(Contact entity)
        {
            _contactdal.Update(entity);
        }
    }
}
