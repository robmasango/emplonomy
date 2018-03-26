using Emplonomy.Web.Models;
using FluentValidation;

namespace Scheduler.API.ViewModels.Validations
{
    public class AddressTypeViewModelValidator : AbstractValidator<AddressTypeViewModel>
    {
        public AddressTypeViewModelValidator()
        {
            RuleFor(addtype => addtype.AddressTypeDesc).NotEmpty().WithMessage("Address type name cannot be empty");
        }

    }
}
