using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RecordStore.Api.Controllers;
using RecordStore.DomainObjects;
using RecordStore.Services.Interfaces;

namespace RecordStore.Api.Tests
{
    [TestClass]
    public class ArtistControllerTests
    {
        private Mock<IArtistService> _mockService;
        private ArtistsController _artistsController;
        private int _artistId;

        [TestInitialize]
        public void Initialize()
        {
            _artistId = 1;
            Setup();
        }

        [TestMethod]
        public async Task Get_WhenNoParams_ShouldReturnIEnumerableOfRecords()
        {
            var result = await _artistsController.Get();
            result.GetType().Should().BeAssignableTo<IEnumerable<Artist>>();
        }

        [TestMethod]
        public async Task Get_WhenIdIsProvided_ShouldReturnCorrespondingRecord()
        {
            var result = await _artistsController.Get(_artistId);
            result.Should().BeOfType<Artist>();
            result.Id.Should().Be(_artistId);
        }

        private void Setup()
        {
            _mockService = new Mock<IArtistService>();
            _mockService.Setup(x => x.GetAll()).ReturnsAsync(new Artist[0]);
            _mockService.Setup(x => x.GetById(_artistId)).ReturnsAsync(new Artist { Id = _artistId });
            _artistsController = new ArtistsController(_mockService.Object);
        }
    }
}
