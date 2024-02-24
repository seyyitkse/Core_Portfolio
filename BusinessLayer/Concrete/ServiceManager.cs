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
    public class ServiceManager:IServiceService
    {
        IServiceDal _servicedal;

        public ServiceManager(IServiceDal servicedal)
        {
            _servicedal = servicedal;
        }

        public void TAdd(Service entity)
        {
            _servicedal.Insert(entity);
        }

        public void TDelete(Service entity)
        {
            _servicedal.Delete(entity);
        }

        public Service TGetByID(int id)
        {
            return _servicedal.GetByID(id);
        }

        public List<Service> TGetList()
        {
            return _servicedal.GetList();
        }

        public void TUpdate(Service entity)
        {
            _servicedal.Update(entity);
        }
    }
}
