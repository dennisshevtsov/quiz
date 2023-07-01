// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using System.ComponentModel;
using System.Text.Json;

using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace SurveyApp.Web.Binding;

/// <summary>Provides a simple API to create an instance of a model from HTTP request.</summary>
public sealed class RequestDtoBinder : IModelBinder
{
  /// <summary>Attempts to bind a model.</summary>
  /// <param name="bindingContext">A object that contains operating information for model binding and validation.</param>
  /// <returns>An object that represents an asynchronous operation.</returns>
  public async Task BindModelAsync(ModelBindingContext bindingContext)
  {
    object? model;

    if (bindingContext.HttpContext.Request.ContentLength != null &&
        bindingContext.HttpContext.Request.ContentLength != 0)
    {
      model = await JsonSerializer.DeserializeAsync(
        bindingContext.HttpContext.Request.Body,
        bindingContext.ModelType,
        new JsonSerializerOptions
        {
          PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        });
    }
    else
    {
      model = Activator.CreateInstance(bindingContext.ModelType);
    }

    foreach (var propertyMetadata in bindingContext.ModelMetadata.Properties)
    {
      object? routeValue;
      TypeConverter? converter;

      if (propertyMetadata != null &&
          propertyMetadata.PropertySetter != null &&
          propertyMetadata.PropertyName != null &&
          (routeValue = bindingContext.ActionContext.RouteData.Values[propertyMetadata.PropertyName]) != null &&
          (converter = TypeDescriptor.GetConverter(propertyMetadata.ModelType)) != null)
      {
        propertyMetadata.PropertySetter(model!, converter.ConvertFrom(routeValue));
      }
    }

    bindingContext.Result = ModelBindingResult.Success(model);
  }
}
