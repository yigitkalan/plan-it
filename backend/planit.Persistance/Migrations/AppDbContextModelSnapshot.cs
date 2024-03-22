﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using planit.Persistance.Contexts;

#nullable disable

namespace planit.Persistance.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("BoardUser", b =>
                {
                    b.Property<int>("ParticipatedBoardsId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UsersId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ParticipatedBoardsId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("BoardUser");
                });

            modelBuilder.Entity("ItemUser", b =>
                {
                    b.Property<int>("AssignedUsersId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TasksId")
                        .HasColumnType("INTEGER");

                    b.HasKey("AssignedUsersId", "TasksId");

                    b.HasIndex("TasksId");

                    b.ToTable("ItemUser");
                });

            modelBuilder.Entity("planit.Domain.Entities.Board", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("OwnerId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Boards");
                });

            modelBuilder.Entity("planit.Domain.Entities.Column", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BoardId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("BoardId");

                    b.ToTable("Columns");
                });

            modelBuilder.Entity("planit.Domain.Entities.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ColumnId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ColumnId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("planit.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BoardUser", b =>
                {
                    b.HasOne("planit.Domain.Entities.Board", null)
                        .WithMany()
                        .HasForeignKey("ParticipatedBoardsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("planit.Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ItemUser", b =>
                {
                    b.HasOne("planit.Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("AssignedUsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("planit.Domain.Entities.Item", null)
                        .WithMany()
                        .HasForeignKey("TasksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("planit.Domain.Entities.Column", b =>
                {
                    b.HasOne("planit.Domain.Entities.Board", "Board")
                        .WithMany("Columns")
                        .HasForeignKey("BoardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Board");
                });

            modelBuilder.Entity("planit.Domain.Entities.Item", b =>
                {
                    b.HasOne("planit.Domain.Entities.Column", "Column")
                        .WithMany("Tasks")
                        .HasForeignKey("ColumnId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Column");
                });

            modelBuilder.Entity("planit.Domain.Entities.Board", b =>
                {
                    b.Navigation("Columns");
                });

            modelBuilder.Entity("planit.Domain.Entities.Column", b =>
                {
                    b.Navigation("Tasks");
                });
#pragma warning restore 612, 618
        }
    }
}
