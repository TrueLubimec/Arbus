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
            var menu = MenuFixtures.GetTestDishesEmpty();
            var menuMaster = new MenuMasterRepo(menu, 2);

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(async () => await menuMaster.GetAmountOfDishes());
        }

        [Fact]
        public async Task GetAmountOfDishes_InvalidAmountPerPage_ThrowsException()
        {
            var menu = MenuFixtures.GetTestDishesEmpty();
            var menuMaster = new MenuMasterRepo(menu, 0);

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(async () => await menuMaster.GetAmountOfDishes());
        }

        [Theory]
        [InlineData(1, 2, 5)]
        [InlineData(2, 2, 6)]
        [InlineData(3, 2, 11)]
        [InlineData(4, 2, 9)]
        public async Task GetAmountOfDishes_ListOfDishes_ReturnInt(int menuVersion, int perPage, int expected)
        {
            // Arrange
            // ↓ реализаия Moq по фабуле не нужна, но если бы были внедрены зависимости ↓
            //var mockMenuMasterService = new Mock<IMenuMasterService>();
            //mockMenuMasterService.Setup(service => service.GetAmountOfDishes())
            //                     .ReturnsAsync(new int());
            var menu = MenuFixtures.GetTestDishes(menuVersion);
            var menuMaster = new MenuMasterRepo(menu, perPage);

            // Act
            var result = await menuMaster.GetAmountOfDishes();

            // Assert
            result.Should().Be(expected);
        }

        #endregion

        #region GetAmountOfPages

        [Fact]
        public async Task GetAmountOfPages_EmptyList_ThrowsException()
        {
            var menu = MenuFixtures.GetTestDishesEmpty();
            var menuMaster = new MenuMasterRepo(menu, 2);

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(async () => await menuMaster.GetAmountOfPages());
        }

        [Fact]
        public async Task GetAmountOfPages_InvalidAmountPerPage_ThrowsException()
        {
            var menu = MenuFixtures.GetTestDishes(1);
            var menuMaster = new MenuMasterRepo(menu, 0);

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(async () => await menuMaster.GetAmountOfPages());
        }

        [Theory]
        [InlineData(1, 1, 5)]
        [InlineData(2, 5, 2)]
        [InlineData(3, 2, 6)]
        [InlineData(4, 9, 1)]
        public async Task GetAmountOfPages_ListOfDishes_ReturnInt(int menuVersion,int perPage, int expected)
        {
            // Arrange
            var menu = MenuFixtures.GetTestDishes(menuVersion);
            var menuMaster = new MenuMasterRepo(menu, perPage);

            // Act
            var result = await menuMaster.GetAmountOfPages();

            // Assert
            result.Should().Be(expected);
        }
        #endregion

        #region GetAmountOfDishesOnPage

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
            var menu = MenuFixtures.GetTestDishes(1);
            var menuMaster = new MenuMasterRepo(menu, 2);

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(async () => await menuMaster.GetAmountOfDishesOnPage(pageId));
        }

        [Fact]
        public async Task GetAmountOfDishesOnPage_InvalidAmountPerPage_ThrowsException()
        {
            var menu = new List<Dish>();//MenuFixtures.GetTestDishesEmpty();
            var menuMaster = new MenuMasterRepo(menu, 0);

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(async () => await menuMaster.GetAmountOfDishesOnPage(1));
        }

        [Theory]
        [InlineData(1, 4, 2, 1)] 
        [InlineData(1, 2, 2, 2)]
        [InlineData(3, 4, 3, 3)]
        [InlineData(4, 1, 3, 1)]
        public async Task GetAmountOfDishesOnPage_PageId_ReturnInt(int menuVersion,int perPage,int pageId ,int expected)
        {
            // Arrange
            var menu = MenuFixtures.GetTestDishes(menuVersion);
            var menuMaster = new MenuMasterRepo(menu, perPage);
            // Act
            var result = await menuMaster.GetAmountOfDishesOnPage(pageId);

            // Assert
            result.Should().Be(expected);
        }
        
        #endregion

        #region GetDishesOnPage
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
            var menu = MenuFixtures.GetTestDishes(1);
            var menuMaster = new MenuMasterRepo(menu, 2);

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(async () => await menuMaster.GetDishesOnPage(pageId));
        }

        [Fact]
        public async Task GetDishesOnPage_InvalidAmountPerPage_ThrowsException()
        {
            var menu = MenuFixtures.GetTestDishesEmpty();
            var menuMaster = new MenuMasterRepo(menu, 0);

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(async () => await menuMaster.GetDishesOnPage(1));
        }

        [Fact]
        public async Task GetDishesOnPage_PageId_ShouldBeList()
        {
            var menu = MenuFixtures.GetTestDishes(1);
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
            var menu = MenuFixtures.GetTestDishes(1);
            var menuMaster = new MenuMasterRepo(menu, 3);
            var expected = new List<Dish> { menu[3], menu[4] };

            // Act
            var result = await menuMaster.GetDishesOnPage(2);

            // Assert
            result.Should().BeEquivalentTo(expected);
        }
        #endregion

        #region GetAllFirstDishesOnPages
        [Fact]
        public async Task GetAllFirstDishesOnPages_EmptyList_ThrowsException()
        {
            var menu = MenuFixtures.GetTestDishesEmpty();
            var menuMaster = new MenuMasterRepo(menu, 2);

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(async () => await menuMaster.GetAllFirstDishesOnPages());
        }

        [Fact]
        public async Task GetAllFirstDishesOnPages_InvalidAmountPerPage_ThrowsException()
        {
            var menu = new List<Dish>();//MenuFixtures.GetTestDishesEmpty();
            var menuMaster = new MenuMasterRepo(menu, 0);

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(async () => await menuMaster.GetAllFirstDishesOnPages());
        }

        [Fact]
        public async Task GetAllFirstDishesOnPages_ListOfDishes_ShouldBeList()
        {
            var menu = MenuFixtures.GetTestDishes(1);
            var menuMaster = new MenuMasterRepo(menu, 3);

            //Act
            var result = await menuMaster.GetAllFirstDishesOnPages();

            //Assert
            result.Should().BeOfType<List<Dish>>();
        }


        [Fact] 
        public async Task GetAllFirstDishesOnPages_ListOfDishes_ReturnListOFDishes()
        {
            //Arrange
            var menu = MenuFixtures.GetTestDishes(-1);
            var menuMaster = new MenuMasterRepo(menu, 3);
            var expected = new List<Dish> { menu[0], menu[3], menu[6] };
            //Act
            var result = await menuMaster.GetAllFirstDishesOnPages();
            //Assert
            result.Should().BeEquivalentTo(expected);
        }
        #endregion
    }
}