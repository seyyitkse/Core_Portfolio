using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AboutValidator:AbstractValidator<About>
    {
        public AboutValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("The title field cannot be left blank")
                .MinimumLength(3).WithMessage("The title must consist of at least 3 characters")
                .MaximumLength(50).WithMessage("The title must have a maximum of 50 characters");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("The description field cannot be left blank")
                .MinimumLength(3).WithMessage("The description must consist of at least 3 characters")
                .MaximumLength(250).WithMessage("The description must have a maximum of 250 characters");

            RuleFor(x => x.Age)
                .NotEmpty().WithMessage("The age field cannot be left blank")
                .Length(2).WithMessage("The age must consist of exactly 2 characters");

            RuleFor(x => x.Mail)
                .NotEmpty().WithMessage("The e-mail field cannot be left blank")
                .EmailAddress().WithMessage("Please enter a valid e-mail address");

            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("The phone field cannot be left blank")
                .MinimumLength(2).WithMessage("The phone must consist of at least 2 characters")
                .MaximumLength(20).WithMessage("The phone must have a maximum of 20 characters");

            RuleFor(x => x.ImageURL)
                .NotEmpty().WithMessage("The URL field cannot be left blank")
                .MinimumLength(3).WithMessage("The URL must consist of at least 3 characters")
                .MaximumLength(500).WithMessage("The URL must have a maximum of 500 characters");

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("The address field cannot be left blank")
                .MinimumLength(3).WithMessage("The address must consist of at least 3 characters")
                .MaximumLength(250).WithMessage("The address must have a maximum of 250 characters");
        }
    }
}
