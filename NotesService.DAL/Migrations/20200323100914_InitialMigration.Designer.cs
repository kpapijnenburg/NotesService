﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NotesService.DAL;

namespace NotesService.DAL.Migrations
{
    [DbContext(typeof(NotesContext))]
    [Migration("20200323100914_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("NotesService.Domain.Models.HandwrittenText", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("Image")
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("NoteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("NoteId")
                        .IsUnique();

                    b.ToTable("HandwrittenTexts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2020, 3, 23, 11, 9, 14, 449, DateTimeKind.Local).AddTicks(7904),
                            NoteId = 1,
                            UpdatedAt = new DateTime(2020, 3, 23, 11, 9, 14, 449, DateTimeKind.Local).AddTicks(7932)
                        });
                });

            modelBuilder.Entity("NotesService.Domain.Models.Note", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("HandwrittenTextId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Notes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Content = "Test Content",
                            CreatedAt = new DateTime(2020, 3, 23, 11, 9, 14, 444, DateTimeKind.Local).AddTicks(2579),
                            HandwrittenTextId = 1,
                            Title = "Test Title",
                            UpdatedAt = new DateTime(2020, 3, 23, 11, 9, 14, 447, DateTimeKind.Local).AddTicks(4592)
                        });
                });

            modelBuilder.Entity("NotesService.Domain.Models.HandwrittenText", b =>
                {
                    b.HasOne("NotesService.Domain.Models.Note", "Note")
                        .WithOne("HandwrittenText")
                        .HasForeignKey("NotesService.Domain.Models.HandwrittenText", "NoteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
