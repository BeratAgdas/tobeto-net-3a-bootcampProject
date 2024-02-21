using Business.Abstracts;
using Business.Requests.Employee;
using Business.Responses.Employee;
using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class EmployeeManager : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeManager(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<GetByIdEmployeeResponse> GetAsync(int id)
        {
            Employee employee = await _employeeRepository.GetAsync(e => e.Id == id);
            GetByIdEmployeeResponse employeeResponse = new GetByIdEmployeeResponse()
            {
                Id = employee.Id,
                CreatedDate = employee.CreatedDate,
                UpdatedDate = employee.UpdatedDate,
                UserName = employee.UserName,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                DateOfBirth = employee.DateOfBirth,
                Email = employee.Email,
                Password = employee.Password,
                Position = employee.Position
            };
            return employeeResponse;
        }
        public async Task<CreateEmployeeResponse> AddAsync(CreateEmployeeRequest request)
        {
            Employee employee = new Employee()
            {
                CreatedDate = DateTime.Now,
                UserName = request.UserName,
                FirstName = request.FirstName,
                LastName = request.LastName,
                DateOfBirth = request.DateOfBirth,
                Email = request.Email,
                Password = request.Password,
                Position = request.Position
            };
            await _employeeRepository.AddAsync(employee);

            CreateEmployeeResponse employeeResponse = new CreateEmployeeResponse()
            {
                Id = employee.Id,
                CreatedDate = employee.CreatedDate,
                UserName=employee.UserName,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                DateOfBirth = employee.DateOfBirth,
                Email = employee.Email,
                Password = employee.Password,
                Position = employee.Position
            };
            return employeeResponse;
        }
        public async Task<UpdateEmployeeResponse> UpdateAsync(UpdateEmployeeRequest request)
        {
            Employee employee = await _employeeRepository.GetAsync(e => e.Id == request.Id);
            employee.UpdatedDate = DateTime.Now;
            employee.UserName = request.UserName;
            employee.FirstName = request.FirstName;
            employee.LastName = request.LastName;
            employee.DateOfBirth = request.DateOfBirth;
            employee.Email = request.Email;
            employee.Password = request.Password;
            employee.Position = request.Position;

            await _employeeRepository.UpdateAsync(employee);

            UpdateEmployeeResponse employeeResponse = new UpdateEmployeeResponse()
            {
                Id = employee.Id,
                CreatedDate = employee.CreatedDate,
                UpdatedDate = employee.UpdatedDate,
                UserName = employee.UserName,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                DateOfBirth = employee.DateOfBirth,
                Email = employee.Email,
                Password = employee.Password,
                Position = employee.Position
            };
            return employeeResponse;

        }
        public async Task<DeleteEmployeeResponse> DeleteAsync(DeleteEmployeeRequest request)
        {
            Employee employee = await _employeeRepository.GetAsync(e => e.Id == request.Id);
            employee.DeletedDate = DateTime.Now;

            await _employeeRepository.DeleteAsync(employee);

            DeleteEmployeeResponse employeeResponse = new DeleteEmployeeResponse()
            {
                Id = employee.Id,
                CreatedDate = employee.CreatedDate,
                UpdatedDate = employee.UpdatedDate,
                DeletedDate = employee.DeletedDate,
                UserName = employee.UserName,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                DateOfBirth = employee.DateOfBirth,
                Email = employee.Email,
                Password = employee.Password,
                Position = employee.Position
            };
            return employeeResponse;
        }

        public async Task<List<GetAllEmployeeResponse>> GetAllAsync()
        {
            List<Employee> employees = await _employeeRepository.GetAllAsync();
            List<GetAllEmployeeResponse> getAllEmployees = new List<GetAllEmployeeResponse>();

            foreach (Employee employee in employees)
            {
                getAllEmployees.Add(new GetAllEmployeeResponse()
                {
                    Id = employee.Id,
                    CreatedDate = employee.CreatedDate,
                    UpdatedDate = employee.UpdatedDate,
                    UserName= employee.UserName,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    DateOfBirth = employee.DateOfBirth,
                    Email = employee.Email,
                    Password = employee.Password,
                    Position = employee.Position
                });
            }
            return getAllEmployees;
        }   
    }
}
