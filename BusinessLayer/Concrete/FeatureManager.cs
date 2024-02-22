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
    public class FeatureManager:IGenericService<Feature>
    {
        IFeatureDal _featuredal;

        public FeatureManager(IFeatureDal featuredal)
        {
            _featuredal = featuredal;
        }

        public void TAdd(Feature entity)
        {
            _featuredal.Insert(entity);
        }

        public void TDelete(Feature entity)
        {
            _featuredal.Delete(entity);
        }

        public Feature TGetByID(int id)
        {
            return _featuredal.GetByID(id);
        }

        public List<Feature> TGetList()
        {
            return _featuredal.GetList();
        }

        public void TUpdate(Feature entity)
        {
            _featuredal.Update(entity);
        }

        //void IGenericService<Feature>.TAdd(Feature entity)
        //{
        //    
        //}

        //void IGenericService<Feature>.TDelete(Feature entity)
        //{
        //    
        //}

        //Feature IGenericService<Feature>.TGetByID(int id)
        //{
        //    
        //}

        //List<Feature> IGenericService<Feature>.TGetList()
        //{
        //   
        //}

        //void IGenericService<Feature>.TUpdate(Feature entity)
        //{
        //    
        //}
    }
}
