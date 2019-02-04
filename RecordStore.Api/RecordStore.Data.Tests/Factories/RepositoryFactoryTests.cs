using System;
using AutoMapper;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using RecordStore.Data.Context;
using RecordStore.Data.Repositories.Factories;
using RecordStore.Data.Repositories.Implementations;
using RecordStore.Data.Repositories.Interfaces;

namespace RecordStore.Data.Tests.Factories
{
    [TestClass]
    public class RepositoryFactoryTests
    {
        private IMapper _mapper;
        private RecordStoreDbContext _dbContext;
        private RepositoryFactory _subject;

        [TestInitialize]
        public void Initialize()
        {
            _mapper = Substitute.For<IMapper>();
            _dbContext = new RecordStoreDbContext();
            _subject = new RepositoryFactory(_dbContext, _mapper);
        }

        [TestMethod]
        public void GetRepository_WhenRepositoryTypeIsRecord_ThenShouldReturnRecordRepository()
        {
            var repo = _subject.GetRepository<IRecordRepository>();

            repo.Should().BeOfType<RecordRepository>();
        }

        [TestMethod]
        public void GetRepository_WhenRepositoryTypeIsArtist_ThenShouldReturnArtistRepository()
        {
            var repo = _subject.GetRepository<IArtistRepository>();

            repo.Should().BeOfType<ArtistRepository>();
        }

        [TestMethod]
        public void GetRepository_WhenRepositoryTypeIsNotSupported_ThenShouldThrowArgumentException()
        {
            _subject.Invoking(s => s.GetRepository<ArtistRepository>())
                .Should().Throw<ArgumentException>();
        }
    }
}
