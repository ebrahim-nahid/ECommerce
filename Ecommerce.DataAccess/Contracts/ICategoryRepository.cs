using Ecommerce.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DataAccess.Contracts;

public interface ICategoryRepository
{
    Task<bool> Create(Category category);
    Task<IReadOnlyList<Category>> Get();
    Task<Category> Get(int id);
    Task<bool> Update(Category category);
    Task<bool> Delete(int id);
}
