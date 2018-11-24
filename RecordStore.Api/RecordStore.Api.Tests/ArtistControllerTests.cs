using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using RecordStore.Api.Controllers;
using RecordStore.DomainObjects;
using RecordStore.Services.Interfaces;

namespace RecordStore.Api.Tests
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
        public async Task Get_WhenNoParams_ShouldReturnIEnumerableOfRecords()
        {
            var result = await _artistsController.Get();
        }

        [TestMethod]
        public async Task Get_WhenIdIsProvided_ShouldReturnCorrespondingRecord()
        {
            var result = await _artistsController.GetById(_artistId);
        }

        private void Setup()
        {
            _artistService = Substitute.For<IArtistService>();
            _artistService.GetAll().Returns(new ArtistDo[0]);
            _artistService.GetById(_artistId).Returns(new ArtistDo { ArtistId = _artistId });
            _artistsController = new ArtistsController(_artistService);
        }
    }
}
