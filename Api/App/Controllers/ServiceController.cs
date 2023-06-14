﻿using Microsoft.AspNetCore.Mvc;
using ServiceLayer.DTO_s.Service;
using ServiceLayer.Services.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace App.Controllers
{
    public class ServiceController : AppController
    {
        private readonly IServiceService _service;

        public ServiceController(IServiceService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get([Required] int id)
        {
            try
            {
                return Ok(await _service.GetAsync(id));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _service.GetAllAsync());
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] ServiceCreateDto serviceCreateDto)
        {
            try
            {
                await _service.CreateAsync(serviceCreateDto);

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest(new { ErrorMessage = "Not Created" });
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([Required] int id)
        {
            try
            {
                await _service.DeleteAsync(id);

                return Ok();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPut, Route("{id}")]
        public async Task<IActionResult> Update([Required][FromRoute] int id, [FromForm] ServiceUpdateDto serviceUpdateDto)
        {
            try
            {
                await _service.UpdateAsync(id, serviceUpdateDto);

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest(new { ErrorMessage = "Not Updated" });
            }
        }
    }
}
