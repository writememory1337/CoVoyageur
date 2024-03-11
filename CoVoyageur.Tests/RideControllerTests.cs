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
    public class RideControllerTests
    {
        private Mock<IRepository<Ride>> _mockRepository;
        private Mock<IMapper> _mockMapper;
        private RideController _controller;

        [SetUp]
        public void Setup()
        {
            _mockRepository = new Mock<IRepository<Ride>>();
            _mockMapper = new Mock<IMapper>();
            _controller = new RideController(_mockRepository.Object, _mockMapper.Object);
        }

        [Test]
        public async Task GetById_ReturnsNotFoundResult_WhenRideNotFound()
        {
            int rideId = 1;
            _mockRepository.Setup(repo => repo.GetById(rideId)).ReturnsAsync((Ride?)null);

            var result = await _controller.GetById(rideId);

            Assert.IsInstanceOf<NotFoundObjectResult>(result);
        }

        [Test]
        public async Task Put_ReturnsOkResult_WhenRideUpdated()
        {
            int rideId = 1;
            var rideDTO = new RideDTO();
            var ride = new Ride();

            _mockRepository.Setup(riderepo => riderepo.GetById(rideId)).ReturnsAsync(ride);
            _mockMapper.Setup(mapper => mapper.Map<Ride>(rideDTO)).Returns(ride);
            _mockMapper.Setup(mapper => mapper.Map<RideDTO>(It.IsAny<Ride>())).Returns(rideDTO);
            _mockRepository.Setup(riderepo => riderepo.Update(ride)).ReturnsAsync(ride);

            var result = await _controller.Put(rideId, rideDTO);

            Assert.IsInstanceOf<OkObjectResult>(result);
        }
    }
}