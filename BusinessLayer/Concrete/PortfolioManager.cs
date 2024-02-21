using BusinessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class PortfolioManager:IPortfolioService
    {
        EfPortfolioDal _portfoliodal;

        public PortfolioManager(EfPortfolioDal portfoliodal)
        {
            _portfoliodal = portfoliodal;
        }

        void IGenericService<Portfolio>.TAdd(Portfolio entity)
        {
            _portfoliodal.Insert(entity);
        }

        void IGenericService<Portfolio>.TDelete(Portfolio entity)
        {
            _portfoliodal.Delete(entity);
        }

        Portfolio IGenericService<Portfolio>.TGetByID(int id)
        {
            return _portfoliodal.GetByID(id);
        }

        List<Portfolio> IGenericService<Portfolio>.TGetList()
        {
            return _portfoliodal.GetList();
        }

        void IGenericService<Portfolio>.TUpdate(Portfolio entity)
        {
            _portfoliodal.Update(entity);
        }
    }
}
