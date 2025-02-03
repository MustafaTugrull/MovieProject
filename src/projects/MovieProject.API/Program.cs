using MovieProject.DataAccess.Contexts;
using MovieProject.DataAccess.Repositories.Abstracts;
using MovieProject.DataAccess.Repositories.Concretes;
using MovieProject.Service.Abstracts;
using MovieProject.Service.Concretes;
using MovieProject.Service.Mappers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Dependency Injection Lifecycle (Ya�am D�ng�s�)
//AddScoped() : Uygulama boyunca 1 tane nesne �retir. Nesnenin �mr� ise istek cevaba d�nene kadar.
//AddSingleton() : Uygulama boyunca 1 tane nesne �retir.
//AddTransient() : Uygulamada her istek i�in ayr� bir nesne olu�turur.

builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<CategoryMapper>();


//builder.Services.AddScoped<CategoryService>();


builder.Services.AddControllers();

builder.Services.AddDbContext<BaseDbContext>();

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
