using Tactsoft.Application;
using Tactsoft.Application.Common;
using Tactsoft.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

var WebAppCorsPolicy = "WebAppCorsPolicy";

// Add services to the container.
builder.Services.ApplicationConfiguration(builder.Configuration);
builder.Services.InfrastructureConfiguration(builder.Configuration);

var origins = builder.Configuration.GetSection("Domain").Get<Domain>();
if (origins.Client2.Any()) { origins?.Client1?.AddRange(origins.Client2); }

builder.Services.AddCors(options => options.AddPolicy(WebAppCorsPolicy, builder =>
{
    builder.WithOrigins(origins?.Client1?.ToArray())
    .AllowAnyMethod()
    .AllowAnyHeader()
    .AllowCredentials();
}));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Tactsoft Ltd"));
    app.UseReDoc(options =>
    {
        options.DocumentTitle = "Learning Management System Api Documentation";
        options.SpecUrl = "/swagger/v1/swagger.json";
    });
}

app.UseCors(WebAppCorsPolicy);
app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseResponseCaching();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();

