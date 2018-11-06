﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RecordStore.Data;

namespace RecordStore.Data.Migrations
{
    [DbContext(typeof(RecordStoreDbContext))]
    partial class RecordStoreDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024");

            modelBuilder.Entity("RecordStore.Data.Models.Artist", b =>
                {
                    b.Property<int>("ArtistId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<DateTime>("Modified");

                    b.HasKey("ArtistId");

                    b.ToTable("Artists");
                });

            modelBuilder.Entity("RecordStore.Data.Models.Record", b =>
                {
                    b.Property<int>("RecordId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ArtistId");

                    b.Property<DateTime>("Created");

                    b.Property<DateTime>("Modified");

                    b.Property<int>("ReleaseYear");

                    b.Property<string>("Title");

                    b.HasKey("RecordId");

                    b.HasIndex("ArtistId");

                    b.ToTable("Records");
                });

            modelBuilder.Entity("RecordStore.Data.Models.Record", b =>
                {
                    b.HasOne("RecordStore.Data.Models.Artist", "Artist")
                        .WithMany("Records")
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
