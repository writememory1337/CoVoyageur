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
    public class FeedbackControllerTests
    {
        private Mock<IRepository<Feedback>> _mockRepository;
        private Mock<IMapper> _mockMapper;
        private FeedbackController _controller;

        [SetUp]
        public void Setup()
        {
            _mockRepository = new Mock<IRepository<Feedback>>();
            _mockMapper = new Mock<IMapper>();
            _controller = new FeedbackController(_mockRepository.Object, _mockMapper.Object);
        }

        [Test]
        public async Task GetAll_ReturnsOkResult_WithFeedbacks()
        {
            var feedbacks = new List<Feedback> { new Feedback(), new Feedback() };
            var feedbacksDTO = new List<FeedbackDTO> { new FeedbackDTO(), new FeedbackDTO() };
            _mockRepository.Setup(repo => repo.GetAll()).ReturnsAsync(feedbacks);
            _mockMapper.Setup(mapper => mapper.Map<IEnumerable<FeedbackDTO>>(feedbacks)).Returns(feedbacksDTO);

            var result = await _controller.GetAll();

            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            Assert.AreEqual(feedbacksDTO, okResult?.Value);
        }

        [Test]
        public async Task GetById_ReturnsNotFoundResult_WhenFeedbackNotFound()
        {
            int feedbackId = 1;
            _mockRepository.Setup(repo => repo.GetById(feedbackId)).ReturnsAsync((Feedback?)null);

            var result = await _controller.GetById(feedbackId);

            Assert.IsInstanceOf<NotFoundObjectResult>(result);
        }

        [Test]
        public async Task Post_ReturnsCreatedAtActionResult_WhenFeedbackAdded()
        {
            var feedbackDTO = new FeedbackDTO();
            var feedback = new Feedback();
            _mockMapper.Setup(mapper => mapper.Map<Feedback>(feedbackDTO)).Returns(feedback);
            _mockMapper.Setup(mapper => mapper.Map<FeedbackDTO>(It.IsAny<Feedback>())).Returns(feedbackDTO);
            _mockRepository.Setup(repo => repo.Add(feedback)).ReturnsAsync(feedback);

            var result = await _controller.Post(feedbackDTO);

            Assert.IsInstanceOf<CreatedAtActionResult>(result);
        }
    }
}