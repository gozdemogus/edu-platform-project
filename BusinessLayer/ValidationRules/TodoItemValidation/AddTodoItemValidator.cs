using System;
using BaseIdentity.EntityLayer.Concrete;
using DTOLayer.DTOs.TodoItemDTOs;
using FluentValidation;

namespace BaseIdentity.BusinessLayer.ValidationRules.TodoItemValidation
{
	public class AddTodoItemValidator : AbstractValidator<AddTodoItemDTO>
    {
		public AddTodoItemValidator()
		{

            RuleFor(x => x.Description).NotEmpty().WithMessage("Description is missing.");
            RuleFor(x => x.Deadline).NotEmpty().WithMessage("Deadline is missing.");
        }
	}
}

