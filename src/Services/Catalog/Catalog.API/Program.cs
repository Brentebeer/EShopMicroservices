var builder = WebApplication.CreateBuilder(args);

// Add services to the container

//Carter is set up to scan the specified assembly (in this case, typeof(Program).Assembly) for classes that implement the ICarterModule interface.
builder.Services.AddCarter(
    new DependencyContextAssemblyCatalog(assemblies: typeof(Program).Assembly)
);

builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
});

var app = builder.Build();

// Configure to HTTP request pipeline
app.MapCarter();

app.Run();
