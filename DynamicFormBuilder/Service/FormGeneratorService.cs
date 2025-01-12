using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DynamicFormBuilder.Service
{
    public class FormGeneratorService
    {
        public List<FieldModel> GenerateFormFields(Type modelType)
        {
            var fields = new List<FieldModel>();

            foreach (var property in modelType.GetProperties())
            {
                var field = new FieldModel
                {
                    FieldName = property.Name,
                    FieldLabel = property.Name.ReplaceCamelCaseWithSpaces(),  
                    FieldType = GetFieldType(property.PropertyType),
                    IsRequired = IsRequired(property),
                    ValidationMessage = GetValidationMessage(property),
                    EnumValues = GetEnumValues(property)
                };

                fields.Add(field);
            }

            return fields;
        }

        private string GetFieldType(Type propertyType)
        {
            if (propertyType == typeof(int) || propertyType == typeof(decimal) || propertyType == typeof(double))
            {
                return "number";
            }
            else if (propertyType == typeof(bool))
            {
                return "checkbox";
            }
            else if (propertyType == typeof(DateTime))
            {
                return "date";
            }
            else if (propertyType.IsEnum)
            {
                return "dropdown";
            }
            return "text";  // Default field type
        }

        private bool IsRequired(PropertyInfo property)
        {
            var attribute = property.GetCustomAttribute<RequiredAttribute>();
            return attribute != null;
        }

        private string GetValidationMessage(PropertyInfo property)
        {
            var attribute = property.GetCustomAttribute<RequiredAttribute>();
            return attribute?.ErrorMessage ?? string.Empty;
        }

        private List<string> GetEnumValues(PropertyInfo property)
        {
            if (property.PropertyType.IsEnum)
            {
                return Enum.GetNames(property.PropertyType).ToList();
            }
            return new List<string>();
        }
    }

    public static class StringExtensions
    {
        public static string ReplaceCamelCaseWithSpaces(this string input)
        {
            return string.Concat(input.Select((x, i) => i > 0 && Char.IsUpper(x) ? " " + x : x.ToString())).Trim();
        }
    }
}
