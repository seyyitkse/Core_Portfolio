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
    public class AnnouncementManager : IAnnouncementService
    {
        IAnnouncementDal _announcementdal;

        public AnnouncementManager(IAnnouncementDal announcementdal)
        {
            _announcementdal = announcementdal;
        }

        public void TAdd(Announcement entity)
        {
            _announcementdal.Insert(entity);
        }

        public void TDelete(Announcement entity)
        {
            _announcementdal.Delete(entity);
        }

        public Announcement TGetByID(int id)
        {
            return _announcementdal.GetByID(id);
        }

        public List<Announcement> TGetList()
        {
            return _announcementdal.GetList();
        }

        public void TUpdate(Announcement entity)
        {
            _announcementdal.Update(entity);
        }
    }
}
