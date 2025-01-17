using Device.API.Configuration;
using Device.API.Contexts;
using Device.API.Contexts.Dtos.Devices;
using Device.API.Shared.Enums;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddSwaggerConfiguration();
builder.Services.RegisterServices(builder.Configuration);
builder.Services.AddDatabaseConfiguration(builder.Configuration);
builder.Services.AddRouting(options => options.LowercaseUrls = true);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseSwaggerSetup();
app.UseAuthorization();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<DevicesDbContext>();
    context.Database.Migrate();

    if(!context.Devices.Any())
    {
        context.Devices.AddRange(
            new DevicesDto
            {
                Name = "Galaxy Note 3",
                Brand = "Samsung",
                State = ((int)DeviceStates.Available),
                CreationTime = DateTime.Now
            },
            new DevicesDto
            {
                Name = "Iphone 2000",
                Brand = "Apple",
                State = ((int)DeviceStates.InUse),
                CreationTime = DateTime.Now
            },
            new DevicesDto
            {
                Name = "Bad Phone 2",
                Brand = "Microsoft",
                State = ((int)DeviceStates.Inactive),
                CreationTime = DateTime.Now
            });

        context.SaveChanges();
    }
}

app.MapControllers();
app.Run();