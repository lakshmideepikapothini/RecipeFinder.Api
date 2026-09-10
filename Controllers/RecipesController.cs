using Microsoft.AspNetCore.Mvc;
using RecipeFinder.Api.Services;

namespace RecipeFinder.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RecipesController : ControllerBase
{
    private readonly RecipeService _recipeService;

    public RecipesController(RecipeService recipeService)
    {
        _recipeService = recipeService;
    }

    [HttpGet("search")]
    public async Task<IActionResult> Search(string query)
    {
        if (string.IsNullOrWhiteSpace(query))
        {
            return BadRequest("Please enter a recipe or ingredient to search.");
        }

        var recipes = await _recipeService.SearchRecipesAsync(query);

        return Ok(recipes);
    }
}