using Moq;
using AutoMapper;
using CoVoyageur.API.Controllers;
using CoVoyageur.API.Repositories;
using CoVoyageur.Core.Models;
using CoVoyageur.API.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CoVoyageur.Tests
{
    [TestFixture]
    public class UserControllerTests
    {
        private Mock<IRepository<User>> _mockRepository;
        private Mock<IMapper> _mockMapper;
        private UserController _controller;

        [SetUp]
        public void Setup()
        {
            _mockRepository = new Mock<IRepository<User>>();
            _mockMapper = new Mock<IMapper>();
            _controller = new UserController(_mockRepository.Object, _mockMapper.Object);
        }

        [Test]
        public async Task GetAll_ReturnsOkResult_WithUsers()
        {
            var users = new List<User> { new User(), new User() };
            var usersDTO = new List<UserDTO> { new UserDTO(), new UserDTO() };
            _mockRepository.Setup(repo => repo.GetAll()).ReturnsAsync(users);
            _mockMapper.Setup(mapper => mapper.Map<IEnumerable<UserDTO>>(users)).Returns(usersDTO);

            var result = await _controller.GetAll();

            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            Assert.AreEqual(usersDTO, okResult?.Value);
        }

        [Test]
        public async Task GetById_ReturnsNotFoundResult_WhenUserNotFound()
        {
            int userId = 1;
            _mockRepository.Setup(repo => repo.GetById(userId)).ReturnsAsync((User?)null);

            var result = await _controller.GetById(userId);

            Assert.IsInstanceOf<NotFoundObjectResult>(result);
        }
    }
}