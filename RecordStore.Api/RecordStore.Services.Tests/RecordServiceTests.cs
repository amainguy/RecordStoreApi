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
    public class RecordServiceTests
    {
        private IRecordService _subject;
        private IUnitOfWork _unitOfWork;
        private int _recordId;

        [TestInitialize]
        public void Initialize()
        {
            _unitOfWork = Substitute.For<IUnitOfWork>();
            _recordId = 1;
            CreateSubject();
        }

        [TestMethod]
        public async Task GetAll_ShouldReturnIEnumerableOfRecords()
        {
            var result = await _subject.GetAll();
            result.GetType().Should().BeAssignableTo<IEnumerable<RecordDo>>();
        }

        [TestMethod]
        public async Task GetById_ShouldReturnCorrespondingRecord()
        {
            var result = await _subject.GetById(_recordId);
            result.Should().BeOfType<RecordDo>();
            result.RecordId.Should().Be(_recordId);
        }

        private void CreateSubject()
        {
            _unitOfWork.Records.Returns(Substitute.For<IRecordRepository>());
            _unitOfWork.Records.Get(_recordId).Returns(new RecordDo { RecordId = _recordId });
            _subject = new RecordService(_unitOfWork);
        }
    }
}
