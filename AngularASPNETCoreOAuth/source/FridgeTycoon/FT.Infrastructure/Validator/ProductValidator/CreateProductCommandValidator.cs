using FluentValidation;
using FT.Commands.Products.Create;
using System;
using System.Collections.Generic;
using System.Text;

namespace FT.Infrastructure.Validator.ProductValidator
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
	{
		public CreateProductCommandValidator()
		{
			RuleFor(x => x.FridgeId).NotEmpty();
			RuleFor(x => x.Name).Length(0, 20).WithMessage("'Name' length must be between 1 and 20");

		}
	}
}
