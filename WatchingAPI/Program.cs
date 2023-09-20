using Company.Persistence.DB;
using FluentValidation;
using FluentValidation.AspNetCore;
using Watching.Application.CommandHandlers.CategoryCommandHandlers;
using Watching.Application.Dtos.ContentDto;
using Watching.Application.Dtos.WatchListDto;
using Watching.Application.Interfaces;
using Watching.Persistence.Services;
using Watching.Persistence.Validators.UserValidators;

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
builder.Services.AddAutoMapper(typeof(CreateContentCommand).Assembly);
builder.Services.AddAutoMapper(typeof(CreateWatchListCommand).Assembly);
builder.Services.AddDbContext<DataContext>();
builder.Services.AddMediatR(c => c.RegisterServicesFromAssemblyContaining<CreateCategoryCommandHandler>());
builder.Services.AddMediatR(c => c.RegisterServicesFromAssemblyContaining<UpdateCategoryCommandHandler>());

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
