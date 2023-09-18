using Company.Persistence.DB;
using FluentValidation;
using FluentValidation.AspNetCore;
using Watching.Application.Dtos.ContentDto;
using Watching.Application.Dtos.WatchListDto;
using Watching.Application.Interfaces;
using Watching.Application.Validators.UserValidators;
using Watching.Persistence.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblyContaining<CreateUserValidator>();




// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IContentService, ContentService>();
builder.Services.AddScoped<IWatchListService, WatchListService>();
builder.Services.AddAutoMapper(typeof(CreateContentDto).Assembly);
builder.Services.AddAutoMapper(typeof(CreateWatchListDto).Assembly);
builder.Services.AddDbContext<DataContext>();

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
