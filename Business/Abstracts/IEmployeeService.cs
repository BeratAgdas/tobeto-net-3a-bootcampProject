using Business.Requests.Employee;
using Business.Responses.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IEmployeeService
    {
        Task<GetByIdEmployeeResponse> GetAsync(int id);
        Task<CreateEmployeeResponse> AddAsync(CreateEmployeeRequest request);
        Task<UpdateEmployeeResponse> UpdateAsync(UpdateEmployeeRequest request);
        Task<DeleteEmployeeResponse> DeleteAsync(DeleteEmployeeRequest request);
        Task<List<GetAllEmployeeResponse>> GetAllAsync();
    }
}
