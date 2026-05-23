using FluentAssertions;
using JewelryStore.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using JewelryStore.Data;
using JewelryStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentLibrary2.Test.UnitTests.Pages.Book
{
    public class CreateModelTests
    {
        private ApplicationDbContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            return new ApplicationDbContext(options);
        }

        [Fact]
        public void OnPost_ShouldAddProductAndRedirect_WhenModelStateIsValid()
        {
            // Arrange
            var context = GetDbContext();
            var pageModel = new JewelryStore.Pages.Decoration.CreateModel(context);

            pageModel.TheProduct = new TheProduct
            {
                Title = "Золотое кольцо",
                Price = 15000,
                Product = "Кольцо",
                Test = 585,
                ProductionDate = 2024,
                Name = "Изумрудное кольцо"
            };

            // Act
            var result = pageModel.OnPost();

            // Assert
            result.Should().BeOfType<RedirectToPageResult>();
            var redirectResult = result as RedirectToPageResult;
            redirectResult.PageName.Should().Be("Index");
            context.TheProducts.Count().Should().Be(1);
            context.TheProducts.First().Title.Should().Be("Золотое кольцо");
        }

        [Fact]
        public void OnPost_ShouldNotAddProduct_WhenModelStateIsInvalid()
        {
            // Arrange
            var context = GetDbContext();
            var pageModel = new JewelryStore.Pages.Decoration.CreateModel(context);

            pageModel.ModelState.AddModelError("Price", "Price is required");
            pageModel.TheProduct = new TheProduct
            {
                Title = "Золотое кольцо"
                // Price не указан, что вызовет ошибку валидации
            };

            // Act
            var result = pageModel.OnPost();

            // Assert
            result.Should().BeOfType<PageResult>();
            context.TheProducts.Count().Should().Be(0);
        }
    }
}
