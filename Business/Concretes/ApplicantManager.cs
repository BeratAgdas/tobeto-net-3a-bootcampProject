using Business.Abstracts;
using Business.Requests.Applicant;
using Business.Responses.Applicant;
using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class ApplicantManager : IApplicantService
    {
        private readonly IApplicantRepository _applicantRepository;

        public ApplicantManager(IApplicantRepository applicantRepository)
        {
            _applicantRepository = applicantRepository;
        }
        public async Task<GetByIdApplicantResponse> GetAsync(int id)
        {
            Applicant applicant = await _applicantRepository.GetAsync(a => a.Id == id);
            GetByIdApplicantResponse applicantResponse = new GetByIdApplicantResponse()
            {
                Id = applicant.Id,
                CreatedDate = applicant.CreatedDate,
                UpdatedDate = applicant.UpdatedDate,
                UserName = applicant.UserName,
                FirstName = applicant.FirstName,
                LastName = applicant.LastName,
                DateOfBirth = applicant.DateOfBirth,
                Email = applicant.Email,
                Password = applicant.Password,
                About = applicant.About
            };
            return applicantResponse;
        }
        public async Task<CreateApplicantResponse> AddAsync(CreateApplicantRequest request)
        {
            Applicant applicant = new Applicant()
            {
                CreatedDate = DateTime.Now,
                UserName = request.UserName,
                FirstName = request.FirstName,
                LastName = request.LastName,
                DateOfBirth = request.DateOfBirth,
                Email = request.Email,
                Password = request.Password,
                About = request.About

            };
            await _applicantRepository.AddAsync(applicant);

            CreateApplicantResponse applicantResponse = new CreateApplicantResponse()
            {
                Id = applicant.Id,
                CreatedDate = applicant.CreatedDate,
                UserName = applicant.UserName,
                FirstName = applicant.FirstName,
                LastName = applicant.LastName,
                DateOfBirth = applicant.DateOfBirth,
                Email = applicant.Email,
                Password = applicant.Password,
                About = applicant.About
            };
            return applicantResponse;

        }
        public async Task<UpdateApplicantResponse> UpdateAsync(UpdateApplicantRequest request)
        {
            Applicant applicant = await _applicantRepository.GetAsync(a => a.Id == request.Id);
            applicant.UpdatedDate = DateTime.Now;
            applicant.UserName = request.UserName;
            applicant.FirstName = request.FirstName;
            applicant.LastName = request.LastName;
            applicant.DateOfBirth = request.DateOfBirth;
            applicant.Email = request.Email;
            applicant.Password = request.Password;
            applicant.About = request.About;
            await _applicantRepository.UpdateAsync(applicant);

            UpdateApplicantResponse applicantResponse = new UpdateApplicantResponse()
            {
                Id = applicant.Id,
                CreatedDate = applicant.CreatedDate,
                UpdatedDate = applicant.UpdatedDate,
                UserName = applicant.UserName,
                FirstName = applicant.FirstName,
                LastName = applicant.LastName,
                DateOfBirth = applicant.DateOfBirth,
                Email = applicant.Email,
                Password = applicant.Password,
                About = applicant.About
            };
            return applicantResponse;
        }
        public async Task<DeleteApplicantResponse> DeleteAsync(DeleteApplicantRequest request)
        {
            Applicant applicant =await _applicantRepository.GetAsync(a => a.Id == request.Id);
            applicant.DeletedDate = DateTime.Now;

            await _applicantRepository.DeleteAsync(applicant);

            DeleteApplicantResponse applicantResponse = new DeleteApplicantResponse()
            {
                Id = applicant.Id,
                CreatedDate = applicant.CreatedDate,
                UpdatedDate = applicant.UpdatedDate,
                DeletedDate = applicant.DeletedDate,
                UserName = applicant.UserName,
                FirstName = applicant.FirstName,
                LastName = applicant.LastName,
                DateOfBirth = applicant.DateOfBirth,
                Email = applicant.Email,
                Password = applicant.Password,
                About = applicant.About
            };
            return applicantResponse;
        }

        public async Task<List<GetAllApplicantResponse>> GetAllAsync()
        {
            List<Applicant> applicants = await _applicantRepository.GetAllAsync();
            List<GetAllApplicantResponse> getAllApplicants = new List<GetAllApplicantResponse>();

            foreach (var applicant in applicants)
            {
                getAllApplicants.Add(new GetAllApplicantResponse()
                {
                    Id = applicant.Id,
                    CreatedDate = applicant.CreatedDate,
                    UpdatedDate = applicant.UpdatedDate,
                    UserName = applicant.UserName,
                    FirstName = applicant.FirstName,
                    LastName = applicant.LastName,
                    DateOfBirth = applicant.DateOfBirth,
                    Email = applicant.Email,
                    Password = applicant.Password,
                    About = applicant.About,
                });
            }

            return getAllApplicants;
        }

    }
}
