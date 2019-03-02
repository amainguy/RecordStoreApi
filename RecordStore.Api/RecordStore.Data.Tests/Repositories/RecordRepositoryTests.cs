using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RecordStore.Data.Repositories.Implementations;
using RecordStore.DomainObjects;
using AutoFixture;

namespace RecordStore.Data.Tests.Repositories
{
    [TestClass]
    public class RecordRepositoryTests : DbContextTests
    {
        private const string Title = "Space Oddity";
        private RecordRepository _subject;

        [TestInitialize]
        public void Initialize()
        {
            Setup();
            _subject = new RecordRepository(_dbContext, _mapper);
        }

        [TestMethod]
        public async Task GetAll_ShouldReturnDataSeed()
        {
            var result = (await _subject.GetAll()).ToList();

            result.Should().HaveCount(1);
            result.First().Title.Should().Be(Title);
        }

        [TestMethod]
        public async Task Get_ShouldReturnCorrespondingRecord()
        {
            var result = await _subject.Get(1);

            result.Title.Should().Be(Title);
        }

        [TestMethod]
        public async Task Create_ShouldAddRecordInDbContext()
        {
            var record = new RecordDo { Title = "Midnight Marauders", ReleaseYear = 1993};

            _subject.Create(record);
            _dbContext.SaveChanges();

            var result = (await _subject.GetAll()).ToList();
            result.Should().HaveCount(2);
            result.Last().Title.Should().Be(record.Title);
        }

        [TestMethod]
        public async Task Update_WhenTitleIsChanged_ThenShouldChangeTitleInDbContext()
        {
            var title = _auto.Create<string>();
            var recordDo = await _subject.Get(1);
            recordDo.Title = title;

            await _subject.Update(recordDo);
            _dbContext.SaveChanges();

            recordDo = await _subject.Get(1);
            recordDo.Title.Should().Be(title);
        }

        [TestMethod]
        public async Task Count_ShouldReturnTheNumberOfArtistsInDbContext()
        {
            var result = await _subject.Count();
            result.Should().Be(1);
        }

        [TestMethod]
        public void Where()
        {
            var result = _subject.Where(x => x.Title == Title).FirstOrDefault();

            result.Title.Should().Be(Title);
        }

        [TestMethod]
        public async Task GetWithRecords()
        {
            var result = await _subject.GetWithArtist(1);

            result.Artist.Should().NotBeNull();
        }
    }
}
