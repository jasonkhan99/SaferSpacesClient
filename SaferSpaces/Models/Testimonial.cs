using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SaferSpacesClient.Models
{
  public class Testimonial
  {
    public int TestimonialId { get; set; }
    public string Place_Id { get; set; }

    public virtual Place Place { get; set; }

    public string Story { get; set; }

    public string Management { get; set; }

    public string Other { get; set; }

    public static void Post(string place_id, Testimonial testimonial)
    {
      string jsonTestimonial = JsonConvert.SerializeObject(testimonial);
      var apiCallTask = ApiHelper.PostTestimonial(testimonial.Place_Id, jsonTestimonial);
    }


//     public static List<Testimonial> GetTestimonials()
//     {
//       var apiCallTask = ApiHelper.GetAllTestimonials();
//       var result = apiCallTask.Result;

//       JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
//       List<Testimonial> testimonialList = JsonConvert.DeserializeObject<List<Testimonial>>(jsonResponse.ToString());

//       return testimonialList;
//     }

//     public static Testimonial GetDetails(int id)
//     {
//       var apiCallTask = ApiHelper.GetTestimonial(id);
//       var result = apiCallTask.Result;
//       JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
//       Testimonial testimonial = JsonConvert.DeserializeObject<Testimonial>(jsonResponse.ToString());
//       return testimonial;
//     }

//     public static void Post(Testimonial testimonial)
//     {
//       string jsonTestimonial = JsonConvert.SerializeObject(testimonial);
//       var apiCallTask = ApiHelper.PostTestimonial(jsonTestimonial);
//     }

//     public static void Put(Testimonial testimonial)
//     {
//       string jsonTestimonial = JsonConvert.SerializeObject(testimonial);
//       var apiCallTask = ApiHelper.PutTestimonial(testimonial.TestimonialId, jsonTestimonial);
//     }

//     public static void Delete(int id)
//     {
//       var apiCallTask = ApiHelper.DeleteTestimonial(id);
//     }
  }
}




