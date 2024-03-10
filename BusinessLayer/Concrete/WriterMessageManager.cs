using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class WriterMessageManager : IWriterMessageService
    {
        IWriterMessageDal _writerMessage;

        public WriterMessageManager(IWriterMessageDal writerMessage)
        {
            _writerMessage = writerMessage;
        }

        public List<WriterMessage> GetListByFilter(Expression<Func<WriterMessage, bool>> filter)
        {
            return _writerMessage.GetListByFilter(filter);
        }

        public List<WriterMessage> GetListRecevierMessages(string p)
        {
            return _writerMessage.GetListByFilter(x => x.Recevier == p);
        }

        public List<WriterMessage> GetListSenderMessages(string p)
        {
            return _writerMessage.GetListByFilter(x => x.Sender == p);
        }

        public void TAdd(WriterMessage entity)
        {
            _writerMessage.Insert(entity);
        }

        public void TDelete(WriterMessage entity)
        {
            _writerMessage.Delete(entity);
        }

        public WriterMessage TGetByID(int id)
        {
            return _writerMessage.GetByID(id);
        }

        public List<WriterMessage> TGetList()
        {
            return _writerMessage.GetList();
        }

        public void TUpdate(WriterMessage entity)
        {
            _writerMessage.Update(entity);
        }
    }
}
