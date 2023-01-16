using System;
using DTOLayer.DTOs.TodoItemDTOs;
using FluentValidation;

namespace BaseIdentity.BusinessLayer.ValidationRules.TodoItemValidation
{
	public class UpdateTodoItemValidator : AbstractValidator<UpdateTodoItemDTO>
    {
		public UpdateTodoItemValidator()
		{
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description is missing.");

        }
	}
}

