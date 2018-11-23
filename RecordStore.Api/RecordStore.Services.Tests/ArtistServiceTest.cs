using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using RecordStore.Data;
using RecordStore.Data.Repositories.Interfaces;
using RecordStore.DomainObjects;
using RecordStore.Services.Implementations;
using RecordStore.Services.Interfaces;

namespace RecordStore.Services.Tests
{
    [TestClass]
    public class ArtistServiceTest
    {
        private IUnitOfWork _unitOfWork;
        private IArtistService _subject;
        private int _artistId;

        [TestInitialize]
        public void Initialize()
        {
            _unitOfWork = Substitute.For<IUnitOfWork>();
            _artistId = 1;
            CreateSubject();
        }

        [TestMethod]
        public async Task GetAll_ShouldReturnIEnumerableOfArtists()
        {
            var result = await _subject.GetAll();
            result.GetType().Should().BeAssignableTo<IEnumerable<ArtistDo>>();
        }

        [TestMethod]
        public async Task GetById_ShouldReturnCorrespondingArtist()
        {
            var result = await _subject.GetById(_artistId);
            result.Should().BeOfType<ArtistDo>();
            result.ArtistId.Should().Be(_artistId);
        }

        private void CreateSubject()
        {
            _unitOfWork.Artists.Returns(Substitute.For<IArtistRepository>());
            _unitOfWork.Artists.Get(_artistId).Returns(new ArtistDo {ArtistId = _artistId});
            _subject = new ArtistService(_unitOfWork);
        }
    }
}
