using System.ComponentModel.DataAnnotations;

namespace GeoCalc.Validation;

public class Validator<T> : IValidatableObject
{
    private List<ValidationResult> m_validationResults = new List<ValidationResult>();
    private List<ValidationAttribute> m_validationAttributes = new List<ValidationAttribute>();
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        throw new NotImplementedException();
    }


}
