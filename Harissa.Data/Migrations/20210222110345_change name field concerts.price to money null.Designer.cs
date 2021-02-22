﻿// <auto-generated />
using System;
using Harissa.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Harissa.Data.Migrations
{
    [DbContext(typeof(HarissaContext))]
    [Migration("20210222110345_change name field concerts.price to money null")]
    partial class changenamefieldconcertspricetomoneynull
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Harissa.Data.Data.Bio", b =>
                {
                    b.Property<int>("BioID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BioID");

                    b.ToTable("Bio");
                });

            modelBuilder.Entity("Harissa.Data.Data.Concert", b =>
                {
                    b.Property<int>("ConcertID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Link")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MediaItem")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Price")
                        .HasColumnType("money");

                    b.HasKey("ConcertID");

                    b.ToTable("Concerts");
                });

            modelBuilder.Entity("Harissa.Data.Data.Contact", b =>
                {
                    b.Property<int>("ContactID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ContactID");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("Harissa.Data.Data.IndexPage", b =>
                {
                    b.Property<int>("IndexPageID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("IndexPageID");

                    b.ToTable("IndexPages");
                });

            modelBuilder.Entity("Harissa.Data.Data.MediaPatronage", b =>
                {
                    b.Property<int>("MediaPatronageID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Link")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MediaPatronageID");

                    b.ToTable("mediaPatronages");
                });

            modelBuilder.Entity("Harissa.Data.Data.News", b =>
                {
                    b.Property<int>("NewsID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateOfPublication")
                        .HasColumnType("datetime2");

                    b.Property<string>("MediaItem")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NewsID");

                    b.ToTable("News");
                });

            modelBuilder.Entity("Harissa.Data.Data.PageSettings", b =>
                {
                    b.Property<int>("PageSettingsID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NoPicture")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PageSettingsID");

                    b.ToTable("PageSettings");
                });

            modelBuilder.Entity("Harissa.Data.Data.SocialMedia", b =>
                {
                    b.Property<int>("SocialMediaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Icon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Link")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PageSettingsID")
                        .HasColumnType("int");

                    b.HasKey("SocialMediaID");

                    b.HasIndex("PageSettingsID");

                    b.ToTable("SocialMedias");
                });

            modelBuilder.Entity("Harissa.Data.Data.SocialMedia", b =>
                {
                    b.HasOne("Harissa.Data.Data.PageSettings", "pageSettings")
                        .WithMany("socialMedias")
                        .HasForeignKey("PageSettingsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("pageSettings");
                });

            modelBuilder.Entity("Harissa.Data.Data.PageSettings", b =>
                {
                    b.Navigation("socialMedias");
                });
#pragma warning restore 612, 618
        }
    }
}
