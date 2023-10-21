using System.ComponentModel.DataAnnotations;

namespace LiveStats.Core.Football.Managers
{
    public static class DataValidator
    {
        public static (bool, string?) Validate<T>(T obj)
        {
            if (obj == null)
                return (false, null);

            try
            {
                Validator.ValidateObject(obj, new ValidationContext(obj), true);
                return (true, null);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }
    }
}
