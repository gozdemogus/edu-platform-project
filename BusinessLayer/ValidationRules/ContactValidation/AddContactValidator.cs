using System;
using BaseIdentity.EntityLayer.Concrete;
using FluentValidation;

namespace BaseIdentity.BusinessLayer.ValidationRules.UserValidation
{
	public class AddContactValidator : AbstractValidator<Contact>
    {
		public AddContactValidator()
		{
            RuleFor(x => x.Email).NotEmpty().WithMessage("E-Mail is missing.");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is missing.");
            RuleFor(x => x.Message).NotEmpty().WithMessage("Message is missing.");

            RuleFor(x => x.Name).MinimumLength(2).WithMessage("Min 2 character required.");

            RuleFor(x => x.Subject).MinimumLength(2).WithMessage("Min 2 character required.");
            RuleFor(x => x.Subject).MaximumLength(20).WithMessage("Max 20 character allowed.");
            RuleFor(x => x.Message).MinimumLength(2).WithMessage("Min 2 character required.");


        }
    }
}

