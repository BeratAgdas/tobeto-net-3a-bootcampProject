using Business.Abstracts;
using Business.Requests.Instructor;
using Business.Responses.Instructor;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorController : ControllerBase
    {
        private readonly IInstructorService _instructorService;
        public InstructorController(IInstructorService instructorService)
        {
            _instructorService = instructorService;
        }
        [HttpGet("id")]
        public async Task<GetByIdInstructorResponse> GetAsync(int id)
        {
            return await _instructorService.GetAsync(id);
        }
        [HttpPost]
        public async Task<CreateInstructorResponse> AddAsync(CreateInstructorRequest request)
        {
            return await _instructorService.AddAsync(request);
        }
        [HttpPut]
        public async Task<UpdateInstructorResponse> UpdateAsync(UpdateInstructorRequest request)
        {
            return await _instructorService.UpdateAsync(request);
        }
        [HttpDelete]
        public async Task<DeleteInstructorResponse> DeleteAsync(DeleteInstructorRequest request)
        {
            return await _instructorService.DeleteAsync(request);
        }
        [HttpGet]
        public async Task<List<GetAllInstructorResponse>> GetAll()
        {
            return await _instructorService.GetAllAsync();
        }
    }
}
