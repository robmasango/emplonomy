using Emplonomy.Model;
using Scheduler.API.ViewModels.Validations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Emplonomy.Web.Models
{
    public class AddressTypeViewModel
    {
        public int ID { get; set; }
        public string AddressTypeDesc { get; set; }
        public bool? isDeleted { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validator = new AddressTypeViewModelValidator();
            var result = validator.Validate(this);
            return result.Errors.Select(item => new ValidationResult(item.ErrorMessage, new[] { item.PropertyName }));
        }

        public AddressTypeViewModel()
        {
        }

        public AddressTypeViewModel(AddressType i)
        {
            MapSingleAddressType(i);
        }

        public AddressTypeViewModel MapSingleAddressType(AddressType addressType)
        {
            ID = addressType.ID;
            AddressTypeDesc = addressType.AddressTypeDesc;
            isDeleted = addressType.isDeleted;
            return this;
        }

        public AddressType ReverseMap()
        {
            return new AddressType()
            {
                ID = this.ID,
                AddressTypeDesc = this.AddressTypeDesc,
                isDeleted = this.isDeleted,
            };
        }

        public static List<AddressTypeViewModel> MultipleAccTypesMap(List<AddressType> addressTypes)
        {
            List<AddressTypeViewModel> addressTypeVM = new List<AddressTypeViewModel>();
            foreach (var s in addressTypes)
            {
                AddressTypeViewModel sVm = new AddressTypeViewModel(s);
                addressTypeVM.Add(sVm);
            }
            return addressTypeVM;
        }
    }
}