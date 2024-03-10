using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IWriterMessageDal:IGenericDal<WriterMessage>
    {
        List<WriterMessage> GetListByFilter(Expression<Func<WriterMessage, bool>> filter);
    }
}
