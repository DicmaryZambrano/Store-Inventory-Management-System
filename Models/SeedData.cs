using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using InventoryManagement.Data;
using System;
using System.Linq;

namespace InventoryManagement.Models
{
  public static class SeedData
  {
    public static void Initialize(IServiceProvider serviceProvider)
    {
      using (var context = new AppDbContext(
          serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
      {
        // Look for any data (employees, products, reports, stores).
        if (context.Employees.Any() || context.Products.Any() || context.Reports.Any() || context.Stores.Any())
        {
          return;   // DB has been seeded
        }

        context.Employees.AddRange(
            new Employee
            {
              FirstName = "John",
              LastName = "Doe",
              Position = Position.Employee,
              Username = "john.doe",
              Password = "password123"
            },
            new Employee
            {
              FirstName = "Jane",
              LastName = "Smith",
              Position = Position.Manager,
              Username = "jane.smith",
              Password = "password456"
            }
        );

        context.Reports.AddRange(
            new Report
            {
              ReportName = "Monthly Report",
              Content = "Monthly Report Content ...."
            }
        );

        context.Stores.AddRange(
            new Store
            {
              StoreName = "Main Store",
              Location = "Idaho, USA"
            }
        );

        context.Products.AddRange(
            new Product
            {
              ProductName = "Dress Shirt",
              Price = 29.99m,
              Quantity = 50,
              Discontinued = false
            },
            new Product
            {
              ProductName = "Jeans",
              Price = 39.99m,
              Quantity = 30,
              Discontinued = false
            }
        );

        // save changes in the database
        context.SaveChanges();
      }
    }
  }
}
