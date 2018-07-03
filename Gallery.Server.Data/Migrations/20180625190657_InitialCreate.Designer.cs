﻿// <auto-generated />
using System;
using Gallery.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Gallery.Server.Data.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20180625190657_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Gallery.Server.Data.Entities.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AuthorId");

                    b.Property<string>("Content");

                    b.Property<DateTime>("Date");

                    b.Property<int?>("PictureId");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("PictureId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Gallery.Server.Data.Entities.Picture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AuthorId");

                    b.Property<string>("Description");

                    b.Property<int>("LikeCount");

                    b.Property<string>("Path");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Pictures");
                });

            modelBuilder.Entity("Gallery.Server.Data.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email");

                    b.Property<string>("Password");

                    b.Property<int>("Role");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Gallery.Server.Data.Entities.Comment", b =>
                {
                    b.HasOne("Gallery.Server.Data.Entities.User", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId");

                    b.HasOne("Gallery.Server.Data.Entities.Picture")
                        .WithMany("Comments")
                        .HasForeignKey("PictureId");
                });

            modelBuilder.Entity("Gallery.Server.Data.Entities.Picture", b =>
                {
                    b.HasOne("Gallery.Server.Data.Entities.User", "Author")
                        .WithMany("Pictures")
                        .HasForeignKey("AuthorId");
                });
#pragma warning restore 612, 618
        }
    }
}