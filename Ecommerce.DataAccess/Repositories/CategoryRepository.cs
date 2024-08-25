using Ecommerce.DataAccess.Contracts;
using Ecommerce.DataAccess.DatabaseContext;
using Ecommerce.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.DataAccess.Repositories;

public sealed class CategoryRepository : ICategoryRepository
{
    private readonly ApplicationDbContext _dbContext;
    public CategoryRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;        
    }
    public async Task<bool> Create(Category category)
    {
        _dbContext.Categories.Add(category); 
        return await _dbContext.SaveChangesAsync() > 0;
    }

    public async Task<bool> Delete(int id)
    {
        var category = await Get(id);
        if(category is not null)
        {
            _dbContext.Categories.Remove(category);
            return _dbContext.SaveChanges() > 0 ;
        }
        return false;
    }

    public async Task<IReadOnlyList<Category>> Get()
    {
        return await _dbContext.Categories.ToListAsync();
    }

    public async Task<Category?> Get(int id)
    {
       return await _dbContext.Categories.FindAsync(id);
    }

    public async Task<bool> Update(Category category)
    {
        var existingCategory = await Get(category.Id);
        if (existingCategory is not null) 
        {
            existingCategory.Name = category.Name;
            existingCategory.Description = category.Description;
            return _dbContext.SaveChanges() > 0;
        }
        return false;
    }
}
