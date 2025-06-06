﻿// <auto-generated />
using System;
using Makc.Dummy.MicroserviceWriterViaSQL.Infrastructure.EntityFramework.App.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Makc.Dummy.MicroserviceWriterViaSQL.Infrastructure.EntityFrameworkForMSSQLServer.App.Db.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250430230424_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Makc.Dummy.MicroserviceWriterViaSQL.Domain.Model.AppOutgoingEvent.AppOutgoingEventEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("ConcurrencyToken")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("ConcurrencyToken");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetimeoffset")
                        .HasColumnName("CreatedAt");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("Name");

                    b.Property<DateTimeOffset?>("PublishedAt")
                        .HasColumnType("datetimeoffset")
                        .HasColumnName("PublishedAt");

                    b.HasKey("Id")
                        .HasName("PK_AppOutgoingEvent");

                    b.ToTable("AppOutgoingEvent", "writer");
                });

            modelBuilder.Entity("Makc.Dummy.MicroserviceWriterViaSQL.Domain.Model.AppOutgoingEventPayload.AppOutgoingEventPayloadEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("AppOutgoingEventId")
                        .HasColumnType("bigint")
                        .HasColumnName("AppOutgoingEventId");

                    b.Property<string>("ConcurrencyToken")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("ConcurrencyToken");

                    b.Property<string>("Data")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Data");

                    b.Property<string>("EntityConcurrencyTokenToDelete")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("EntityConcurrencyTokenToDelete");

                    b.Property<string>("EntityConcurrencyTokenToInsert")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("EntityConcurrencyTokenToInsert");

                    b.Property<string>("EntityId")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("EntityId");

                    b.Property<string>("EntityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("EntityName");

                    b.Property<int>("Position")
                        .HasColumnType("int")
                        .HasColumnName("Position");

                    b.HasKey("Id")
                        .HasName("PK_AppOutgoingEventPayload");

                    b.HasIndex("AppOutgoingEventId");

                    b.ToTable("AppOutgoingEventPayload", "writer");
                });

            modelBuilder.Entity("Makc.Dummy.MicroserviceWriterViaSQL.Domain.Model.DummyItem.DummyItemEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("ConcurrencyToken")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
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

            modelBuilder.Entity("Makc.Dummy.MicroserviceWriterViaSQL.Domain.Model.AppOutgoingEventPayload.AppOutgoingEventPayloadEntity", b =>
                {
                    b.HasOne("Makc.Dummy.MicroserviceWriterViaSQL.Domain.Model.AppOutgoingEvent.AppOutgoingEventEntity", "AppOutgoingEvent")
                        .WithMany("Payloads")
                        .HasForeignKey("AppOutgoingEventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_AppOutgoingEventPayload_AppOutgoingEvent");

                    b.Navigation("AppOutgoingEvent");
                });

            modelBuilder.Entity("Makc.Dummy.MicroserviceWriterViaSQL.Domain.Model.AppOutgoingEvent.AppOutgoingEventEntity", b =>
                {
                    b.Navigation("Payloads");
                });
#pragma warning restore 612, 618
        }
    }
}
