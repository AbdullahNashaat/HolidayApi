# HolidayApi
 This api get official holidays from google calender for 79 Country which are stored with it's name and required key in file with path  HolidayApi/Data/google-calendar-list.txt and then store the data in MYSQL DB and you can do CRUD ops on them.
 
 There are 3 entities
- Holiday has Id, GlobalId (in the google calender), Name, StartDate,  EndDate and CountryId (FK).
 - Country has  Id,  Name and CalenderRegion.
 - GoogleCalenderResponseModel is for reading the Google Calender Response.
 


There are 3 controllers 
- CountriesController (CRUD ops)
- HolidaysController (CRUD ops)
- HomeController for calling Google Calender and get data and store it in the DB
