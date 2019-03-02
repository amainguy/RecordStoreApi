using System;
using AutoFixture;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RecordStore.Data.Context;
using RecordStore.Data.Models;
using RecordStore.Data.Tests.DbSetCreator;
using RecordStore.DomainObjects;

namespace RecordStore.Data.Tests
{
    public class DbContextTests
    {
        protected IMapper _mapper;
        protected RecordStoreDbContext _dbContext;
        protected IFixture _auto;

        public void Setup()
        {
            _auto = new Fixture();
            _auto.Behaviors.Add(new OmitOnRecursionBehavior());

            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Artist, ArtistDo>().ReverseMap();
                c.CreateMap<Record, RecordDo>().ReverseMap();
            });

            _mapper = config.CreateMapper();

            _dbContext = new RecordStoreDbContext(GetDbContextOptions());
            RecordStoreDbSetCreator.CreateDbSet(_dbContext);
        }

        private DbContextOptions GetDbContextOptions()
        {
            return new DbContextOptionsBuilder<RecordStoreDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
        }
    }
}
