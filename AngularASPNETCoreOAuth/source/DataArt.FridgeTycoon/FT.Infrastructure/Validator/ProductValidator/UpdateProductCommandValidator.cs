using FluentValidation;
using FT.Commands.Products.Update;
using System;
using System.Collections.Generic;
using System.Text;

namespace FT.Infrastructure.Validator.ProductValidator
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
	{
		public UpdateProductCommandValidator()
		{
			RuleFor(x => x.Id).NotEmpty();
			RuleFor(x => x.Name).Length(0, 20).WithMessage("'Name' length must be between 1 and 20");

		}

	}
}
