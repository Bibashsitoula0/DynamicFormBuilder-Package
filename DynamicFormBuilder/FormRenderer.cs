using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicFormBuilder
{
    public static class FormRenderer
    {
        public static IHtmlContent RenderForm(this IHtmlHelper htmlHelper, List<FieldModel> fields, string formAction)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append($"<form action='{formAction}' method='POST' class='needs-validation' validate>"); 
            foreach (var field in fields)
            {
                stringBuilder.Append($"<div class='form-group'>");

                stringBuilder.Append($"<label for='{field.FieldName}' class='form-label'>{field.FieldLabel}</label>");

                if (field.FieldType == "text" || field.FieldType == "number" || field.FieldType == "date")
                {
                    stringBuilder.Append($"<input type='{field.FieldType}' id='{field.FieldName}' name='{field.FieldName}' class='form-control' required='{field.IsRequired}' />");
                }
                else if (field.FieldType == "checkbox")
                {
                    stringBuilder.Append($"<div class='form-check'>");
                    stringBuilder.Append($"<input type='checkbox' id='{field.FieldName}' name='{field.FieldName}' class='form-check-input' />");
                    stringBuilder.Append($"<label class='form-check-label' for='{field.FieldName}'> {field.FieldLabel} </label>");
                    stringBuilder.Append("</div>");
                }
                else if (field.FieldType == "dropdown")
                {
                    stringBuilder.Append($"<select id='{field.FieldName}' name='{field.FieldName}' class='form-select' required='{field.IsRequired}'>");
                    foreach (var value in field.EnumValues)
                    {
                        stringBuilder.Append($"<option value='{value}'>{value}</option>");
                    }
                    stringBuilder.Append("</select>");
                }

                if (field.IsRequired)
                {
                    stringBuilder.Append($"<div class='invalid-feedback'>{field.ValidationMessage}</div>"); 
                }

                stringBuilder.Append("</div>");
            }

            stringBuilder.Append("<div class='form-group' style='margin-top: 15px;'>");
            stringBuilder.Append("<button type='submit' class='btn btn-primary'>Submit</button>");
            stringBuilder.Append("</div>");

            stringBuilder.Append("</form>");

            return new HtmlString(stringBuilder.ToString());
        }
    }
}
