using VeriketApp.Service;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();

builder.Services.AddWindowsService(options =>
{
    options.ServiceName = "Veriket Application Test";
});

var host = builder.Build();
host.Run();
