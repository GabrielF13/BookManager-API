using BookManager.Application.Commands.CreateBook;
using BookManager.Application.Services.Implementations;
using BookManager.Application.Services.Interfaces;
using BookManager.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("BookManager");
builder.Services.AddDbContext<BookManagerDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped<ILoanService, LoanService>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddControllers();

builder.Services.AddMediatR(typeof(CreateBookCommand));

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