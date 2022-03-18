using AutoFixture;
using AutoFixture.AutoNSubstitute;
using AutoMapper;
using Catalog.Menus.Contracts;
using Catalog.Menus.Domains;
using Catalog.Menus.Dtos;
using Catalog.Menus.Profiles;
using Catalog.Menus.Services;
using FluentAssertions;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using System;
using System.Data.Entity.Core;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Catalog.Menus.Test.Tests
{
    public class MenusServiceTest
    {
        #region Properties

        private readonly Fixture fixture;
        private readonly IMapper mapper;

        #endregion Properties

        #region Costructor

        public MenusServiceTest()
        {
            fixture = new Fixture();
            fixture
                .Customize(new AutoNSubstituteCustomization());

            fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
                .ForEach(b => fixture.Behaviors.Remove(b));
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            var config = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MenuApplicationProfile());
            });
            mapper = config.CreateMapper();

            fixture.Inject<IMapper>(mapper);
        }

        #endregion Costructor

        #region Methods

        [Fact]
        public async void GetMenues_Should_Return_Menus_When_It_Exist()
        {
            // Arrange
            var mockRepo = Substitute.For<IMenusRepository>();
            fixture.Register(() => mockRepo);
            var mockModels = fixture.CreateMany<Menu>();

            mockRepo.GetAllAsync().Returns(mockModels);

            // Act
            var service = fixture.Create<MenusService>();
            var result = await service.GetAllAsync();

            // Assert
            result.Should().NotBeNull();
            result.Count().Should().Be(mockModels.Count());
            result.First().Name.Should().Be(mockModels.First().Name);
            result.First().Price.Should().Be(mockModels.First().Price);
            result.First().Cost.Should().Be(mockModels.First().Cost);
            result.First().Image.Should().Be(mockModels.First().Image);
        }

        [Fact]
        public void GetMenues_Should_Throw_Exception_When_Unexcpected_error_occured()
        {
            // Arrange
            var mockRepo = Substitute.For<IMenusRepository>();
            fixture.Register(() => mockRepo);

            mockRepo.GetAllAsync().ThrowsForAnyArgs(new Exception());

            // Act
            var service = fixture.Create<MenusService>();
            var exception = Record.ExceptionAsync(() => service.GetAllAsync()).Result;

            // Assert
            exception.Should().NotBeNull();
            exception.Should().BeOfType<Exception>();
        }

        [Fact]
        public async void GetMenu_By_Id_Should_Return_The_Menu_When_It_Exist()
        {
            // Arrange
            var mockRepo = Substitute.For<IMenusRepository>();
            fixture.Register(() => mockRepo);
            var mockModel = fixture.Create<Menu>();

            mockRepo.GetAsync(mockModel.Id).Returns(mockModel);

            // Act
            var service = fixture.Create<MenusService>();
            var result = await service.GetAsync(mockModel.Id);

            // Assert
            result.Should().NotBeNull();
            result.Name.Should().Be(mockModel.Name);
            result.Price.Should().Be(mockModel.Price);
            result.Cost.Should().Be(mockModel.Cost);
            result.Image.Should().Be(mockModel.Image);
        }

        [Fact]
        public void GetMenu_By_Id_Should_Throw_Object_Not_Found_Exception_When_Object_Is_Not_Found()
        {
            // Arrange
            var mockRepo = Substitute.For<IMenusRepository>();
            fixture.Register(() => mockRepo);
            var mockModel = fixture.Create<Menu>();

            mockRepo.GetAsync(mockModel.Id).Returns((Menu)null);

            // Act
            var service = fixture.Create<MenusService>();
            var exception = Record.ExceptionAsync(() => service.GetAsync(mockModel.Id)).Result;

            // Assert
            exception.Should().NotBeNull();
            exception.Should().BeOfType<ObjectNotFoundException>();
        }

        [Fact]
        public void GetMenu_By_Id_Should_Throw_Exception_When_Unexcpected_error_occured()
        {
            // Arrange
            var mockRepo = Substitute.For<IMenusRepository>();
            fixture.Register(() => mockRepo);

            mockRepo.GetAsync(default).ThrowsForAnyArgs(new Exception());

            // Act
            var service = fixture.Create<MenusService>();
            var exception = Record.ExceptionAsync(() => service.GetAsync(default)).Result;

            // Assert
            exception.Should().NotBeNull();
            exception.Should().BeOfType<Exception>();
        }

        [Fact]
        public async void Add_Menu_Should_Add_Menu_Item_Successfully()
        {
            // Arrange
            var mockRepo = Substitute.For<IMenusRepository>();
            fixture.Register(() => mockRepo);
            var dto = fixture.Create<AddMenuDto>();
            var model = mapper.Map<Menu>(dto);

            mockRepo.AddAsync(model).Returns(Task.CompletedTask);

            // Act
            var service = fixture.Create<MenusService>();

            // Assert
            try
            {
                await service.AddAsync(dto);
                true.Should().BeTrue();
            }
            catch
            {
                false.Should().BeTrue();
            }
        }

        [Fact]
        public void Add_Menu_Should_Throw_Exception_When_Unexcpected_error_occured()
        {
            // Arrange
            var mockRepo = Substitute.For<IMenusRepository>();
            fixture.Register(() => mockRepo);
            var dto = fixture.Create<AddMenuDto>();
            var model = mapper.Map<Menu>(dto);

            mockRepo.AddAsync(model).ThrowsForAnyArgs(new Exception());

            // Act
            var service = fixture.Create<MenusService>();
            var exception = Record.ExceptionAsync(() => service.AddAsync(dto)).Result;

            // Assert
            exception.Should().NotBeNull();
            exception.Should().BeOfType<Exception>();
        }

        [Fact]
        public async void Remove_Menu_Should_Remove_Menu_Item_Successfully()
        {
            // Arrange
            var mockRepo = Substitute.For<IMenusRepository>();
            fixture.Register(() => mockRepo);
            var id = Guid.NewGuid();
            var model = fixture.Create<Menu>();

            mockRepo.GetAsync(id).Returns(model);
            mockRepo.RemoveAsync(id).Returns(Task.CompletedTask);

            // Act
            var service = fixture.Create<MenusService>();

            // Assert
            try
            {
                await service.RemoveAsync(id);
                true.Should().BeTrue();
            }
            catch
            {
                false.Should().BeTrue();
            }
        }

        [Fact]
        public void Remove_Menu_Should_Throw_Object_Not_Found_Exception_When_Object_Is_Not_Found()
        {
            // Arrange
            var mockRepo = Substitute.For<IMenusRepository>();
            fixture.Register(() => mockRepo);
            var id = Guid.NewGuid();

            mockRepo.GetAsync(id).Returns((Menu)null);

            // Act
            var service = fixture.Create<MenusService>();
            var exception = Record.ExceptionAsync(() => service.RemoveAsync(id)).Result;

            // Assert
            exception.Should().NotBeNull();
            exception.Should().BeOfType<ObjectNotFoundException>();
        }

        [Fact]
        public void Remove_Menu_Should_Throw_Exception_When_Unexcpected_error_occured()
        {
            // Arrange
            var mockRepo = Substitute.For<IMenusRepository>();
            fixture.Register(() => mockRepo);
            var id = Guid.NewGuid();

            var model = fixture.Create<Menu>();

            mockRepo.GetAsync(id).Returns(model);
            mockRepo.RemoveAsync(id).ThrowsForAnyArgs(new Exception());

            // Act
            var service = fixture.Create<MenusService>();
            var exception = Record.ExceptionAsync(() => service.RemoveAsync(id)).Result;

            // Assert
            exception.Should().NotBeNull();
            exception.Should().BeOfType<Exception>();
        }

        [Fact]
        public async void Update_Menu_Should_Remove_Menu_Item_Successfully()
        {
            // Arrange
            var mockRepo = Substitute.For<IMenusRepository>();
            fixture.Register(() => mockRepo);
            var id = Guid.NewGuid();
            var model = fixture.Create<Menu>();
            var dto = fixture.Create<UpdateMenuDto>();

            mockRepo.GetAsync(model.Id).Returns(model);
            mockRepo.UpdateAsync(model).Returns(Task.CompletedTask);

            // Act
            var service = fixture.Create<MenusService>();

            // Assert
            try
            {
                await service.UpdateAsync(model.Id, dto);
                true.Should().BeTrue();
            }
            catch
            {
                false.Should().BeTrue();
            }
        }

        [Fact]
        public void Update_Menu_Should_Throw_Object_Not_Found_Exception_When_Object_Is_Not_Found()
        {
            // Arrange
            var mockRepo = Substitute.For<IMenusRepository>();
            fixture.Register(() => mockRepo);
            var id = Guid.NewGuid();
            var dto = fixture.Create<UpdateMenuDto>();

            mockRepo.GetAsync(id).Returns((Menu)null);

            // Act
            var service = fixture.Create<MenusService>();
            var exception = Record.ExceptionAsync(() => service.UpdateAsync(id, dto)).Result;

            // Assert
            exception.Should().NotBeNull();
            exception.Should().BeOfType<ObjectNotFoundException>();
        }

        [Fact]
        public void Update_Menu_Should_Throw_Exception_When_Unexcpected_error_occured()
        {
            // Arrange
            var mockRepo = Substitute.For<IMenusRepository>();
            fixture.Register(() => mockRepo);
            var id = Guid.NewGuid();
            var dto = fixture.Create<UpdateMenuDto>();
            var model = fixture.Create<Menu>();

            mockRepo.GetAsync(id).Returns(model);
            mockRepo.UpdateAsync(model).ThrowsForAnyArgs(new Exception());

            // Act
            var service = fixture.Create<MenusService>();
            var exception = Record.ExceptionAsync(() => service.UpdateAsync(id, dto)).Result;

            // Assert
            exception.Should().NotBeNull();
            exception.Should().BeOfType<Exception>();
        }

        #endregion Methods
    }
}