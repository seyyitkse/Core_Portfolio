using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IWriterMessageService:IGenericService<WriterMessage>
    {
        List<WriterMessage> GetListSenderMessages(string p);
        List<WriterMessage> GetListRecevierMessages(string p);
        List<WriterMessage> GetListByFilter(Expression<Func<WriterMessage, bool>> filter);
    }
}
