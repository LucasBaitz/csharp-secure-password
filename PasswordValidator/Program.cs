using PasswordValidator.API.Errors;
using PasswordValidator.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);
    

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddExceptionHandler<InvalidPasswordExceptionHandler>();
builder.Services.AddProblemDetails();

builder.Services.AddScoped<IPasswordValidator, PasswordValidator.Services.Services.PasswordValidator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
