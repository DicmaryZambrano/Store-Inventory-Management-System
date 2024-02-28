using InventoryManagement.Data;
using InventoryManagement.Models;
using Microsoft.EntityFrameworkCore;


namespace InventoryManagement.Services
{
    public class EmployeeService
    {
        private readonly IDbContextFactory<AppDbContext> _dbContextFactory;

        public EmployeeService(IDbContextFactory<AppDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory ?? throw new ArgumentNullException(nameof(dbContextFactory));
        }

        // Add a new employee
        public async Task AddEmployee(Employee employee)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                context.Employees.Add(employee);
                await context.SaveChangesAsync();
            }
        }

        // Retrieve all employees
        public async Task<List<Employee>> GetAllEmployees()
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                return await context.Employees.ToListAsync();
            }
        }

        // Get Employee by UserName
        public Employee? GetEmployeeByUserName(Employee user)
        {

            using (var context = _dbContextFactory.CreateDbContext())
            {
                var userAccount = context.Employees.FirstOrDefault(x => x.Username == user.Username);
                return userAccount;
            }
        }

        //Get Employee by ID
        public async Task<Employee> GetEmployeetByIdAsync(int employeeId)
        {
            try
            {
                using (var context = _dbContextFactory.CreateDbContext())
                {
                    var employee = await context.Employees.FindAsync(employeeId);
                    if (employee == null)
                    {
                        // If the employee with the specified ID is not found handle the exception
                        throw new KeyNotFoundException($"Employee with ID {employeeId} not found");
                    }
                    return employee;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        // Update an existing employee
        public async Task UpdateEmployee(Employee employee)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                context.Employees.Update(employee);
                await context.SaveChangesAsync();
            }
        }

        // Delete an employee by ID
        public async Task DeleteEmployee(int employeeId)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                var employee = await context.Employees.FindAsync(employeeId);
                if (employee != null)
                {
                    context.Employees.Remove(employee);
                    await context.SaveChangesAsync();
                }
            }
        }
    }
}
