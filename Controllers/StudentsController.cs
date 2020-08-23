using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentRegistration.Dtos;
using StudentRegistration.Models;
using StudentRegistration.Repository;

namespace StudentRegistration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepo _repository;
        private readonly IMapper _mapper;

        public StudentsController(IStudentRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
       

        //Get api/students
        [HttpGet]
        public ActionResult <IEnumerable<StudentReadDto>> GetStudents()
        {
            var students = _repository.GetStudents();
            return Ok(_mapper.Map<IEnumerable<StudentReadDto>>(students));
        }

        //Get api/students/{id}
        [HttpGet("{id}", Name="GetStudentById")]
        public ActionResult <StudentReadDto> GetStudentById(int id)
        {
            var studentDetail = _repository.GetStudentById(id);
            if(studentDetail != null)
            {
                return Ok(_mapper.Map<StudentReadDto>(studentDetail));
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult <StudentReadDto> CreateCommand(StudentCreateDto student)
        {
            var commandModel = _mapper.Map<Student>(student);
            _repository.CreateStudent(commandModel);
            _repository.SaveChanges();

            var commandReadDto = _mapper.Map<StudentReadDto>(commandModel);
            return CreatedAtRoute(nameof(GetStudentById), new {Id = commandReadDto.Id}, commandReadDto);
        }
    }
}