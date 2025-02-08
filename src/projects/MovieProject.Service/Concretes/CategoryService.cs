using MovieProject.Model.Dtos.Categories;
using MovieProject.Service.Abstracts;
using MovieProject.DataAccess.Repositories.Concretes;
using MovieProject.DataAccess.Repositories.Abstracts;
using MovieProject.DataAccess.Contexts;
using MovieProject.Model.Entities;
using MovieProject.Service.Mappers.Categories;
using Core.CrossCuttingConcerns.Exceptions;
using MovieProject.Service.Constants.Categories;
using MovieProject.Service.BusinessRules.Categories;
namespace MovieProject.Service.Concretes;

public sealed class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly ICategoryMapper _categoryMapper;
    private readonly CategoryBusinessRules _businessRules;

    public CategoryService(ICategoryRepository categoryRepository, ICategoryMapper categoryMapper, CategoryBusinessRules businessRules)
    {
        _categoryRepository = categoryRepository;
        _categoryMapper = categoryMapper;
        _businessRules = businessRules;
    }

    public void Add(CategoryAddRequestDto dto)
    {
        // Validasyon kuralı

        //iş kuralı
        _businessRules.CategoryNameMustBeUnique(dto.Name);
        Category category = _categoryMapper.ConvertToEntity(dto);
        _categoryRepository.Add(category);
    }

    public void Delete(int id)
    {
        _businessRules.CategoryIsPresent(id);
        var category = _categoryRepository.GetById(id);
        _categoryRepository.Delete(category!);
    }

    public List<CategoryResponseDto> GetAll()
    {
        List<Category> categories = _categoryRepository.GetAll();
        List<CategoryResponseDto> response = _categoryMapper.ConvertToResponseList(categories);
        return response;
    }

    public CategoryResponseDto? GetById(int id)
    {
        _businessRules.CategoryIsPresent(id);

        Category? category = _categoryRepository.GetById(id);


        CategoryResponseDto categoryResponseDto = _categoryMapper.ConvertToResponse(category);
        return categoryResponseDto;
    }

    public void Update(CategoryUpdateRequestDto dto)
    {
        _businessRules.CategoryIsPresent(dto.Id);
        Category? category = _categoryRepository.GetById(dto.Id);
        category.Name = dto.Name;
        _categoryRepository.Update(category);
    }
}
