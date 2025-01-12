using DynamicFormBuilder.Service;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicFormBuilder
{
    public static class FormRendererExtensions
    {
        public static IHtmlContent RenderFormForModel(this IHtmlHelper htmlHelper, Type modelType, string formAction)
        {
            var formGenerator = new FormGeneratorService();
            var fields = formGenerator.GenerateFormFields(modelType);

            return FormRenderer.RenderForm(htmlHelper, fields, formAction);
        }
    }
}
