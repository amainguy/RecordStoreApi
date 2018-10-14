using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RecordStore.DomainObjects;
using RecordStore.Services.Implementations;
using RecordStore.Services.Interfaces;

namespace RecordStore.Services.Tests
{
    [TestClass]
    public class ArtistServiceTest
    {
        private IArtistService _subject; 

        [TestInitialize]
        public void Initialize()
        {
            CreateSubject();
        }

        [TestMethod]
        public async Task GetAll_ShouldReturnIEnumerableOfArtists()
        {
            var result = await _subject.GetAll();
            result.GetType().Should().BeAssignableTo<IEnumerable<Artist>>();
        }

        [TestMethod]
        public async Task GetById_ShouldReturnCorrespondingArtist()
        {
            var result = await _subject.GetById(1);
            result.Should().BeOfType<Artist>();
            result.Id.Should().Be(1);
        }

        private void CreateSubject()
        {
            _subject = new ArtistService();
        }
    }
}
