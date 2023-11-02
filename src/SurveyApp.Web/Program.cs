// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.Services.AddData(builder.Configuration);
builder.Services.AddSwaggerGen();
builder.Services.AddControllers(options => options.AddComposable());

WebApplication app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseRouting();
app.MapControllers();
app.Run();
