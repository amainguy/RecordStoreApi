using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RecordStore.Api.Controllers;
using RecordStore.DomainObjects;
using RecordStore.Services.Interfaces;
using Moq;


namespace RecordStore.Api.Tests
{
    [TestClass]
    public class RecordsControllerTests
    {
        private RecordsController _recordsController;
        private Mock<IRecordService> _mockService;
        private int _recordId;

        [TestInitialize]
        public void Initialize()
        {
            _recordId = 1;
            Setup();
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

        private void Setup()
        {
            _mockService = new Mock<IRecordService>();
            _mockService.Setup(x => x.GetAll()).ReturnsAsync(new Record[0]);
            _mockService.Setup(x => x.GetById(_recordId)).ReturnsAsync(new Record { Id = _recordId });
            _recordsController = new RecordsController(_mockService.Object);
        }

    }
}
