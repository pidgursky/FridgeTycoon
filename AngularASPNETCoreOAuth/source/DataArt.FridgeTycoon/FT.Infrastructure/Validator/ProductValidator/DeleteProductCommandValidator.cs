using FluentValidation;
using FT.Commands.Products.Delete;
using System;
using System.Collections.Generic;
using System.Text;

namespace FT.Infrastructure.Validator.ProductValidator
{
    public class DeleteProductCommandValidator : AbstractValidator<DeleteProductByIdCommand>
	{
		public DeleteProductCommandValidator()
		{
			RuleFor(x => x.Id).NotEmpty();

		}

	}
}
