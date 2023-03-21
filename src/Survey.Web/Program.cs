// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.SetUpApplication();
builder.Services.SetUpInfrastructure();

var app = builder.Build();

app.MapControllers();

app.Run();
