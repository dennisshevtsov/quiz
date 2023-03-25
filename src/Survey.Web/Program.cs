// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

builder.Services.SetUpApplication();
builder.Services.SetUpInfrastructure(builder.Configuration);

var app = builder.Build();

app.UseSwagger();

app.MapControllers();

app.Run();
