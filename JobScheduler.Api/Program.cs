using Common;
using Common.Jobs.Quartz;
using GenericHandlers;
using GenericHandlers.Persistence;
using JobScheduler.Api;
using JobScheduler.Api.CommandHandlers.Authors.AddAuthor;
using JobScheduler.Api.Persistence;
using JobScheduler.Api.Persistence.Repositories;
using JobScheduler.Api.Persistence.UnitOfWork;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.AddEventHandlersAndNecessaryWork(typeof(AddAuthorOperation));

services.AddQuartzServices(configuration);

services.AddQuartzJobs();
// Add Services

services.AddScoped<IBookRepository, BookRepository>();

services.AddScoped<IAuthorRepository, AuthorRepository>();

services.AddScoped<IBookRequestRepository, BookRequestRepository>();

services.AddScoped<IUnitOfWork, UnitOfWork<ApplicationDbContext>>();


services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(configuration.GetConnectionString("JobSchedulersDatabase")));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.AddGenericEndpoint();


app.Run();

// {
//  "source": "string",
//  "detailType": "AddCommand",
//  "detail": {
//      "body":{
//          "Value1":1
//      }
//  }
//  }


//{
// "source": "string",
// "detailType": "RemoveCommand",
// "detail": {
//     "body":{
//         "Value1":2
//     }
// }
// }

//{
// "source": "string",
// "detailType": "DividedEvent",
// "detail": {
//     "body":{
//         "Value1":3
//     }
// }
// }

// {
 // "source": "string",
 // "detailType": "MultipliedEvent",
 // "detail": {
 //     "body":{
 //         "Value1":4
 //     }
 // }
 // }