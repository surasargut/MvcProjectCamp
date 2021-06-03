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
    public class WriterManager : IWriterService
    {
        IWriterDal __writerDal;

        public WriterManager(IWriterDal writerDal)
        {
            __writerDal = writerDal;
        }

        public Writer GetByID(int id)
        {
            return __writerDal.Get(x => x.WriterID == id);
        }

        public List<Writer> GetList()
        {
            return __writerDal.List();
        }

        public void WriterAdd(Writer writer)
        {
            __writerDal.Insert(writer);
        }

        public void WriterDelete(Writer writer)
        {
            __writerDal.Delete(writer);
        }

        public void WriterUpdate(Writer writer)
        {
            __writerDal.Update(writer);
        }
    }
}
