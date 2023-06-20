﻿using AutoMapper;
using DomainLayer.Entities;
using RepositoryLayer.Repositories.Interfaces;
using ServiceLayer.DTO_s.Student;
using ServiceLayer.Helpers;
using ServiceLayer.Services.Interfaces;

namespace ServiceLayer.Services.Implementations
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;

        public StudentService(IStudentRepository studentRepository,
            ICourseRepository courseRepository,
            IMapper mapper)

        {
            _studentRepository = studentRepository;
            _courseRepository = courseRepository;
            _mapper = mapper;
        }


        public async Task<StudentDto> GetAsync(int id)
        {
            return _mapper.Map<StudentDto>(await _studentRepository.GetWithCoursesAsync(id));
        }


        public async Task<List<StudentListDto>> GetAllAsync()
        {
            return _mapper.Map<List<StudentListDto>>(await _studentRepository.GetAllWithCoursesAsync());
        }


        public async Task CreateAsync(StudentCreateDto studentCreateDto)
        {
            var course = await _courseRepository.Get(studentCreateDto.CourseId);

            var mapStudent = _mapper.Map<Student>(studentCreateDto);

            mapStudent.Image = await studentCreateDto.Photo.GetBytes();

            mapStudent.Course = course;

            await _studentRepository.Create(mapStudent);
        }


        public async Task DeleteAsync(int id)
        {
            await _studentRepository.Delete(await _studentRepository.Get(id));
        }
    }
}
