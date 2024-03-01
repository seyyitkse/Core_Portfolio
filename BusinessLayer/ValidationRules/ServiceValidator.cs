using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ServiceValidator:AbstractValidator<Service>
    {
        public ServiceValidator()
        {
            RuleFor(x => x.Title)
            .NotEmpty().WithMessage("The title field cannot be left blank")
            .MinimumLength(5).WithMessage("The title must consist of at least 5 characters.")
            .MaximumLength(50).WithMessage("The title must have a maximum of 50 characters.");

            RuleFor(x => x.ImageURL)
                .NotEmpty().WithMessage("The URL field cannot be left blank")
                .MinimumLength(15).WithMessage("The title must consist of at least 5 characters.")
                .MaximumLength(500).WithMessage("The title must have a maximum of 500 characters.");
        }
    }
}
