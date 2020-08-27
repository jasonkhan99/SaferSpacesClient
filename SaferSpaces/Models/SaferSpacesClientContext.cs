using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SaferSpacesClient.Models
{
  public class SaferSpacesClientContext : IdentityDbContext<ApplicationUser> //tells identity which class in the application will contain the user account information identity is responsible for authenticating
  {
    public virtual DbSet<Place> Places { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<Testimonial> Testimonials { get; set; }
    public SaferSpacesClientContext(DbContextOptions options) : base(options) { }
  }
}