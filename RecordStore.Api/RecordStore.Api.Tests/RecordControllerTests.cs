using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NSubstitute.ReturnsExtensions;
using RecordStore.Api.Controllers;
using RecordStore.DomainObjects;
using RecordStore.Services.Interfaces;

namespace RecordStore.Api.Tests
{
    [TestClass]
    public class RecordControllerTests
    {
        private IRecordService _recordService;
        private RecordsController _recordsController;
        private int _recordId;

        [TestInitialize]
        public void Initialize()
        {
            _recordId = 1;
            Setup();
        }

        [TestMethod]
        public async Task GetAll_ShouldReturnOkResult()
        {
            _recordService.GetAll().Returns(Substitute.For<IEnumerable<RecordDo>>());

            var result = await _recordsController.GetAll();

            result.Should().BeOfType<OkObjectResult>();
        }

        [TestMethod]
        public async Task GetById_WhenValidIdProvided_ShouldReturnOkObjectResult()
        {
            _recordService.GetById(_recordId).Returns(new RecordDo { RecordId = _recordId });

            var result = await _recordsController.GetById(_recordId);

            result.Should().BeOfType<OkObjectResult>();
        }

        [TestMethod]
        public async Task GetById_WhenInvalidIdProvided_ShouldReturnNotFoundResult()
        {
            _recordService.GetById(_recordId).ReturnsNull();

            var result = await _recordsController.GetById(_recordId);

            result.Should().BeOfType<NotFoundResult>();
        }

        [TestMethod]
        public async Task Create_WhenRecordIsNull_ShouldReturnBadRequestObjectResult()
        {
            var result = await _recordsController.Create(null);

            result.Should().BeOfType<BadRequestObjectResult>();
        }

        [TestMethod]
        public async Task Create_WhenRecordIsProvidedAndServiceDoNotThrowException_ShouldReturnCreatedAtRouteResult()
        {
            var result = await _recordsController.Create(Substitute.For<RecordDo>());

            result.Should().BeOfType<CreatedAtRouteResult>();
        }

        [TestMethod]
        public async Task Create_WhenRecordIsProvidedAndServiceThrowsException_ShouldReturnInternalServerErrorStatusCode()
        {
            var record = Substitute.For<RecordDo>();

            _recordService.Create(record).Throws<Exception>();

            var result = await _recordsController.Create(record);

            result.Should().BeOfType<StatusCodeResult>();
            result.As<StatusCodeResult>().StatusCode.Should().Be(500);
        }

        [TestMethod]
        public async Task Update_WhenIdIsZero_ShouldReturnBadRequestObjectResult()
        {
            var result = await _recordsController.Update(0, Substitute.For<RecordDo>());

            result.Should().BeOfType<BadRequestObjectResult>();
        }

        [TestMethod]
        public async Task Update_WhenRecordIsNull_ShouldReturnBadRequestObjectResult()
        {
            var result = await _recordsController.Update(_recordId, null);

            result.Should().BeOfType<BadRequestObjectResult>();
        }

        [TestMethod]
        public async Task Update_WhenRecordIsProvidedAndServiceThrowsException_ShouldReturnInternalServerErrorStatusCode()
        {
            var record = Substitute.For<RecordDo>();

            _recordService.Update(_recordId, record).Throws<Exception>();

            var result = await _recordsController.Update(_recordId, record);

            result.Should().BeOfType<StatusCodeResult>();
            result.As<StatusCodeResult>().StatusCode.Should().Be(500);
        }

        [TestMethod]
        public async Task Update_WhenRecordIsProvidedAndServiceDoNotThrowException_ShouldReturnCreatedAtRouteResult()
        {
            var result = await _recordsController.Update(_recordId, Substitute.For<RecordDo>());

            result.Should().BeOfType<OkResult>();
        }

        [TestMethod]
        public async Task Delete_WhenRecordIsNull_ShouldReturnBadRequestObjectResult()
        {
            var result = await _recordsController.Delete(null);

            result.Should().BeOfType<BadRequestObjectResult>();
        }

        [TestMethod]
        public async Task Delete_WhenRecordIsProvided_ShouldReturnOkResult()
        {
            var result = await _recordsController.Delete(Substitute.For<RecordDo>());

            result.Should().BeOfType<OkResult>();
        }


        [TestMethod]
        public async Task Delete_WhenRecordServiceThrowException_ShouldReturnInternalServerError()
        {
            var record = Substitute.For<RecordDo>();
            _recordService.Delete(record).Throws<Exception>();

            var result = await _recordsController.Delete(record);

            result.Should().BeOfType<StatusCodeResult>();
            result.As<StatusCodeResult>().StatusCode.Should().Be(500);
        }


        private void Setup()
        {
            _recordService = Substitute.For<IRecordService>();
            _recordsController = new RecordsController(_recordService);
        }
    }
}

