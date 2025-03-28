﻿// <auto-generated />
using System;
using Makc.Dummy.Writer.Infrastructure.EntityFramework.App.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Makc.Dummy.Writer.Infrastructure.EntityFrameworkForMSSQLServer.App.Db.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250216172751_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Makc.Dummy.Writer.DomainModel.AppEvent.AppEventEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<Guid>("ConcurrencyToken")
                        .IsConcurrencyToken()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ConcurrencyToken");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetimeoffset")
                        .HasColumnName("CreatedAt");

                    b.Property<bool>("IsPublished")
                        .HasColumnType("bit")
                        .HasColumnName("IsPublished");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("Name");

                    b.HasKey("Id")
                        .HasName("PK_AppEvent");

                    b.ToTable("AppEvent", "writer");
                });

            modelBuilder.Entity("Makc.Dummy.Writer.DomainModel.AppEventPayload.AppEventPayloadEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("AppEventId")
                        .HasColumnType("bigint")
                        .HasColumnName("AppEventId");

                    b.Property<Guid>("ConcurrencyToken")
                        .IsConcurrencyToken()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ConcurrencyToken");

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Data");

                    b.HasKey("Id")
                        .HasName("PK_AppEventPayload");

                    b.HasIndex("AppEventId");

                    b.ToTable("AppEventPayload", "writer");
                });

            modelBuilder.Entity("Makc.Dummy.Writer.DomainModel.DummyItem.DummyItemEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<Guid>("ConcurrencyToken")
                        .IsConcurrencyToken()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ConcurrencyToken");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("Name");

                    b.HasKey("Id")
                        .HasName("PK_DummyItem");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasDatabaseName("UX_DummyItem_Name");

                    b.ToTable("DummyItem", "writer");
                });

            modelBuilder.Entity("Makc.Dummy.Writer.DomainModel.AppEventPayload.AppEventPayloadEntity", b =>
                {
                    b.HasOne("Makc.Dummy.Writer.DomainModel.AppEvent.AppEventEntity", "Event")
                        .WithMany("Payloads")
                        .HasForeignKey("AppEventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_AppEventPayload_AppEvent");

                    b.Navigation("Event");
                });

            modelBuilder.Entity("Makc.Dummy.Writer.DomainModel.AppEvent.AppEventEntity", b =>
                {
                    b.Navigation("Payloads");
                });
#pragma warning restore 612, 618
        }
    }
}
