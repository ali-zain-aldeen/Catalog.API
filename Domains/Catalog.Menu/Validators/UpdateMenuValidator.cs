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
                !string.IsNullOrEmpty(dto.Name)
                || !string.IsNullOrEmpty(dto.Image)
                || dto.Price.HasValue
                || dto.Cost.HasValue;
        }
    }
}
