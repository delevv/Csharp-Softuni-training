namespace ValidationAttributes
{
    using System.Linq;
    using System.Reflection;
    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            var objProperties = obj.GetType().GetProperties();

            foreach (var property in objProperties)
            {
                var propAttributes = property
                    .GetCustomAttributes()
                    .Where(a => a is MyValidationAttribute)
                    .Cast<MyValidationAttribute>();

                foreach (var attribute in propAttributes)
                {
                    var result = attribute.IsValid(property.GetValue(obj));

                    if (!result)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
