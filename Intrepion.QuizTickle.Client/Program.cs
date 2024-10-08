﻿using Intrepion.QuizTickle.BusinessLogic.Services;
using Intrepion.QuizTickle.BusinessLogic.Services.Client;
using Intrepion.QuizTickle.Client;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddSingleton<AuthenticationStateProvider, PersistentAuthenticationStateProvider>();

builder.Services.AddScoped(http => new HttpClient
{
    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress),
});
builder.Services.AddScoped<IApplicationRoleAdminService, ApplicationRoleClientAdminService>();
builder.Services.AddScoped<IApplicationUserAdminService, ApplicationUserClientAdminService>();

builder.Services.AddScoped<IAnswerAdminService, AnswerClientAdminService>();
builder.Services.AddScoped<IQuestionAdminService, QuestionClientAdminService>();
builder.Services.AddScoped<IQuestionTypeAdminService, QuestionTypeClientAdminService>();
builder.Services.AddScoped<IQuizAdminService, QuizClientAdminService>();
// RegisterClientServiceCodePlaceholder

await builder.Build().RunAsync();
