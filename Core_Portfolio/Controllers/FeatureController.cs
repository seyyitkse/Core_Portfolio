using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace Core_Portfolio.Controllers
{
    public class FeatureController : Controller
    {
        FeatureManager featureManager = new FeatureManager(new EfFeatureDal());
        public IActionResult Index()
        {
            var values = featureManager.TGetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult UpdateFeature(int id)
        {
            var values=featureManager.TGetByID(id);
            return View(values);  
        }
        [HttpPost] 
        public IActionResult UpdateFeature(Feature feature) 
        {
            FeatureValidator validations = new FeatureValidator();
            ValidationResult results = validations.Validate(feature);
            if (results.IsValid)
            {
                featureManager.TUpdate(feature);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
        }
    }
}
