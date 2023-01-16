using System;
using DTOLayer.DTOs.AppUserDTOs;
using FluentValidation;

namespace BaseIdentity.BusinessLayer.ValidationRules.UserValidation
{
	public class AppUserLoginValidator : AbstractValidator<AppUserLoginDTO>
    {
		public AppUserLoginValidator()
		{
            RuleFor(x => x.username).NotEmpty().WithMessage("Username is missing");
            RuleFor(x => x.password).NotEmpty().WithMessage("Password is missing");
        }
	}
}

