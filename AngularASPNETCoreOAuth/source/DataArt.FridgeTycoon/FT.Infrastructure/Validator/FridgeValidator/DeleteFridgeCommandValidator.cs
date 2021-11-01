using FluentValidation;
using FT.Commands.Fridger.Delete;
using System;
using System.Collections.Generic;
using System.Text;

namespace FT.Infrastructure.Validator.FridgeValidator
{
    public class DeleteFridgeCommandValidator : AbstractValidator<DeleteFridgeByIdCommand>
	{
		public DeleteFridgeCommandValidator()
		{
			RuleFor(x => x.Id).NotEmpty();

		}

	}
}
