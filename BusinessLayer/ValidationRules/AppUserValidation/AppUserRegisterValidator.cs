using System;
using DTOLayer.DTOs.AppUserDTOs;
using FluentValidation;

namespace BaseIdentity.BusinessLayer.ValidationRules.UserValidation
{
	public class AppUserRegisterValidator:AbstractValidator<AppUserRegisterDTO>
	{
		public AppUserRegisterValidator()
		{
			RuleFor(x => x.Name).NotEmpty().WithMessage("Name is missing");
			RuleFor(x => x.Surname).NotEmpty().WithMessage("Surname is missing");
			RuleFor(x => x.Mail).NotEmpty().WithMessage("Mail is missing");
            RuleFor(x => x.Username).NotEmpty().WithMessage("Username is missing");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is missing");
            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("Confirm Password is missing");

			RuleFor(x => x.Username).MinimumLength(3).WithMessage("Username must include minimum 3 characters");
            RuleFor(x => x.Username).MaximumLength(20).WithMessage("Username must include maximum 20 characters");
			RuleFor(x => x.Password).Equal(y => y.ConfirmPassword).WithMessage("Passwords are not matching");
        }
    }
}

