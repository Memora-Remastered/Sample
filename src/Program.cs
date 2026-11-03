var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddInfrastructure(builder.Configuration, typeof(Program).Assembly);

var app = builder.Build();

app.UseExceptionHandler();
app.UseSwagger();
app.UseHttpsRedirection();
app.UseCors("AllowDomains");
app.UseRequestLocalization();
app.UseMiddleware<RequestContextMiddleware>();
app.MapControllers();
await app.RunAsync();
