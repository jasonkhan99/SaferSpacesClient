using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SaferSpacesApi.Models
{
  public class Testimonial
  {
    public int TestimonialId { get; set; }

    public string Story { get; set; }

    public string Management { get; set; }

    public string Other { get; set; }

    
    public static List<Testimonial> GetTestimonials()
    {
      var apiCallTask = ApiHelper.GetAll();
      var result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Testimonial> testimonialList = JsonConvert.DeserializeObject<List<Testimonial>>(jsonResponse.ToString());

      return testimonialList;
    }

    public static Testimonial GetDetails(int id)
    {
      var apiCallTask = ApiHelper.Get(id);
      var result = apiCallTask.Result;
      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      Testimonial testimonial = JsonConvert.DeserializeObject<Testimonial>(jsonResponse.ToString());
      return testimonial;
    }

    public static void Post(Testimonial testimonial)
    {
      string jsonTestimonial = JsonConvert.SerializeObject(testimonial);
      var apiCallTask = ApiHelper.Post(jsonTestimonial);
    }

    public static void Put(Testimonial testimonial)
    {
      string jsonTestimonial = JsonConvert.SerializeObject(testimonial);
      var apiCallTask = ApiHelper.Put(testimonial.TestimonialId, jsonTestimonial);
    }
    
    public static void Delete(int id)
    {
      var apiCallTask = ApiHelper.Delete(id);
    }
  }
}




