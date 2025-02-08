﻿using Core.CrossCuttingConcerns.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieProject.Model.Dtos.Categories;
using MovieProject.Service.Abstracts;
using MovieProject.Service.Concretes;

namespace MovieProject.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    //Constructor arg injection
    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    // propert Injection
    //public ICategoryService CategoryService { get; set; }


    // Method Injection
    //[HttpPost("add")]
    //public IActionResult Add(CategoryAddRequestDto dto, ICategoryService categoryService)
    //{
    //    _categoryService.Add(dto);
    //    return Ok("Kategori başarıyla eklendi.");
    //}

    [HttpPost("add")]
    public IActionResult Add(CategoryAddRequestDto dto)
    {
        try
        {
            _categoryService.Add(dto);
            return Ok("Kategori başarıyla eklendi.");

        }
        catch (BusinessException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("getall")]
    public IActionResult GetAll()
    {
        var response = _categoryService.GetAll();
        return Ok(response);
    }

    [HttpGet("getbyid")]
    public IActionResult GetById(int id)
    {
        try
        {
            var response = _categoryService.GetById(id);
            return Ok(response);

        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    [HttpPut("update")]
    public IActionResult Update(CategoryUpdateRequestDto dto)
    {
        try
        {
            _categoryService.Update(dto);
            return Ok("Kategori güncellendi.");
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    [HttpDelete("delete")]
    public IActionResult Delete(int id)
    {
        try
        {
            _categoryService.Delete(id);
            return Ok("Kategori silindi.");
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }
}
