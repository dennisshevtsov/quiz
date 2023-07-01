// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace SurveyApp.Web.Binding;

/// <summary>Provides a simple API to create an instance of the <see cref="BookApi.Web.Binding.RequestDtoBinder"/> class.</summary>
public sealed class RequestDtoBinderProvider : IModelBinderProvider
{
  /// <summary>Creates a <see cref="Microsoft.AspNetCore.Mvc.ModelBinding.IModelBinder"/> based on <see cref="Microsoft.AspNetCore.Mvc.ModelBinding.ModelBinderProviderContext"/>.</summary>
  /// <param name="context">A context object for <see cref="IModelBinderProvider.GetBinder"/>.</param>
  /// <returns>An instance of the <see cref="Microsoft.AspNetCore.Mvc.ModelBinding.IModelBinder"/>.</returns>
  public IModelBinder? GetBinder(ModelBinderProviderContext context)
  {
    if (context.Metadata.ModelType.IsAssignableTo(typeof(IRequestDto)))
    {
      return new RequestDtoBinder();
    }

    return null;
  }
}
