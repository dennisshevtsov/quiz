// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen();

builder.Services.SetUpApp();
builder.Services.SetUpData(builder.Configuration);
builder.Services.SetUpWeb();

var app = builder.Build();

app.SetUpDatabase();

app.UseSwagger();
app.UseStaticFiles();
app.UseRouting();

app.MapControllers();

app.Run();
