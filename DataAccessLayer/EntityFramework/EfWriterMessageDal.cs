using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfWriterMessageDal:GenericRepository<WriterMessage>,IWriterMessageDal
    {
        public List<WriterMessage> GetListByFilter(Expression<Func<WriterMessage, bool>> filter)
        {
            using var c = new Context();
            return c.Set<WriterMessage>().Where(filter).ToList();
        }
    }
}
