using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RecordStore.Api.Controllers;
using RecordStore.DomainObjects;

namespace RecordStore.Api.Tests
{
    [TestClass]
    public class RecordsControllerTests
    {
        private RecordsController _recordsController;
        private int _recordId;

        [TestInitialize]
        public void Initialize()
        {
            _recordsController = new RecordsController();
            _recordId = 1;
        }

        [TestMethod]
        public async Task Get_WhenNoParams_ShouldReturnIEnumerableOfRecords()
        {
            var result = await _recordsController.Get();
            result.GetType().Should().BeAssignableTo<IEnumerable<Record>>();
        }

        [TestMethod]
        public async Task Get_WhenIdIsProvided_ShouldReturnCorrespondingRecord()
        {
            var result = await _recordsController.Get(_recordId);
            result.Should().BeOfType<Record>();
            result.Id.Should().Be(_recordId);
        }

    }
}
