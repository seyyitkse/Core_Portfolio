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

        public void TAdd(Portfolio entity)
        {
            _portfoliodal.Insert(entity);
        }

        public void TDelete(Portfolio entity)
        {
            _portfoliodal.Delete(entity);
        }

        public Portfolio TGetByID(int id)
        {
            return _portfoliodal.GetByID(id);
        }

        public List<Portfolio> TGetList()
        {
            return _portfoliodal.GetList();
        }

        public void TUpdate(Portfolio entity)
        {
            _portfoliodal.Update(entity);
        }  
    }
}
