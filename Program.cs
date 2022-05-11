using HolidayApi.Model;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<HolidayContext>(opt =>
    opt.UseMySQL("server=localhost;database=Holiday;user=root;password=root"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseSwagger();
    //app.UseSwaggerUI();
}

/*

const BASE_CALENDAR_URL = "https://www.googleapis.com/calendar/v3/calendars";

const BASE_CALENDAR_ID_FOR_PUBLIC_HOLIDAY ="holiday@group.v.calendar.google.com"; // Calendar Id. This is public but apparently not documented anywhere officialy.

const API_KEY = "YOUR_API_KEY";

const CALENDAR_REGION = "en.usa"; // This variable refers to region whose holidays do we need to fetch


const url = `${BASE_CALENDAR_URL}/${ CALENDAR_REGION}% 23${ BASE_CALENDAR_ID_FOR_PUBLIC_HOLIDAY}/ events ? key =${ API_KEY}`

fetch(url).then(response => response.json()).then(data => {
    const holidays = data.items;
})*/












app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
