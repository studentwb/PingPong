using Server.Infrastructure.Extensions;
using Server.Application.Extensions;
using Server.Domain.Entites;
using Microsoft.OpenApi.Models;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowVueApp", policy =>
            policy.WithOrigins("https://localhost:58706")  
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials());
    
});
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("bearerAuth", new OpenApiSecurityScheme
    {
        Type=SecuritySchemeType.Http,
        Scheme="Bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference=new OpenApiReference{ Type= ReferenceType.SecurityScheme, Id="bearerAuth"}
            },
            []
        }
    });
});

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapGroup("api/identity").MapIdentityApi<User>();
app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors("AllowVueApp");
app.MapControllers();

app.MapFallbackToFile("/index.html");


app.Run();
