using ReadyToRunRepro;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddSingleton<IService, Service>();
builder.Services.AddHostedService<Worker>();

var host = builder.Build();
host.Run();
