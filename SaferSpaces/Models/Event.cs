using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SaferSpacesClient.Models
{
  public class Event
  {
    public Event()
    {
      this.Testimonials = new HashSet<Testimonial>();
    }

    public int EventId { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public DateTime EventDate { get; set; }
    [Required]
    public DateTime EventTime { get; set; }
    [Required]
    public string Description { get; set; }
    public virtual ICollection<Testimonial> Testimonials { get; set; }

    public static List<Event> GetEvents()
    {
      var apiCallTask = ApiHelper.GetAll();
      var result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Event> gatheringList = JsonConvert.DeserializeObject<List<Event>>(jsonResponse.ToString());

      return gatheringList;
    }

    public static Event GetDetails(int id)
    {
      var apiCallTask = ApiHelper.Get(id);
      var result = apiCallTask.Result;
      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      Event gathering = JsonConvert.DeserializeObject<Event>(jsonResponse.ToString());
      return gathering;
    }

    public static void Post(Event gathering)
    {
      string jsonEvent = JsonConvert.SerializeObject(gathering);
      var apiCallTask = ApiHelper.Post(jsonEvent);
    }

    public static void Put(Event gathering)
    {
      string jsonEvent = JsonConvert.SerializeObject(gathering);
      var apiCallTask = ApiHelper.Put(gathering.EventId, jsonEvent);
    }

    public static void Delete(int id)
    {
      var apiCallTask = ApiHelper.Delete(id);
    }
  }
}
