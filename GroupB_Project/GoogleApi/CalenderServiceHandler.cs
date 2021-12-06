using System;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace GroupB_Project.GoogleApi
{
    public class CalenderServiceHandler
    {
        public CalendarService GetCalendarService()
        {
            try
            {
                string[] Scopes = {
                CalendarService.Scope.Calendar,
                CalendarService.Scope.CalendarEvents,
                CalendarService.Scope.CalendarEventsReadonly
            };

                UserCredential credential;

                using (var stream = new FileStream("GoogleAPI/credentials.json", FileMode.Open, FileAccess.Read))
                {
                    // The file token.json stores the user's access and refresh tokens, and is created
                    // automatically when the authorization flow completes for the first time.
                    string credPath = "token.json";
                    credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                        GoogleClientSecrets.FromStream(stream).Secrets,
                        Scopes,
                        "user",
                        CancellationToken.None,
                        new FileDataStore(credPath, true)).Result;
                    Console.WriteLine("Credential file saved to: " + credPath);
                }

                // Create Calendar API service.    
                var service = new CalendarService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = "GroupB_Project",
                });
                return service;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void CreateEvent(CalendarService _service, DateTime start, DateTime end, String subject, String location)
        {
            Event body = new Event();
            EventAttendee a = new EventAttendee();
            a.Email = "bunsomendoza@gmail.com";
       
            List<EventAttendee> attendes = new List<EventAttendee>();
            attendes.Add(a);
         
            body.Attendees = attendes;
            EventDateTime startTime = new EventDateTime();
            startTime.DateTime = start;
            EventDateTime endTime = new EventDateTime();
            endTime.DateTime = end;
            body.Start = startTime;
            body.End = endTime;
            body.Location = location;
            body.Summary = subject;
            EventsResource.InsertRequest request = new EventsResource.InsertRequest(_service, body, "bunsomendoza@gmail.com");
            Event response = request.Execute();
        }
    }
}
/*@functions{

    //if google imports are broken use nuGet package manager and call 'Install-Package Google.Apis.Calendar.v3'
    String GetCalendarService()
    {
        try
        {
            string[] Scopes = {
                    CalendarService.Scope.Calendar,
                    CalendarService.Scope.CalendarEvents,
                    CalendarService.Scope.CalendarEventsReadonly
                };

            UserCredential credential;

            using (var stream = new FileStream("GoogleApi/credentials.json", FileMode.Open, FileAccess.Read))
            {
                // The file token.json stores the user's access and refresh tokens, and is created
                // automatically when the authorization flow completes for the first time.
                string credPath = "token.json";
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.FromStream(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
                Console.WriteLine("Credential file saved to: " + credPath);
            }

            // Create Calendar API service.
            var service = new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "GroupB_Project",
            });


            // Define parameters of request.
            EventsResource.ListRequest request = service.Events.List("primary");
            request.TimeMin = DateTime.Now;
            request.ShowDeleted = false;
            request.SingleEvents = true;
            request.MaxResults = 10;
            request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;

            string eventsValue = "";
            // List events.
            Events events = request.Execute();
            eventsValue = "Upcoming events:\n";
            if (events.Items != null && events.Items.Count > 0)
            {
                foreach (var eventItem in events.Items)
                {
                    string when = eventItem.Start.DateTime.ToString();
                    if (String.IsNullOrEmpty(when))
                    {
                        when = eventItem.Start.Date;
                    }
                    eventsValue += string.Format("{0} ({1})", eventItem.Summary, when) + "\n";
                }
                return eventsValue;
            }
            else
            {
                return "No upcoming events found.";
            }
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}*/

