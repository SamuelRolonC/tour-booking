using AutoMapper;
using Core;
using Core.Entity;
using Core.Interface.Repository;
using Core.Interface.Service;
using Core.Validator;
using FluentValidation;
using Infraestructure.Data;
using Infraestructure.Repository;
using Microsoft.EntityFrameworkCore;
using Service;
using System;
using TourBooking;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<IBookingManagerService, BookingManagerService>();

builder.Services.AddScoped<ITourRepository, TourRepository>();
builder.Services.AddScoped<IBookingRepository, BookingRepository>();

builder.Services.AddSingleton<IValidator<Tour>, TourValidator>();
builder.Services.AddSingleton<IValidator<Booking>, BookingValidator>();

var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});
builder.Services.AddSingleton(mapperConfig.CreateMapper());

builder.Services.AddCors(o => o.AddPolicy("NoCors", builder =>
{
    builder.AllowAnyOrigin()
    .AllowAnyMethod()
           .AllowAnyHeader();
}));

builder.Services.AddDbContext<TourBookingContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString(SystemParameters.ConnectionString.TourBookingContext)));

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

app.UseCors("NoCors");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
