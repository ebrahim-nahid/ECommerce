using Ecommerce.Service.Contracts;
using Ecommerce.Service.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Web.Controllers;

public class CategoryController : Controller
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
       var categories = await _categoryService.Get();
        return View(categories);
    }
    //public Task<IActionResult> Detail(int id) 
    //{

    //}

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateCategoryDto category)
    {
        if (category != null)
        {
            var isSuccess = await _categoryService.Create(category);
            if(isSuccess)
            {
                return RedirectToAction(nameof(Index));
            }
        }
        return View(category);
    }


}
