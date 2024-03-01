using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class FeatureValidator:AbstractValidator<Feature>
    {
        public FeatureValidator()
        {
            RuleFor(x=>x.Header).NotEmpty().WithMessage("The header field cannot be left blank");
            RuleFor(x => x.Header).MinimumLength(5).WithMessage("The header must consist of at least 3 characters");
            RuleFor(x => x.Header).MaximumLength(15).WithMessage("The header must have a maximum of 15 characters");
            RuleFor(x => x.Name).NotEmpty().WithMessage("The name field cannot be left blank");
            RuleFor(x => x.Name).MinimumLength(5).WithMessage("The name must have a minimum of 5 characters");
            RuleFor(x => x.Name).MaximumLength(50).WithMessage("The name must have a maximum of 50 characters");
            RuleFor(x => x.Title).NotEmpty().WithMessage("The title field cannot be left blank");
            RuleFor(x => x.Title).MinimumLength(10).WithMessage("The title must have a minimum of 10 characters");
            RuleFor(x => x.Title).MaximumLength(150).WithMessage("The title must have a maximum of 150 characters");
        }
    }
}
