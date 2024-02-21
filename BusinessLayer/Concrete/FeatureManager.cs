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
    public class FeatureManager:IFeatureService
    {
        IFeatureDal _featuredal;

        public FeatureManager(IFeatureDal featuredal)
        {
            _featuredal = featuredal;
        }

        void IGenericService<Feature>.TAdd(Feature entity)
        {
            _featuredal.Insert(entity);
        }

        void IGenericService<Feature>.TDelete(Feature entity)
        {
            _featuredal.Delete(entity);
        }

        Feature IGenericService<Feature>.TGetByID(int id)
        {
            return _featuredal.GetByID(id);
        }

        List<Feature> IGenericService<Feature>.TGetList()
        {
            return _featuredal.GetList();
        }

        void IGenericService<Feature>.TUpdate(Feature entity)
        {
            _featuredal.Update(entity);
        }
    }
}
