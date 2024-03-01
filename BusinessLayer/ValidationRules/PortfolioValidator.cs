using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class PortfolioValidator:AbstractValidator<Portfolio>
    {
        public PortfolioValidator()
        {
            RuleFor(x=>x.Name).NotEmpty().WithMessage("The name field cannot be left blank");
            RuleFor(x=>x.ImageURL).NotEmpty().WithMessage("The image url field cannot be left blank");
            RuleFor(x=>x.ImageURL2).NotEmpty().WithMessage("The image url field cannot be left blank");
            RuleFor(x=>x.ProjectURL).NotEmpty().WithMessage("The project url field cannot be left blank");
            RuleFor(x=>x.Name).MinimumLength(3).WithMessage("Project name must consist of at least 3 characters");
            RuleFor(x=>x.Name).MaximumLength(50).WithMessage("The project name should be maximum 50 characters");
        }
    }
}
