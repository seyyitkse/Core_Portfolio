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
    public class ExperienceManager:IExperienceService
    {
        IExperienceDal _experincedal;

        public ExperienceManager(IExperienceDal experincedal)
        {
            _experincedal = experincedal;
        }

        void IGenericService<Experience>.TAdd(Experience entity)
        {
            _experincedal.Insert(entity);
        }

        void IGenericService<Experience>.TDelete(Experience entity)
        {
            _experincedal.Delete(entity);
        }

        Experience IGenericService<Experience>.TGetByID(int id)
        {
            return _experincedal.GetByID(id);
        }

        List<Experience> IGenericService<Experience>.TGetList()
        {
            return _experincedal.GetList();
        }

        void IGenericService<Experience>.TUpdate(Experience entity)
        {
            _experincedal.Update(entity);
        }
    }
}
