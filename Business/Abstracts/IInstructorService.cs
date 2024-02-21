using Business.Requests.Instructor;
using Business.Responses.Instructor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IInstructorService
    {
        Task<GetByIdInstructorResponse> GetAsync(int id);
        Task<CreateInstructorResponse> AddAsync(CreateInstructorRequest request);
        Task<UpdateInstructorResponse> UpdateAsync(UpdateInstructorRequest request);
        Task<DeleteInstructorResponse> DeleteAsync(DeleteInstructorRequest request);
        Task<List<GetAllInstructorResponse>> GetAllAsync();
    }
}
