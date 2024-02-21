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

        void IGenericService<Testimonial>.TAdd(Testimonial entity)
        {
            _testimonialdal.Insert(entity);
        }

        void IGenericService<Testimonial>.TDelete(Testimonial entity)
        {
            _testimonialdal.Delete(entity);
        }

        Testimonial IGenericService<Testimonial>.TGetByID(int id)
        {
            return _testimonialdal.GetByID(id);
        }

        List<Testimonial> IGenericService<Testimonial>.TGetList()
        {
            return _testimonialdal.GetList();
        }

        void IGenericService<Testimonial>.TUpdate(Testimonial entity)
        {
            _testimonialdal.Update(entity);
        }
    }
}
