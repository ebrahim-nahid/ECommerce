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

    public async Task<UpdateCategoryDto> Get(int id)
    {
       var category = await _categoryRepository.Get(id);

        var updateCategoryDto = new UpdateCategoryDto()
        {
            Id = category.Id,
            Name = category.Name,
            Description = category.Description
        };
        return updateCategoryDto;
    }

    public async Task<bool> Update(UpdateCategoryDto updateCategoryDto)
    {
        var category = new Category()
        {
            Id= updateCategoryDto.Id,
            Name = updateCategoryDto.Name,
            Description = updateCategoryDto.Description
        };
       return await _categoryRepository.Update(category);
    }
}
