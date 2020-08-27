
using System.Threading.Tasks;
using RestSharp;

namespace SaferSpacesClient.Models
{
  class ApiHelper
  {
    //GOOGLE CALLS
    public static async Task<string> ApiCall(string apiKey, string searchRequest)
    {
      RestClient client = new RestClient("https://maps.googleapis.com");
      RestRequest request = new RestRequest($"maps/api/place/textsearch/json?input={searchRequest}&inputtype=textquery&types=bar&fields=formatted_address,name,place_id&key={apiKey}", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }

    public static async Task<string> ApiSpecific(string apiKey, string id)
    {
      RestClient client = new RestClient("https://maps.googleapis.com");
      RestRequest request = new RestRequest($"maps/api/place/details/json?place_id={id}&fields=formatted_address,name,place_id&key={apiKey}", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }

     //Events API Helper Methods
    public static async Task<string> GetAllEvents()
    {
      ///do we need to pass the API key here?
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"events", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }

    public static async Task<string> GetEvent(int id)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"events/{id}", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }

    public static async Task PostEvent(string newEvent)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"events", Method.POST);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newEvent);
      var response = await client.ExecuteTaskAsync(request);
    }

    public static async Task PutEvent(int id, string newEvent)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"events/{id}", Method.PUT);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newEvent);
      var response = await client.ExecuteTaskAsync(request);
    }

    public static async Task DeleteEvent(int id)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"events/{id}", Method.DELETE);
      request.AddHeader("Content-Type", "application/json");
      var response = await client.ExecuteTaskAsync(request);
    }
    
    // Places API Helper
    public static async Task<string> GetAllPlaces()
    {
      ///do we need to pass the API key here?
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"places", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }

    public static async Task<string> GetPlace(int id)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"places/{id}", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }

    public static async Task PostPlace(string newPlace)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"places", Method.POST);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newPlace);
      var response = await client.ExecuteTaskAsync(request);
    }

    public static async Task PutPlace(int id, string newPlace)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"places/{id}", Method.PUT);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newPlace);
      var response = await client.ExecuteTaskAsync(request);
    }

    public static async Task DeletePlace(int id)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"places/{id}", Method.DELETE);
      request.AddHeader("Content-Type", "application/json");
      var response = await client.ExecuteTaskAsync(request);
    }

    //Testimonials API Helper
    public static async Task<string> GetAllTestimonials()
    {
      ///do we need to pass the API key here?
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"testimonials", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }

    public static async Task<string> GetTestimonial(int id)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"testimonials/{id}", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }

    public static async Task PostTestimonial(string place_id, string newTestimonial)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"testimonials", Method.POST);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newTestimonial);
      var response = await client.ExecuteTaskAsync(request);
    }

    public static async Task PutTestimonial(int id, string newTestimonial)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"testimonials/{id}", Method.PUT);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newTestimonial);
      var response = await client.ExecuteTaskAsync(request);
    }

    public static async Task DeleteTestimonial(int id)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"testimonials/{id}", Method.DELETE);
      request.AddHeader("Content-Type", "application/json");
      var response = await client.ExecuteTaskAsync(request);
    }
  }
}