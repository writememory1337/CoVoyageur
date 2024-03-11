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
    public class ReservationControllerTests
    {
        private Mock<IRepository<Reservation>> _mockRepository;
        private Mock<IMapper> _mockMapper;
        private ReservationController _controller;

        [SetUp]
        public void Setup()
        {
            _mockRepository = new Mock<IRepository<Reservation>>();
            _mockMapper = new Mock<IMapper>();
            _controller = new ReservationController(_mockRepository.Object, _mockMapper.Object);
        }

        [Test]
        public async Task GetAll_ReturnsOkResult_WithReservations()
        {
            var reservations = new List<Reservation> { new Reservation(), new Reservation() };
            var reservationsDTO = new List<ReservationDTO> { new ReservationDTO(), new ReservationDTO() };

            _mockRepository.Setup(repo => repo.GetAll()).ReturnsAsync(reservations);
            _mockMapper.Setup(mapper => mapper.Map<IEnumerable<ReservationDTO>>(reservations)).Returns(reservationsDTO);

            var result = await _controller.GetAll();

            Assert.IsInstanceOf<OkObjectResult>(result);

            if (result is OkObjectResult okResult)
            {
                Assert.AreEqual(reservationsDTO, okResult.Value);
            }
            else
            {
                Assert.Fail("result isnt of type OkObjectResult.");
            }
        }

        [Test]
        public async Task Post_ReturnsCreatedAtActionResult_WhenReservationAdded()
        {
            var reservationDTO = new ReservationDTO();
            var reservation = new Reservation();
            _mockMapper.Setup(mapper => mapper.Map<Reservation>(reservationDTO)).Returns(reservation);
            _mockMapper.Setup(mapper => mapper.Map<ReservationDTO>(It.IsAny<Reservation>())).Returns(reservationDTO);
            _mockRepository.Setup(repo => repo.Add(reservation)).ReturnsAsync(reservation);

            var result = await _controller.Post(reservationDTO);

            Assert.IsInstanceOf<CreatedAtActionResult>(result);
        }
    }
}