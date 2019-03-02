using System.Linq;
using System.Threading.Tasks;
using AutoFixture;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RecordStore.Data.Repositories.Implementations;
using RecordStore.DomainObjects;

namespace RecordStore.Data.Tests.Repositories
{
    [TestClass]
    public class ArtistRepositoryTests : DbContextTests
    {
        private const string FirstName = "David";
        private ArtistRepository _subject;

        [TestInitialize]
        public void initialize()
        {
            Setup();
            _subject = new ArtistRepository(_dbContext, _mapper);
        }

        [TestMethod]
        public async Task GetAll_ShouldReturnDataSeed()
        {
            var result = (await _subject.GetAll()).ToList();

            result.Should().HaveCount(2);
            result.First().FirstName.Should().Be(FirstName);
        }

        [TestMethod]
        public async Task Get_ShouldReturnCorrespondingArtist()
        {
            var result = await _subject.Get(1);

            result.FirstName.Should().Be(FirstName);
        }

        [TestMethod]
        public async Task Create_ShouldAddAnArtistInDbContext()
        {
            var artist = new ArtistDo {ArtistId = 3, FirstName = "Otis", LastName = "Redding"};
            _subject.Create(artist);
            _dbContext.SaveChanges();

            var result = (await _subject.GetAll()).ToList();

            result.Should().HaveCount(3);
            result.Last().FirstName.Should().Be(artist.FirstName);
        }

        [TestMethod]
        public async Task Update_WhenFirstNameIsChanged_ThenShouldChangeFirstNameInDbContext()
        {
            var name = _auto.Create<string>();
            var artistDo = await _subject.Get(1);
            artistDo.FirstName = name;

            await _subject.Update(artistDo);
            _dbContext.SaveChanges();

            artistDo = await _subject.Get(1);
            artistDo.FirstName.Should().Be(name);
        }

        [TestMethod]
        public async Task Count_ShouldReturnTheNumberOfArtistsInDbContext()
        {
            var result = await _subject.Count();
            result.Should().Be(2);
        }

        [TestMethod]
        public void Where()
        {
            var result = _subject.Where(x => x.FirstName == FirstName).FirstOrDefault();

            result.FirstName.Should().Be(FirstName);
        }

        [TestMethod]
        public async Task GetWithRecords()
        {
            var result = await _subject.GetWithRecords(1);

            result.Records.Should().HaveCount(1);
        }
    }
}
