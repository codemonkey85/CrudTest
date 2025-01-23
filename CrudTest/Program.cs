var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services
    .AddOpenApi()
    .AddEndpointsApiExplorer()
    .AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
services.AddDbContextPool<AppDbContext>(options => options.UseSqlServer(connectionString));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app
    .UseHttpsRedirection()
    .UseSwagger()
    .UseSwaggerUI();

var apiGroup = app.MapGroup("api");
apiGroup.MapEndpoints();

app.Run();
