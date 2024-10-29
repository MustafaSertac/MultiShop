﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Services.CategoryServices;

namespace MultiShop.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController:ControllerBase
    {
        private readonly ICategoryService _categoryService;

        // Corrected the parameter to be of type ICategoryService
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet]

        public async Task<IActionResult> CategoryList()
        {
            var values= await _categoryService.GetAllCategoriesAsync();
            return Ok(values); 

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(string id)
        {
            var values= await _categoryService.GetByIdCategoryAsync(id);
            return Ok(values);

        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            await _categoryService.CreateCategoryAsync(createCategoryDto);
            return Ok("Kategori Başarıyla Eklendi");
        }
        [HttpDelete]

        public async Task<IActionResult> DeleteCategory(string id)
        {
            await _categoryService.DeleteCategoryAsync(id);
            return Ok("Kategori Başarıyla Silindi");
        }

        [HttpPut]

        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            await _categoryService.UpdateCategoryAsync(updateCategoryDto);

            return Ok("Kategori Başarıyla Güncellendi");
        }
    }
}
