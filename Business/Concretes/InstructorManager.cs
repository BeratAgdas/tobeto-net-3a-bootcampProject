using Business.Abstracts;
using Business.Requests.Instructor;
using Business.Responses.Instructor;
using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class InstructorManager : IInstructorService
    {
        private readonly IInstructorRepository _intructorRepository;
        public InstructorManager(IInstructorRepository instructorRepository)
        {
            _intructorRepository = instructorRepository;
        }
        public async Task<GetByIdInstructorResponse> GetAsync(int id)
        {
            Instructor instructor = await _intructorRepository.GetAsync(i => i.Id == id);
            GetByIdInstructorResponse instructorResponse = new GetByIdInstructorResponse()
            {
                Id = instructor.Id,
                CreatedDate = instructor.CreatedDate,
                UpdatedDate = instructor.UpdatedDate,
                UserName = instructor.UserName,
                FirstName = instructor.FirstName,
                LastName = instructor.LastName,
                DateOfBirth = instructor.DateOfBirth,
                Email = instructor.Email,
                Password = instructor.Password,
                CompanyName = instructor.CompanyName
            };
            return instructorResponse;
        }
        public async Task<CreateInstructorResponse> AddAsync(CreateInstructorRequest request)
        {
            Instructor instructor = new Instructor()
            {
                CreatedDate = DateTime.Now,
                UserName = request.UserName,
                FirstName = request.FirstName,
                LastName = request.LastName,
                DateOfBirth = request.DateOfBirth,
                Email = request.Email,
                Password = request.Password,
                CompanyName = request.CompanyName
            };
            await _intructorRepository.AddAsync(instructor);

            CreateInstructorResponse instructorResponse = new CreateInstructorResponse()
            {
                Id = instructor.Id,
                CreatedDate = instructor.CreatedDate,
                UserName = instructor.UserName,
                FirstName = instructor.FirstName,
                LastName = instructor.LastName,
                DateOfBirth = instructor.DateOfBirth,
                Email = instructor.Email,
                Password = instructor.Password,
                CompanyName = instructor.CompanyName
            };
            return instructorResponse;
        }
        public async Task<UpdateInstructorResponse> UpdateAsync(UpdateInstructorRequest request)
        {
            Instructor instructor = await _intructorRepository.GetAsync(i => i.Id == request.Id);
            instructor.UpdatedDate = DateTime.Now;
            instructor.UserName = request.UserName;
            instructor.FirstName = request.FirstName;
            instructor.LastName = request.LastName;
            instructor.DateOfBirth = request.DateOfBirth;
            instructor.Email = request.Email;
            instructor.Password = request.Password;
            instructor.CompanyName = request.CompanyName;

            await _intructorRepository.UpdateAsync(instructor);
            UpdateInstructorResponse instructorResponse = new UpdateInstructorResponse()
            {
                Id = instructor.Id,
                CreatedDate = instructor.CreatedDate,
                UpdatedDate = instructor.UpdatedDate,
                UserName = instructor.UserName,
                FirstName = instructor.FirstName,
                LastName = instructor.LastName,
                DateOfBirth = instructor.DateOfBirth,
                Email = instructor.Email,
                Password = instructor.Password,
                CompanyName = instructor.CompanyName
            };
            return instructorResponse;
        }
        public async Task<DeleteInstructorResponse> DeleteAsync(DeleteInstructorRequest request)
        {
            Instructor instructor = await _intructorRepository.GetAsync(i => i.Id == request.Id);
            instructor.DeletedDate = DateTime.Now;

            await _intructorRepository.DeleteAsync(instructor);

            DeleteInstructorResponse instructorResponse = new DeleteInstructorResponse()
            {
                Id = instructor.Id,
                CreatedDate = instructor.CreatedDate,
                UpdatedDate = instructor.UpdatedDate,
                DeletedDate= instructor.DeletedDate,
                UserName = instructor.UserName,
                FirstName = instructor.FirstName,
                LastName = instructor.LastName,
                DateOfBirth = instructor.DateOfBirth,
                Email = instructor.Email,
                Password = instructor.Password,
                CompanyName = instructor.CompanyName
            };
            return instructorResponse;
        }

        public async Task<List<GetAllInstructorResponse>> GetAllAsync()
        {
            List<Instructor> instructors =await _intructorRepository.GetAllAsync();
            List<GetAllInstructorResponse> getAllInstructors=new List<GetAllInstructorResponse>();

            foreach (var instructor in instructors)
            {
                getAllInstructors.Add(new GetAllInstructorResponse()
                {
                    Id = instructor.Id,
                    CreatedDate = instructor.CreatedDate,
                    UpdatedDate = instructor.UpdatedDate,
                    UserName = instructor.UserName,
                    FirstName = instructor.FirstName,
                    LastName = instructor.LastName,
                    DateOfBirth = instructor.DateOfBirth,
                    Email = instructor.Email,
                    Password = instructor.Password,
                    CompanyName = instructor.CompanyName
                });
            }
            return getAllInstructors;
        }
    }
}
