# Dynamic Form Builder

Dynamic Form Builder is a powerful and easy-to-use library for automatically generating HTML forms based on your model's properties. It is designed for ASP.NET Core applications, and it helps you save time by dynamically creating forms with full validation, styling, and layout.

The library supports basic form fields, including text inputs, number fields, checkboxes, and dropdowns, and it integrates seamlessly with Bootstrap for styling. It also handles required fields and displays validation messages where necessary.

# Features
1) Automatic Form Generation: Automatically generates forms based on the properties of your model.
2) Field Types: Supports text, number, date, checkbox, and dropdown fields.
3) Bootstrap Integration: Built-in support for Bootstrap styling to make your forms visually appealing and responsive.
4) Field Validation: Supports required field validation with error messages.
5) Easy Integration: Seamlessly integrates with your ASP.NET Core application with minimal setup.

# Installation
To install Dynamic Form Builder in your ASP.NET Core project, you can either download the DLL or install the package via NuGet if it's published.

Install via NuGet (if available) `dotnet add package DynamicFormBuilder --version 1.0.0`.

Install via Package Manager (if available) `Install-Package DynamicFormBuilder -Version 1.0.0`

Configure `builder.Services.AddSingleton<FormGeneratorService>();` Inside Program.cs file.

![image](https://github.com/user-attachments/assets/6a3cb2d7-049b-4887-baf1-05d11634a5d9)


![image](https://github.com/user-attachments/assets/d2e23c09-033f-43b5-8355-76c691d1ce23)

Automatically generates forms based on your model and its properties.
