﻿// <auto-generated />
using System;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(StreamerDataContext))]
    partial class StreamerDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Domain.Entities.StreamerData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AvatarUrl")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<DateTime>("DownloadedOn")
                        .HasColumnType("datetime");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("varchar(80)");

                    b.Property<string>("YoutubeName")
                        .IsRequired()
                        .HasColumnType("varchar(80)");

                    b.Property<string>("YoutubeUrl")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.ToTable("StreamerData");
                });
#pragma warning restore 612, 618
        }
    }
}
