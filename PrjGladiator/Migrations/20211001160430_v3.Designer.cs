﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PrjGladiator.Models;

namespace PrjGladiator.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20211001160430_v3")]
    partial class v3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PrjGladiator.Models.Question", b =>
                {
                    b.Property<int>("Question_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Correct_Option")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Option1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Option2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Option3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Option4")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QuestionSetRef_Id")
                        .HasColumnType("int");

                    b.Property<string>("Question_Desc")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Question_Id");

                    b.HasIndex("QuestionSetRef_Id");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("PrjGladiator.Models.QuestionSet", b =>
                {
                    b.Property<int>("QuestionSet_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<int>("SubjectRef_Id")
                        .HasColumnType("int");

                    b.HasKey("QuestionSet_Id");

                    b.HasIndex("SubjectRef_Id");

                    b.ToTable("QuestionSets");
                });

            modelBuilder.Entity("PrjGladiator.Models.Report", b =>
                {
                    b.Property<int>("Report_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Marks")
                        .HasColumnType("int");

                    b.Property<int>("QuestionSetRef_Id")
                        .HasColumnType("int");

                    b.Property<int>("UserRef_Id")
                        .HasColumnType("int");

                    b.HasKey("Report_Id");

                    b.HasIndex("QuestionSetRef_Id");

                    b.HasIndex("UserRef_Id");

                    b.ToTable("Reports");
                });

            modelBuilder.Entity("PrjGladiator.Models.Subject", b =>
                {
                    b.Property<int>("Subject_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Subject_Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Subject_Id");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("PrjGladiator.Models.User", b =>
                {
                    b.Property<int>("User_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MobileNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Qualification")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("YearOfCompletion")
                        .HasColumnType("int");

                    b.HasKey("User_Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("PrjGladiator.Models.Question", b =>
                {
                    b.HasOne("PrjGladiator.Models.QuestionSet", "QuestionSet")
                        .WithMany("Questions")
                        .HasForeignKey("QuestionSetRef_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("QuestionSet");
                });

            modelBuilder.Entity("PrjGladiator.Models.QuestionSet", b =>
                {
                    b.HasOne("PrjGladiator.Models.Subject", "Subject")
                        .WithMany("QuestionSets")
                        .HasForeignKey("SubjectRef_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("PrjGladiator.Models.Report", b =>
                {
                    b.HasOne("PrjGladiator.Models.QuestionSet", "QuestionSet")
                        .WithMany()
                        .HasForeignKey("QuestionSetRef_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PrjGladiator.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserRef_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("QuestionSet");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PrjGladiator.Models.QuestionSet", b =>
                {
                    b.Navigation("Questions");
                });

            modelBuilder.Entity("PrjGladiator.Models.Subject", b =>
                {
                    b.Navigation("QuestionSets");
                });
#pragma warning restore 612, 618
        }
    }
}
