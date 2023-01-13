using System;
using BaseIdentity.EntityLayer.Concrete;
using FluentValidation;

namespace BaseIdentity.BusinessLayer.ValidationRules.UserValidation
{
	public class ContactValidator : AbstractValidator<Contact>
    {
		public ContactValidator()
		{
            RuleFor(x => x.Email).NotEmpty().WithMessage("E-Mail is obligatory.");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is obligatory.");




            RuleFor(x => x.Subject).MinimumLength(2).WithMessage("Min 2 character required.");
            RuleFor(x => x.Subject).MaximumLength(20).WithMessage("Max 20 character allowed.");
        }
    }
}

