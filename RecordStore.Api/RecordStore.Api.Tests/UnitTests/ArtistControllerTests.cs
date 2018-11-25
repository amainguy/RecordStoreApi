using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NSubstitute.ReturnsExtensions;
using RecordStore.Api.Controllers;
using RecordStore.DomainObjects;
using RecordStore.Services.Interfaces;

namespace RecordStore.Api.Tests.UnitTests
{
    [TestClass]
    public class ArtistControllerTests
    {
        private IArtistService _artistService;
        private ArtistsController _artistsController;
        private int _artistId;

        [TestInitialize]
        public void Initialize()
        {
            _artistId = 1;
            Setup();
        }

        [TestMethod]
        public async Task GetAll_ShouldReturnOkResult()
        {
            _artistService.GetAll().Returns(Substitute.For<IEnumerable<ArtistDo>>());

            var result = await _artistsController.GetAll();

            result.Should().BeOfType<OkObjectResult>();
        }

        [TestMethod]
        public async Task GetById_WhenValidIdProvided_ShouldReturnOkObjectResult()
        {
            _artistService.GetById(_artistId).Returns(new ArtistDo { ArtistId = _artistId });

            var result = await _artistsController.GetById(_artistId);

            result.Should().BeOfType<OkObjectResult>();
        }

        [TestMethod]
        public async Task GetById_WhenInvalidIdProvided_ShouldReturnNotFoundResult()
        {
            _artistService.GetById(_artistId).ReturnsNull();

            var result = await _artistsController.GetById(_artistId);

            result.Should().BeOfType<NotFoundResult>(); 
        }

        [TestMethod]
        public async Task Create_WhenArtistIsNull_ShouldReturnBadRequestObjectResult()
        {
            var result = await _artistsController.Create(null);

            result.Should().BeOfType<BadRequestObjectResult>();
        }

        [TestMethod]
        public async Task Create_WhenArtistIsProvidedAndServiceDoNotThrowException_ShouldReturnCreatedAtRouteResult()
        {
            var result = await _artistsController.Create(Substitute.For<ArtistDo>());

            result.Should().BeOfType<CreatedAtRouteResult>();
        }

        [TestMethod]
        public async Task Create_WhenArtistIsProvidedAndServiceThrowsException_ShouldReturnInternalServerErrorStatusCode()
        {
            var artist = Substitute.For<ArtistDo>();

            _artistService.Create(artist).Throws<Exception>();

            var result = await _artistsController.Create(artist);

            result.Should().BeOfType<StatusCodeResult>();
            result.As<StatusCodeResult>().StatusCode.Should().Be(500);
        }

        [TestMethod]
        public async Task Update_WhenIdIsZero_ShouldReturnBadRequestObjectResult()
        {
            var result = await _artistsController.Update(0, Substitute.For<ArtistDo>());

            result.Should().BeOfType<BadRequestObjectResult>();
        }

        [TestMethod]
        public async Task Update_WhenArtistIsNull_ShouldReturnBadRequestObjectResult()
        {
            var result = await _artistsController.Update(_artistId, null);

            result.Should().BeOfType<BadRequestObjectResult>();
        }

        [TestMethod]
        public async Task Update_WhenArtistIsProvidedAndServiceThrowsException_ShouldReturnInternalServerErrorStatusCode()
        {
            var artist = Substitute.For<ArtistDo>();

            _artistService.Update(_artistId, artist).Throws<Exception>();

            var result = await _artistsController.Update(_artistId, artist);

            result.Should().BeOfType<StatusCodeResult>();
            result.As<StatusCodeResult>().StatusCode.Should().Be(500);
        }

        [TestMethod]
        public async Task Update_WhenArtistIsProvidedAndServiceDoNotThrowException_ShouldReturnCreatedAtRouteResult()
        {
            var result = await _artistsController.Update(_artistId, Substitute.For<ArtistDo>());

            result.Should().BeOfType<OkResult>();
        }

        [TestMethod]
        public async Task Delete_WhenArtistIsNull_ShouldReturnBadRequestObjectResult()
        {
            var result = await _artistsController.Delete(null);

            result.Should().BeOfType<BadRequestObjectResult>();
        }

        [TestMethod]
        public async Task Delete_WhenArtistIsProvided_ShouldReturnOkResult()
        {
            var result = await _artistsController.Delete(Substitute.For<ArtistDo>());

            result.Should().BeOfType<OkResult>();
        }


        [TestMethod]
        public async Task Delete_WhenArtistServiceThrowException_ShouldReturnInternalServerError()
        {
            var artist = Substitute.For<ArtistDo>();
            _artistService.Delete(artist).Throws<Exception>();

            var result = await _artistsController.Delete(artist);

            result.Should().BeOfType<StatusCodeResult>();
            result.As<StatusCodeResult>().StatusCode.Should().Be(500);
        }


        private void Setup()
        {
            _artistService = Substitute.For<IArtistService>();
            _artistsController = new ArtistsController(_artistService);
        }
    }
}
