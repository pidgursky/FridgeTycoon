using FluentValidation;
using FT.Commands.Fridger.Create;
using System;
using System.Collections.Generic;
using System.Text;

namespace FT.Infrastructure.Validator.FridgeValidator
{
	public class CreateFridgeCommandValidator : AbstractValidator<CreateFridgeCommand>
	{
		public CreateFridgeCommandValidator()
		{
			RuleFor(x => x.Name).Length(0, 20).WithMessage("'Name' length must be between 1 and 20");
			RuleFor(x => x.Model).Length(0, 20).WithMessage("'Model' length must be between 1 and 20");
			RuleFor(x => x.Volume).InclusiveBetween(1, 10000).WithMessage("'Volume' must be between 1 and 10000");
		}
	}
}
