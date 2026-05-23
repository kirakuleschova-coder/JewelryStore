using JewelryStore.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryStore.Tests.UnitTests.Model
{
    public class TheProductTests
    {
        [Fact]
        public void TheProduct_WithValidData_ShouldBeValid()
        {
            // Создаем объект продукта с валидными значениями.
            var product = new TheProduct
            {
                Title = "Золотое кольцо",     // Обязательное поле, строка < 100 символов
                Price = 15000,                // Цена должна быть положительной
                Product = "Кольцо",           // Обязательное поле, строка < 100 символов
                Test = 585,                   // Проба в пределах 375-999
                ProductionDate = 2024,        // В пределах допустимого диапазона 1900-2025
                Name = "Изумрудное кольцо"    // Необязательное поле
            };

            // Создаем контекст валидации на основе объекта
            var context = new ValidationContext(product);

            // Сюда будут записаны ошибки валидации, если они есть
            var result = new List<ValidationResult>();

            // Проводим валидацию объекта с учетом всех атрибутов [Required], [Range] и т.п.
            var isValid = Validator.TryValidateObject(product, context, result, true);

            // Ожидаем, что валидация прошла успешно (все поля корректны)
            Assert.True(isValid);

            // Также убеждаемся, что список ошибок пуст
            Assert.Empty(result);
        }

        // Тест проверяет, что если указать неправильную пробу, то объект будет невалиден.
        [Fact]
        public void TheProduct_WithInvalidTest_ShouldBeInvalid()
        {
            // Arrange
            var product = new TheProduct
            {
                Title = "Золотое кольцо",
                Price = 15000,
                Product = "Кольцо",
                Test = 9999, // ❗ недопустимое значение пробы
                ProductionDate = 2024,
                Name = "Изумрудное кольцо"
            };

            var context = new ValidationContext(product);
            var results = new List<ValidationResult>();

            // Act
            var isValid = Validator.TryValidateObject(product, context, results, true);

            // Assert
            Assert.False(isValid);
            Assert.Contains(results, r => r.ErrorMessage.Contains("Проба должна быть"));
        }

        // Тест проверяет, что если указать неправильный год производства, то объект будет невалиден.
        [Fact]
        public void TheProduct_WithInvalidProductionDate_ShouldBeInvalid()
        {
            // Arrange
            var product = new TheProduct
            {
                Title = "Золотое кольцо",
                Price = 15000,
                Product = "Кольцо",
                Test = 585,
                ProductionDate = 1800, // ❗ недопустимый год
                Name = "Изумрудное кольцо"
            };

            var context = new ValidationContext(product);
            var results = new List<ValidationResult>();

            // Act
            var isValid = Validator.TryValidateObject(product, context, results, true);

            // Assert
            Assert.False(isValid);
            Assert.Contains(results, r => r.ErrorMessage.Contains("Год производства должен быть"));
        }

        // Тест проверяет, что если не указать название, то объект будет невалиден.
        [Fact]
        public void TheProduct_WithoutTitle_ShouldBeInvalid()
        {
            // Arrange
            var product = new TheProduct
            {
                Title = null, // ❗ отсутствует обязательное поле
                Price = 15000,
                Product = "Кольцо",
                Test = 585,
                ProductionDate = 2024,
                Name = "Изумрудное кольцо"
            };

            var context = new ValidationContext(product);
            var results = new List<ValidationResult>();

            // Act
            var isValid = Validator.TryValidateObject(product, context, results, true);

            // Assert
            Assert.False(isValid);
            Assert.Contains(results, r => r.ErrorMessage.Contains("Название обязательно"));
        }

        // Тест проверяет, что если указать отрицательную цену, то объект будет невалиден.
        [Fact]
        public void TheProduct_WithNegativePrice_ShouldBeInvalid()
        {
            // Arrange
            var product = new TheProduct
            {
                Title = "Золотое кольцо",
                Price = -1000, // ❗ отрицательная цена
                Product = "Кольцо",
                Test = 585,
                ProductionDate = 2024,
                Name = "Изумрудное кольцо"
            };

            var context = new ValidationContext(product);
            var results = new List<ValidationResult>();

            // Act
            var isValid = Validator.TryValidateObject(product, context, results, true);

            // Assert
            Assert.False(isValid);
            Assert.Contains(results, r => r.ErrorMessage.Contains("Цена должна быть"));
        }
    }
}