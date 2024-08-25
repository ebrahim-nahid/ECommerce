using Ecommerce.DataAccess.Contracts;
using Ecommerce.DataAccess.Entities;
using Ecommerce.Service.Contracts;
using Ecommerce.Service.DTOs;

namespace Ecommerce.Service.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }
    public async Task<bool> Create(CreateCategoryDto categoryDto)
    {
        var category = new Category
        {
            Name = categoryDto.Name,
            Description = categoryDto.Description
        };
       return await _categoryRepository.Create(category);
    }

    public async Task<bool> Delete(int id)
    {
        return await _categoryRepository.Delete(id);
    }

    public Task<IReadOnlyList<Category>> Get()
    {
        return _categoryRepository.Get();
    }

    public async Task<Category> Get(int id)
    {
       return await _categoryRepository.Get(id);
    }

    public async Task<bool> Update(Category category)
    {
       return await _categoryRepository.Update(category);
    }
}
