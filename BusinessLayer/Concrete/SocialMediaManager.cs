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

        void IGenericService<SocialMedia>.TAdd(SocialMedia entity)
        {
            _socialmediadal.Insert(entity);
        }

        void IGenericService<SocialMedia>.TDelete(SocialMedia entity)
        {
            _socialmediadal.Delete(entity);
        }

        SocialMedia IGenericService<SocialMedia>.TGetByID(int id)
        {
            return _socialmediadal.GetByID(id);
        }

        List<SocialMedia> IGenericService<SocialMedia>.TGetList()
        {
            return _socialmediadal.GetList();
        }

        void IGenericService<SocialMedia>.TUpdate(SocialMedia entity)
        {
            _socialmediadal.Update(entity);
        }
    }
}
