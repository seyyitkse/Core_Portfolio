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

        void IGenericService<Skill>.TAdd(Skill entity)
        {
            _skilldal.Insert(entity);
        }

        void IGenericService<Skill>.TDelete(Skill entity)
        {
            _skilldal.Delete(entity);
        }

        Skill IGenericService<Skill>.TGetByID(int id)
        {
            return _skilldal.GetByID(id);
        }

        List<Skill> IGenericService<Skill>.TGetList()
        {
            return _skilldal.GetList();
        }

        void IGenericService<Skill>.TUpdate(Skill entity)
        {
            _skilldal.Update(entity);
        }
    }
}
