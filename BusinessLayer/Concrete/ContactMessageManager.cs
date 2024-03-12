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
    public class ContactMessageManager : IContactMessageService
    {
        IContactMessageDal contactMessageDal;

        public ContactMessageManager(IContactMessageDal contactMessageDal)
        {
            this.contactMessageDal = contactMessageDal;
        }

        public void TAdd(ContactMessage entity)
        {
            contactMessageDal.Insert(entity);
        }

        public void TDelete(ContactMessage entity)
        {
            contactMessageDal.Delete(entity);
        }

        public ContactMessage TGetByID(int id)
        {
            return contactMessageDal.GetByID(id);
        }

        public List<ContactMessage> TGetList()
        {
            return contactMessageDal.GetList();
        }

        public void TUpdate(ContactMessage entity)
        {
            contactMessageDal.Update(entity);
        }
    }
}
