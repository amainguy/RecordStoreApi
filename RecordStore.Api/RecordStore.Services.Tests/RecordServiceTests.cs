using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RecordStore.DomainObjects;
using RecordStore.Services.Implementations;

namespace RecordStore.Services.Tests
{
    [TestClass]
    public class RecordServiceTests
    {
        private RecordService _subject;

        [TestInitialize]
        public void Initialize()
        {
            CreateSubject();
        }

        [TestMethod]
        public async Task GetAll_ShouldReturnIEnumerableOfRecords()
        {
            var result = await _subject.GetAll();
            result.GetType().Should().BeAssignableTo<IEnumerable<Record>>();
        }

        [TestMethod]
        public async Task GetById_ShouldReturnCorrespondingRecord()
        {
            var result = await _subject.GetById(1);
            result.Should().BeOfType<Record>();
            result.Id.Should().Be(1);
        }

        private void CreateSubject()
        {
            _subject = new RecordService();
        }
    }
}
