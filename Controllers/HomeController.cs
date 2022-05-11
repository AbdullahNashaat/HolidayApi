//using ConsumingWebAapiRESTinMVC.Models;
using HolidayApi.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
//using System.Web.Mvc;

namespace ConsumingWebAapiRESTinMVC.Controllers
{
    public class HomeController : Controller
    {
        static HolidayContext _context;
        static string BASE_CALENDAR_URL = "https://www.googleapis.com/calendar/v3/calendars";
        // Calendar Id. This is public but apparently not documented anywhere officialy.
        static string BASE_CALENDAR_ID_FOR_PUBLIC_HOLIDAY = "holiday@group.v.calendar.google.com"; 
        // add key
        static string API_KEY = "AIzaSyBpSZoCr4xUGsNzmAuxVw_WT0Q4hVW9Bos";
        //looop
        //static string CALENDAR_REGION = "en.usa"; // This variable refers to region whose holidays do we need to fetch

        //string url = `${ BASE_CALENDAR_URL}/${ CALENDAR_REGION}% 23${ BASE_CALENDAR_ID_FOR_PUBLIC_HOLIDAY}/ events ? key =${ API_KEY}`
        //static string url = BASE_CALENDAR_URL + "/" + CALENDAR_REGION + "%23" + BASE_CALENDAR_ID_FOR_PUBLIC_HOLIDAY + "/events?key=" + API_KEY;
       
        static public  List<Holiday> GetHolidaysFromGoogleForCountry(string CALENDAR_REGION,int CCountryId)
        {
            string url = BASE_CALENDAR_URL + "/" + CALENDAR_REGION + "%23" + BASE_CALENDAR_ID_FOR_PUBLIC_HOLIDAY + "/events?key=" + API_KEY;
            List<Holiday> Holidays = new List<Holiday>();

            using (var client = new HttpClient())
            {
                //Passing service base url
                //client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient


                //edit
                //HttpResponseMessage Res = client.Get(url);
                HttpResponseMessage Res = client.GetAsync(url).Result;

                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var HolydaysResponse = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list
                    //Holidays = JsonConvert.DeserializeObject<List<Employee>>(EmpResponse);
                    GoogleCalenderResponseModel GCRM = Newtonsoft.Json.JsonConvert.DeserializeObject<GoogleCalenderResponseModel>(HolydaysResponse);
                    Holiday holiday = new Holiday();
                    
                    foreach(Item item in GCRM.items)
                    {
                        holiday.GlobalId = item.id;
                        holiday.Name = item.summary;
                        holiday.CountryId = CCountryId;
                        /*Country country = _context.Country.Find(CCountryId);
                        holiday.Country = country;*/
                        //Teacher = _context.Teachers.Find(courseDTO.TeacherId)
                        holiday.StartDate = item.start.date;
                        holiday.EndDate = item.end.date;
                        // need 
                        Holidays.Add(holiday);
                    }
 
                }
                //returning the employee list to view
                return Holidays;
            }
        }
    }
}