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
    public class SkillManager:ISkillService
    {
        ISkillDal _skilldal;

        public SkillManager(ISkillDal skilldal)
        {
            _skilldal = skilldal;
        }

        public void TAdd(Skill entity)
        {
            _skilldal.Insert(entity);
        }

        public void TDelete(Skill entity)
        {
            _skilldal.Delete(entity);
        }

        public Skill TGetByID(int id)
        {
            return _skilldal.GetByID(id);
        }

        public List<Skill> TGetList()
        {
            return _skilldal.GetList();
        }

        public void TUpdate(Skill entity)
        {
            _skilldal.Update(entity);
        } 
    }
}
