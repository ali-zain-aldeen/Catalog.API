using Catalog.Menus.Dtos;
using FluentValidation;

namespace Catalog.Menus.Validators
{
    public class AddMenuValidator : AbstractValidator<AddMenuDto>
    {
        public AddMenuValidator()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Image)
                .NotNull()
                .NotEmpty();
        }
    }
}
