using Arbus.Entities;
using Arbus.Servieces;
using FluentAssertions;
using MenuMaster.Api.Service.Contracts;
using MenuMaster.UnitTests.Fixtures;
using Moq;
using System;

namespace MenuMaster.UnitTests.Systems.Servieces
{
    public class TestMenuMaster
    {
        public TestMenuMaster()
        {
            // если бы нужно было подчищать, то реализовал бы IDisposable
        }
        #region GetAmountOfDishes

        [Fact]
        public async Task GetAmountOfDishes_EmptyList_ThrowsException()
        {
            var menu = new List<Dish>();//MenuFixtures.GetTestDishesEmpty();
            var menuMaster = new MenuMasterRepo(menu, 2);

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(async () => await menuMaster.GetAmountOfDishes());
        }

        [Fact]
        public async Task GetAmountOfDishes_InvalidAmountPerPage_ThrowsException()
        {
            var menu = new List<Dish>();//MenuFixtures.GetTestDishesEmpty();
            var menuMaster = new MenuMasterRepo(menu, 0);

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(async () => await menuMaster.GetAmountOfDishes());
        }

        [Fact]
        public async Task GetAmountOfDishes_ListOfDishes_ReturnInt()
        {
            // Arrange
            // ↓ реализаия Moq по фабуле не нужна, но если бы были внедрены зависимости ↓
            //var mockMenuMasterService = new Mock<IMenuMasterService>();
            //mockMenuMasterService.Setup(service => service.GetAmountOfDishes())
            //                     .ReturnsAsync(new int());
            var menu = MenuFixtures.GetTestDishes();
            var menuMaster = new MenuMasterRepo(menu, 1);

            // Act
            var result = await menuMaster.GetAmountOfDishes();

            // Assert
            result.Should().Be(5);
        }
        
        #endregion

        #region GetAmountOfPages
        [Theory]
        [InlineData(1, 9)]
        [InlineData(3, 3)]
        [InlineData(2, 5)]
        public async Task GetAmountOfPages_ListOfDishes_ReturnInt(int amount, int expected)
        {
            // Arrange
            var menu = MenuFixtures.GetTestDishes2();
            var menuMaster = new MenuMasterRepo(menu, amount);

            // Act
            var result = await menuMaster.GetAmountOfPages();

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public async Task GetAmountOfPages_EmptyList_ThrowsException()
        {
            var menu = MenuFixtures.GetTestDishesEmpty();
            var menuMaster = new MenuMasterRepo(menu, 2);

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(async () => await menuMaster.GetAmountOfPages());
        }
        #endregion

        #region GetAmountOfDishesOnPage
        [Theory]
        [InlineData(3,1,3)]
        [InlineData(3,2,2)]
        public async Task GetAmountOfDishesOnPage_PageId_ReturnInt(int amount,int pageId ,int expected)
        {
            // Arrange
            var menu = MenuFixtures.GetTestDishes();
            var menuMaster = new MenuMasterRepo(menu, amount);
            // Act
            var result = await menuMaster.GetAmountOfDishesOnPage(pageId);

            // Assert
            result.Should().Be(expected);
        }
        [Fact]
        public async Task GetAmountOfDishesOnPage_EmptyList_ThrowsException()
        {
            var menu = MenuFixtures.GetTestDishesEmpty();
            var menuMaster = new MenuMasterRepo(menu, 2);

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(async () => await menuMaster.GetAmountOfDishesOnPage(1));
        }
        [Theory]
        [InlineData(-1)]
        [InlineData(55)]
        public async Task GetAmountOfDishesOnPage_InvalidPageId_ThrowsException(int pageId)
        {
            var menu = MenuFixtures.GetTestDishes();
            var menuMaster = new MenuMasterRepo(menu, 2);

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(async () => await menuMaster.GetAmountOfDishesOnPage(pageId));
        }
        #endregion

        #region GetDishesOnPage
        [Fact] 
        public async Task GetDishesOnPage_PageId_ShouldBeList()
        {
            var menu = MenuFixtures.GetTestDishes();
            var menuMaster = new MenuMasterRepo(menu, 3);

            //Act
            var result = await menuMaster.GetDishesOnPage(2);

            //Assert
            result.Should().BeOfType<List<Dish>>();
        }

        [Fact]
        public async Task GetDishesOnPage_PageId_ReturnListOfDishes()
        {
            // Arrange
            var menu = MenuFixtures.GetTestDishes();
            var menuMaster = new MenuMasterRepo(menu, 3);
            var expected = new List<Dish> {
            new Dish
            {
                DishId = 3,
                DishName = "Eskimo",
                DishDescriptions = "ice cream"
            },
            new Dish
            {
                DishId = 4,
                DishName = "Latte",
                DishDescriptions = "Another coffee"
            }};

            // Act
            var result = await menuMaster.GetDishesOnPage(2);

            // Assert
            result.Should().BeOfType<List<Dish>>();
            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public async Task GetDishesOnPage_EmptyList_ThrowsException()
        {
            var menu = MenuFixtures.GetTestDishesEmpty();
            var menuMaster = new MenuMasterRepo(menu, 2);

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(async () => await menuMaster.GetDishesOnPage(1));
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(55)]
        public async Task GetDishesOnPage_InvalidPageId_ThrowsException(int pageId)
        {
            var menu = MenuFixtures.GetTestDishes2();
            var menuMaster = new MenuMasterRepo(menu, 2);

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(async () => await menuMaster.GetDishesOnPage(pageId));
        }

        #endregion

        #region GetAllFirstDishesOnPages
        [Fact]
        public async Task GetAllFirstDishesOnPages_ListOfDishes_ShouldBeList()
        {
            var menu = MenuFixtures.GetTestDishes2();
            var menuMaster = new MenuMasterRepo(menu, 3);

            //Act
            var result = await menuMaster.GetAllFirstDishesOnPages();

            //Assert
            result.Should().BeOfType<List<Dish>>();
        }


        [Fact] // ТАК-ТО ПРАВИЛЬНО,ПРОСТО ПОЧЕМУ-ТО НЕ ЭКВИВАЛЕНТ
        public async Task GetAllFirstDishesOnPages_ListOfDishes_ReturnListOFDishes()
        {
            //Arrange
            var menu = MenuFixtures.GetTestDishes2();
            var menuMaster = new MenuMasterRepo(menu, 3);
            var expected = new List<Dish> { menu[0], menu[3], menu[6] };
            //Act
            var result = await menuMaster.GetAllFirstDishesOnPages();
            //Assert
            result.Should().ContainEquivalentOf(expected);
        }

        [Fact]
        public async Task GetAllFirstDishesOnPages_EmptyList_ThrowsException()
        {
            var menu = MenuFixtures.GetTestDishesEmpty();
            var menuMaster = new MenuMasterRepo(menu, 2);

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(async () => await menuMaster.GetAllFirstDishesOnPages());
        }
        #endregion
    }
}