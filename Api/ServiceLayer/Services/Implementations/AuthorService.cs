﻿using AutoMapper;
using DomainLayer.Entities;
using RepositoryLayer.Repositories.Interfaces;
using ServiceLayer.DTO_s.Author;
using ServiceLayer.Helpers;
using ServiceLayer.Services.Interfaces;

namespace ServiceLayer.Services.Implementations
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;

        public AuthorService(IAuthorRepository authorRepository, ICourseRepository courseRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _courseRepository = courseRepository;
            _mapper = mapper;
        }


        public async Task<AuthorDto> GetAsync(int id)
        {
            return _mapper.Map<AuthorDto>(await _authorRepository.GetWithCoursesAsync(id));
        }


        public async Task<List<AuthorListDto>> GetAllAsync()
        {
            var authors = await _authorRepository.GetAllWithCoursesAsync();

            return _mapper.Map<List<AuthorListDto>>(authors);
        }


        public async Task CreateAsync(AuthorCreateDto authorCreateDto)
        {
            if (authorCreateDto.CourseIds != null && authorCreateDto.CourseIds.Any())
            {
                var courses = await _authorRepository.FindAllByExpression(c => authorCreateDto.CourseIds.Contains(c.Id));

                var mapAuthor = _mapper.Map<Author>(authorCreateDto);

                mapAuthor.Image = await authorCreateDto.Photo.GetBytes();

                mapAuthor.CourseAuthors = new List<CourseAuthor>();

                foreach (var course in courses)
                {
                    var courseAuthor = new CourseAuthor
                    {
                        CourseId = course.Id,
                        AuthorId = mapAuthor.Id
                    };
                    mapAuthor.CourseAuthors.Add(courseAuthor);
                }

                await _authorRepository.Create(mapAuthor);
            }
            else
            {
                throw new Exception("You must select at least one course.");
            }
        }


        public async Task UpdateAsync(int id, AuthorUpdateDto authorUpdateDto)
        {
            if (authorUpdateDto.CourseIds != null && authorUpdateDto.CourseIds.Any())
            {
                var courses = await _courseRepository.FindAllByExpression(c => authorUpdateDto.CourseIds.Contains(c.Id));

                var dbAuthor = await _authorRepository.GetWithCoursesAsync(id);

                await _authorRepository.DeleteCourseAuthor(dbAuthor.CourseAuthors.ToList());

                foreach (var course in courses)
                {
                    var courseAuthor = new CourseAuthor
                    {
                        AuthorId = id,
                        CourseId = course.Id
                    };

                    dbAuthor.CourseAuthors?.Add(courseAuthor);
                }

                var mapAuthor = _mapper.Map(authorUpdateDto, dbAuthor);

                mapAuthor.Image = await authorUpdateDto.Photo.GetBytes();

                await _authorRepository.Update(mapAuthor);
            }
            else
            {
                throw new Exception("You must select at least one author.");
            }
        }


        public async Task DeleteAsync(int id)
        {
            await _authorRepository.Delete(await _authorRepository.Get(id));
        }
    }
}
