using System.Collections.Generic;
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
        public void Get_WhenRouteIsCalled_ThenControllerShouldReturnRecords()
        {
            var result = _recordsController.Get();
            result.GetType().Should().BeAssignableTo<IEnumerable<Record>>();
        }

        [TestMethod]
        public void Get_WhenRouteIsCalledWithValidId_ThenControllerShouldReturnRecord()
        {
            var result = _recordsController.Get(_recordId);
            result.Should().BeOfType<Record>();
        }

        [TestMethod]
        public void Get_WhenRouteIsCalledWithValidId_ThenControllerShouldReturnCorrespondingRecord()
        {
            var result = _recordsController.Get(_recordId);
            result.Id.Should().Be(_recordId);
        }

    }
}
