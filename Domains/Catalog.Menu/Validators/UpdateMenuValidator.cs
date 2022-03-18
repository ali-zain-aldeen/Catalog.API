using Catalog.Menus.Dtos;
using FluentValidation;

namespace Catalog.Menus.Validators
{
    public class UpdateMenuValidator : AbstractValidator<UpdateMenuDto>
    {
        public UpdateMenuValidator()
        {
            RuleFor(x => x)
                .Must(BeValidUpdateOperation);
        }

        private bool BeValidUpdateOperation(UpdateMenuDto dto)
        {
            return
                   dto.Name is not null
                || dto.Image is not null
                || dto.Price.HasValue
                || dto.Cost.HasValue;
        }
    }
}