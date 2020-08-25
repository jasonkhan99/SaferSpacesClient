// using Microsoft.EntityFrameworkCore;    TEMPLATE - DO WE NEED THIS????????
// using Microsoft.EntityFrameworkCore.Design;
// using Microsoft.Extensions.Configuration;
// using System.IO;

// namespace NAMESPACE.Models //probably same as ProjectName
// {
//   public class PROJECTNAMEContextFactory : IDesignTimeDbContextFactory<PROJECTNAMEContext>
//   {

//     PROJECTNAMEContext IDesignTimeDbContextFactory<PROJECTNAMEContext>.CreateDbContext(string[] args)
//     {
//       IConfigurationRoot configuration = new ConfigurationBuilder()
//           .SetBasePath(Directory.GetCurrentDirectory())
//           .AddJsonFile("appsettings.json")
//           .Build();

//       var builder = new DbContextOptionsBuilder<PROJECTNAMEContext>();
//       var connectionString = configuration.GetConnectionString("DefaultConnection");

//       builder.UseMySql(connectionString);

//       return new PROJECTNAMEContext(builder.Options);
//     }
//   }
// }