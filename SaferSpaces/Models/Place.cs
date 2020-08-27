using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SaferSpacesClient.Models
{
  public class Place
  { 
    public Place()
    {
      this.Events = new HashSet<Event>();
      this.Testimonials = new HashSet<Testimonial>();
    }
    public string Place_Id { get; set; }
    public string Name { get; set; }
    public string Formatted_Address { get; set; }
    public Restroom RestroomFeatures { get; set; }
    public virtual ICollection<Event> Events { get; set; }
    public virtual ICollection<Testimonial> Testimonials { get; set; }

    public static List<Place> GetPlaces(string apiKey, string searchRequest)
    {
      var apiCallTask = ApiHelper.ApiCall(apiKey, searchRequest);
      var result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      List<Place> placeList = JsonConvert.DeserializeObject<List<Place>>(jsonResponse["results"].ToString());

      return placeList;
    }

    public static Place GetDetails(string apiKey, string id)
    {
      var apiCallTask = ApiHelper.ApiSpecific(apiKey, id);
      var result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      Console.WriteLine(jsonResponse);
      Place place = JsonConvert.DeserializeObject<Place>(jsonResponse["result"].ToString());
      Console.WriteLine(place.Name);

      return place;
    }
    // public static List<Place> GetPlaces()
    // {
    //   var apiCallTask = ApiHelper.GetAllPlaces();
    //   var result = apiCallTask.Result;

    //   JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
    //   List<Place> placeList = JsonConvert.DeserializeObject<List<Place>>(jsonResponse.ToString());

    //   return placeList;
    // }

    // public static Place GetDetails(int id)
    // {
    //   var apiCallTask = ApiHelper.GetPlace(id);
    //   var result = apiCallTask.Result;
    //   JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
    //   Place place = JsonConvert.DeserializeObject<Place>(jsonResponse.ToString());
    //   return place;
    // }

    // public static void Post(Place place)
    // {
    //   string jsonPlace = JsonConvert.SerializeObject(place);
    //   var apiCallTask = ApiHelper.PostPlace(jsonPlace);
    // }

    // public static void Put(Place place)
    // {
    //   string jsonPlace = JsonConvert.SerializeObject(place);
    //   var apiCallTask = ApiHelper.PutPlace(place.PlaceId, jsonPlace);
    // }

    // public static void Delete(int id)
    // {
    //   var apiCallTask = ApiHelper.DeletePlace(id);
    // }
  }

  public enum Restroom
  {
    Accessible,
    GenderNeutral,
    Both,
    None
  }
}