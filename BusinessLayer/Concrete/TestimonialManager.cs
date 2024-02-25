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
    public class TestimonialManager:ITestimonialService
    {
        ITestimonialDal _testimonialdal;

        public TestimonialManager(ITestimonialDal testimonialdal)
        {
            _testimonialdal = testimonialdal;
        }

        public void TAdd(Testimonial entity)
        {
            _testimonialdal.Insert(entity);
        }

        public void TDelete(Testimonial entity)
        {
            _testimonialdal.Delete(entity);
        }

        public Testimonial TGetByID(int id)
        {
            return _testimonialdal.GetByID(id);
        }

        public List<Testimonial> TGetList()
        {
            return _testimonialdal.GetList();
        }

        public void TUpdate(Testimonial entity)
        {
            _testimonialdal.Update(entity);
        }
    }
}
