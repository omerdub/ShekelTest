using System.Collections.Generic;

namespace ShekelAPI.Validators
{
    public interface INewCustomerValidator<T>
    {
        List<string> Validate(T entity);
    }
}
