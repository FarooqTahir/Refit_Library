using Refit;
using Refit_Library.Handler;
using Refit_Library.Interface;
using Refit_Library.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddRefitClient<IAuthApi>()
    .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://example-api.azurewebsites.net/api"));

builder.Services.AddScoped<ITokenService, TokenService>();

builder.Services.AddTransient<AuthenticatedHttpClientHandler>();
builder.Services.AddRefitClient<IUserNotificationApi>()
    .ConfigureHttpClient(c =>
    {
        c.BaseAddress = new Uri("https://example-api.azurewebsites.net/api");
        //c.DefaultRequestHeaders.UserAgent.ParseAdd("MyApp/1.0"); // GitHub requires a User-Agent header
    }).AddHttpMessageHandler<AuthenticatedHttpClientHandler>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
