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

        void IGenericService<Service>.TAdd(Service entity)
        {
            _servicedal.Insert(entity);
        }

        void IGenericService<Service>.TDelete(Service entity)
        {
            _servicedal.Delete(entity);
        }

        Service IGenericService<Service>.TGetByID(int id)
        {
            return _servicedal.GetByID(id);
        }

        List<Service> IGenericService<Service>.TGetList()
        {
            return _servicedal.GetList();
        }

        void IGenericService<Service>.TUpdate(Service entity)
        {
            _servicedal.Update(entity);
        }
    }
}
