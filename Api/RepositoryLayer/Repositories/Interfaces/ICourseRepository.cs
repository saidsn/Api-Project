﻿using DomainLayer.Entities;

namespace RepositoryLayer.Repositories.Interfaces
{
    public interface ICourseRepository : IRepository<Course>
    {
        Task<Course> GetWithAuthorsAndStudentsAsync(int id);
    }
}
