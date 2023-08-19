using ImagesAPI.Config;
using ImagesAPI.Helpers;
using ImagesAPI.Helpers.Abstractions;
using ImagesAPI.Services;
using ImagesAPI.Services.Abstractions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<CloudinaryConfig>(builder.Configuration.GetSection("CloudinaryConfig"));
builder.Services.AddTransient<ICloudinaryAccountFactory, CloudinaryAccountFactory>();
builder.Services.AddScoped<IImagesService, CloudinaryImagesService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
