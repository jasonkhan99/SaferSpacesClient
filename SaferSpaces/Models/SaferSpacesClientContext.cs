using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SaferSpacesClient.Models
{
  public class SaferSpaceClientContext : IdentityDbContext<ApplicationUser> //tells identity which class in the application will contain the user account information identity is responsible for authenticating
  {
    public virtual DbSet<Place> Places { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<Testimonial> Testimonials { get; set; }
    public DbSet<EventPlace> EventPlace {get; set; }
    public DbSet<EventTestimonial> EventTestimonial {get; set; }
    public DbSet<PlaceTestimonial> PlaceTestimonial {get; set; }
    
    public SaferSpacesClientContext(DbContextOptions options) : base(options) { }
  }
}