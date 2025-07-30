using Lesson2.Contexts;
using Lesson2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();

var optionsBuilder = new DbContextOptionsBuilder<AuthDbContext>();
optionsBuilder.UseSqlServer(configuration.GetConnectionString("Default"));

using var context = new AuthDbContext(optionsBuilder.Options); 


context.Students.Add(new()
 { 
     Id = "723A1B3",
     Email = "test@gmail.com",
     Name = "Test",
     BirthDate = DateTime.Today
});

context.SaveChanges();

var res = context.Students.Where(u => u.Email == "test@gmail.com");

foreach (var student in res)
{
    Console.WriteLine($"{student.Name} - {student.Email} - {student.BirthDate}");
}
