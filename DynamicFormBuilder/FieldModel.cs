using System.Collections.Generic;

namespace DynamicFormBuilder
{
    public class FieldModel
    {
        public string FieldName { get; set; }
        public string FieldLabel { get; set; }
        public string FieldType { get; set; }
        public bool IsRequired { get; set; }
        public string ValidationMessage { get; set; }
        public List<string> EnumValues { get; set; }  

    }
}
