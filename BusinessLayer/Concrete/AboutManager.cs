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
    public class AboutManager:IAboutService
    {
        IAboutDal _aboutdal;

        public AboutManager(IAboutDal aboutdal)
        {
            _aboutdal = aboutdal;
        }

        public void TAdd(About entity)
        {
            _aboutdal.Insert(entity);
        }

        public void TDelete(About entity)
        {
            _aboutdal.Delete(entity);
        }

        public void TUpdate(About entity)
        {
            _aboutdal.Update(entity);
        }


        public About TGetByID(int id)
        {
            return _aboutdal.GetByID(id);
        }

        public List<About> TGetList()
        {
            return _aboutdal.GetList();
        }
    }
}
