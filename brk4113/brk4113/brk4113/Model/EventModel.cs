using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace brk4113.Model.Event
{
    class EventModel
    {
    }

    public class ResponseStatus
    {
        public string response { get; set; }
        public string time { get; set; }
    }

    public class Body
    {
        public string contentType { get; set; }
        public string content { get; set; }
    }

    public class Start
    {
        public string dateTime { get; set; }
        public string timeZone { get; set; }
    }

    public class End
    {
        public string dateTime { get; set; }
        public string timeZone { get; set; }
    }

    public class Location
    {
        public string displayName { get; set; }
    }

    public class Status
    {
        public string response { get; set; }
        public string time { get; set; }
    }

    public class EmailAddress
    {
        public string name { get; set; }
        public string address { get; set; }
    }

    public class Attendee
    {
        public Status status { get; set; }
        public string type { get; set; }
        public EmailAddress emailAddress { get; set; }
    }

    public class EmailAddress2
    {
        public string name { get; set; }
        public string address { get; set; }
    }

    public class Organizer
    {
        public EmailAddress2 emailAddress { get; set; }
    }

    public class Value
    {
        [JsonProperty("@odata.etag")]
        public string OdataEtag { get; set; }
        public string id { get; set; }
        public string createdDateTime { get; set; }
        public string lastModifiedDateTime { get; set; }
        public string changeKey { get; set; }
        public List<object> categories { get; set; }
        public string originalStartTimeZone { get; set; }
        public string originalEndTimeZone { get; set; }
        public ResponseStatus responseStatus { get; set; }
        public string iCalUId { get; set; }
        public int reminderMinutesBeforeStart { get; set; }
        public bool isReminderOn { get; set; }
        public bool hasAttachments { get; set; }
        public string subject { get; set; }
        public Body body { get; set; }
        public string bodyPreview { get; set; }
        public string importance { get; set; }
        public string sensitivity { get; set; }
        public Start start { get; set; }
        public End end { get; set; }
        public Location location { get; set; }
        public bool isAllDay { get; set; }
        public bool isCancelled { get; set; }
        public bool isOrganizer { get; set; }
        public object recurrence { get; set; }
        public bool responseRequested { get; set; }
        public object seriesMasterId { get; set; }
        public string showAs { get; set; }
        public string type { get; set; }
        public List<Attendee> attendees { get; set; }
        public Organizer organizer { get; set; }
        public string webLink { get; set; }
        public object onlineMeetingUrl { get; set; }
    }

    public class RootObject
    {
        [JsonProperty("@odata.context")]
        public string OdataContext { get; set; }
        [JsonProperty("@odata.nextLink")]
        public string OdataNextLink { get; set; }
        public List<brk4113.Model.Event.Value> value { get; set; }
    }
}

