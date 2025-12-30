
using Entities;
using Microsoft.EntityFrameworkCore;
using Repository;
using System.Threading.Tasks;
using TestProject;
using Xunit;

public class CategoryIntegrationTest : IClassFixture<DataBaseFixture>
{
    private readonly CategoryRepository _categoryRepository;
    private readonly DataBaseFixture _fixture;

    public CategoryIntegrationTest(DataBaseFixture fixture)
    {
        _fixture = fixture;
        _categoryRepository = new CategoryRepository(_fixture.Context);
    }

    [Fact]
    public async Task GetCategories_ReturnsAllCategories()
    {
        // הוספת נתונים בבדיקה זו
        _fixture.Context.CategoriesTbls.AddRange(
            new CategoriesTbl { CategoryName = "Electronics" },
            new CategoriesTbl { CategoryName = "Clothing" },
            new CategoriesTbl { CategoryName = "Books" }
        );
        await _fixture.Context.SaveChangesAsync();

        // Act - קריאה למתודה
        var categories = await _categoryRepository.getCategories();

        // Assert
        Assert.NotNull(categories);
        Assert.Equal(3, categories.Count);
        Assert.Contains(categories, c => c.CategoryName == "Electronics");
        Assert.Contains(categories, c => c.CategoryName == "Clothing");
        Assert.Contains(categories, c => c.CategoryName == "Books");
    }

    [Fact]
    public async Task GetCategories_ReturnsEmptyListWhenNoCategoriesExist()
    {
        // נקה את הנתונים מהקטגוריות
        _fixture.Context.CategoriesTbls.RemoveRange(_fixture.Context.CategoriesTbls);
        await _fixture.Context.SaveChangesAsync();

        // Act - קריאה למתודה
        var categories = await _categoryRepository.getCategories();

        // Assert
        Assert.NotNull(categories);
        Assert.Empty(categories);
    }
}