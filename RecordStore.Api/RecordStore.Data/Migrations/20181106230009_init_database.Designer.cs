﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RecordStore.Data;

namespace RecordStore.Data.Migrations
{
    [DbContext(typeof(RecordStoreDbContext))]
    [Migration("20181106230009_init_database")]
    partial class init_database
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024");

            modelBuilder.Entity("RecordStore.Data.Models.Artist", b =>
                {
                    b.Property<int>("ArtistId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.HasKey("ArtistId");

                    b.ToTable("Artists");
                });

            modelBuilder.Entity("RecordStore.Data.Models.Record", b =>
                {
                    b.Property<int>("RecordId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ArtistId");

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