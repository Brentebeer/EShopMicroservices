var builder = WebApplication.CreateBuilder(args);

// Add services to the container
var assembly = typeof(Program).Assembly;

//Underneath is pipelinebehavior
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(assembly);
    config.AddOpenBehavior(typeof(ValidationBehavior<,>));
});

builder.Services.AddValidatorsFromAssembly(assembly);

//Carter is set up to scan the specified assembly (in this case, typeof(Program).Assembly) for classes that implement the ICarterModule interface.
builder.Services.AddCarter(
    new DependencyContextAssemblyCatalog(assemblies: assembly)
);

//Configure the connection to the postGres database.
builder.Services.AddMarten(opts =>
{
    opts.Connection(builder.Configuration.GetConnectionString("Database")!);
}).UseLightweightSessions();

builder.Services.AddExceptionHandler<CustomExceptionHandler>();

var app = builder.Build();

// Configure to HTTP request pipeline
app.MapCarter();

app.UseExceptionHandler(options => { });

app.Run();
