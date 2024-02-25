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

        public void TAdd(Experience entity)
        {
            _experincedal.Insert(entity);
        }

        public void TDelete(Experience entity)
        {
            _experincedal.Delete(entity);
        }

        public Experience TGetByID(int id)
        {
            return _experincedal.GetByID(id);
        }

        public List<Experience> TGetList()
        {
            return _experincedal.GetList();
        }

        public void TUpdate(Experience entity)
        {
            _experincedal.Update(entity);
        }
    }
}
