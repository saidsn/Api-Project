﻿using ServiceLayer.DTO_s.Author;

namespace ServiceLayer.Services.Interfaces
{
    public interface IAuthorService
    {
        Task<AuthorDto> GetAsync(int id);
        Task<List<AuthorListDto>> GetAllAsync();
        Task CreateAsync(AuthorCreateDto authorCreateDto);
        Task UpdateAsync(int id, AuthorUpdateDto authorUpdateDto);
        Task DeleteAsync(int id);
    }
}