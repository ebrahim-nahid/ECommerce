using Ecommerce.DataAccess.Entities;
using Ecommerce.Service.DTOs;

namespace Ecommerce.Service.Contracts;

public interface ICategoryService
{
    Task<bool> Create(CreateCategoryDto category);
    Task<IReadOnlyList<Category>> Get();
    Task<UpdateCategoryDto> Get(int id);
    Task<bool> Update(UpdateCategoryDto category);
    Task<bool> Delete(int id);
}
