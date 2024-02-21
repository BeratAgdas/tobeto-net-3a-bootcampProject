using Business.Requests.Applicant;
using Business.Responses.Applicant;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IApplicantService
    {
        Task<GetByIdApplicantResponse> GetAsync(int id);
        Task<CreateApplicantResponse> AddAsync(CreateApplicantRequest request);
        Task<UpdateApplicantResponse> UpdateAsync(UpdateApplicantRequest request);
        Task<DeleteApplicantResponse> DeleteAsync(DeleteApplicantRequest request);
        Task<List<GetAllApplicantResponse>> GetAllAsync(); 

    }
}
