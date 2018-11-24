using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RecordStore.Api.Controllers;
using RecordStore.Services.Interfaces;
using NSubstitute;


namespace RecordStore.Api.Tests
{
    [TestClass]
    public class RecordsControllerTests
    {
        private RecordsController _recordsController;
        private IRecordService _recordService;
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
        }

        [TestMethod]
        public async Task GetById_WhenIdIsProvided_ShouldReturnCorrespondingRecord()
        {
            var result = await _recordsController.GetById(_recordId);
        }

        private void Setup()
        {
            _recordService = Substitute.For<IRecordService>();
            _recordsController = new RecordsController(_recordService);
        }

    }
}
