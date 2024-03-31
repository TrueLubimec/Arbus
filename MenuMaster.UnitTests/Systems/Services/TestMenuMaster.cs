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
        [InlineData(0,2,1)]
        [InlineData(1, 2, 5)]
        [InlineData(2, 2, 6)]
        [InlineData(3, 2, 11)]
        [InlineData(-1, 2, 9)]
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
        [InlineData(0, 3, 1)]
        [InlineData(1, 1, 5)]
        [InlineData(2, 5, 2)]
        [InlineData(3, 2, 6)]
        [InlineData(-1, 9, 1)]
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
        [InlineData(0,2 , 1, 1)]
        [InlineData(1, 4, 2, 1)] 
        [InlineData(1, 2, 2, 2)]
        [InlineData(3, 4, 3, 3)]
        [InlineData(-1, 1, 3, 1)]
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
            var menu0 = MenuFixtures.GetTestDishes(0);
            var menuMaster0 = new MenuMasterRepo(menu0, 5);
            var expected0 = new List<Dish> { menu0[0] };

            var menu1 = MenuFixtures.GetTestDishes(1);
            var menuMaster1 = new MenuMasterRepo(menu1, 3);
            var expected1 = new List<Dish> { menu1[3], menu1[4] };

            var menu2 = MenuFixtures.GetTestDishes(2);
            var menuMaster2 = new MenuMasterRepo(menu2, 4);
            var expected2 = new List<Dish> { menu2[4], menu2[5] };

            var menu3 = MenuFixtures.GetTestDishes(3);
            var menuMaster3 = new MenuMasterRepo(menu3, 5);
            var expected3 = new List<Dish> { menu3[10] };

            var menu4 = MenuFixtures.GetTestDishes(-1);
            var menuMaster4 = new MenuMasterRepo(menu4, 3);
            var expected4 = new List<Dish> { menu4[0], menu4[1], menu4[2] };


            // Act
            var result0 = await menuMaster0.GetDishesOnPage(1);

            var result1 = await menuMaster1.GetDishesOnPage(2);

            var result2 = await menuMaster2.GetDishesOnPage(2);

            var result3 = await menuMaster3.GetDishesOnPage(3);

            var result4 = await menuMaster4.GetDishesOnPage(1);

            // Assert
            result0.Should().BeEquivalentTo(expected0);

            result1.Should().BeEquivalentTo(expected1);

            result2.Should().BeEquivalentTo(expected2);

            result3.Should().BeEquivalentTo(expected3);

            result4.Should().BeEquivalentTo(expected4);
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
        public async Task GetAllFirstDishesOnPages_ListOfDishes_ReturnListOfDishes()
        {
            // Arrange
            var menu0 = MenuFixtures.GetTestDishes(0);
            var menuMaster0 = new MenuMasterRepo(menu0, 3);
            var expected0 = new List<Dish> { menu0[0] };

            var menu1 = MenuFixtures.GetTestDishes(1);
            var menuMaster1 = new MenuMasterRepo(menu1, 1);
            var expected1 = MenuFixtures.GetTestDishes(1);

            var menu2 = MenuFixtures.GetTestDishes(2);
            var menuMaster2 = new MenuMasterRepo(menu2, 4);
            var expected2 = new List<Dish> { menu2[0], menu2[4] };

            var menu3 = MenuFixtures.GetTestDishes(3);
            var menuMaster3 = new MenuMasterRepo(menu3, 3);
            var expected3 = new List<Dish> { menu3[0], menu3[3], menu3[6], menu3[9] };

            var menu4 = MenuFixtures.GetTestDishes(-1);
            var menuMaster4 = new MenuMasterRepo(menu4, 4);
            var expected4 = new List<Dish> { menu4[0], menu4[4], menu4[8] };


            // Act
            var result0 = await menuMaster0.GetAllFirstDishesOnPages();

            var result1 = await menuMaster1.GetAllFirstDishesOnPages();

            var result2 = await menuMaster2.GetAllFirstDishesOnPages();

            var result3 = await menuMaster3.GetAllFirstDishesOnPages();

            var result4 = await menuMaster4.GetAllFirstDishesOnPages();

            // Assert
            result0.Should().BeEquivalentTo(expected0);

            result1.Should().BeEquivalentTo(expected1);

            result2.Should().BeEquivalentTo(expected2);

            result3.Should().BeEquivalentTo(expected3);

            result4.Should().BeEquivalentTo(expected4);
        }
        #endregion
    }
}