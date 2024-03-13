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
    public class SocialMediaManager:ISocialMediaService
    {
        ISocialMediaDal _socialmediadal;

        public SocialMediaManager(ISocialMediaDal socialmediadal)
        {
            _socialmediadal = socialmediadal;
        }

        public void TAdd(SocialMedia entity)
        {
            _socialmediadal.Insert(entity);
        }

        public void TDelete(SocialMedia entity)
        {
            _socialmediadal.Delete(entity);
        }

        public SocialMedia TGetByID(int id)
        {
            return _socialmediadal.GetByID(id);
        }

        public List<SocialMedia> TGetList()
        {
            return _socialmediadal.GetList();
        }

        public void TUpdate(SocialMedia entity)
        {
            _socialmediadal.Update(entity);
        }
    }
}
