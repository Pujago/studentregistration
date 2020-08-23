using AutoMapper;
using StudentRegistration.Dtos;
using StudentRegistration.Models;

namespace StudentRegistration.Profiles
{
    public class StudentsProfile : Profile
    {
        public StudentsProfile()
        {
            CreateMap<Student, StudentReadDto>();
            CreateMap<StudentCreateDto, Student>();
        }
    }
}