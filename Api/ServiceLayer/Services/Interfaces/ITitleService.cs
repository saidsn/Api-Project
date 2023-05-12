﻿using DomainLayer.Entities;
using ServiceLayer.DTOs.Title;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Interfaces
{
    public interface ITitleService
    {
        Task<TitleDto> GetAsync(int id);
        Task<List<TitleListDto>> GetAllAsync();
        Task CreateAsync(TitleCreateDto titleCreateDto);
<<<<<<< HEAD
        Task DeleteAsync(int id);
        Task UpdateAsync(int id, TitleUpdateDto titleUpdateDto);
=======
>>>>>>> 44390bf0eff2aded80d32a3e84ecc86dfb4ff0a7

    }
}
