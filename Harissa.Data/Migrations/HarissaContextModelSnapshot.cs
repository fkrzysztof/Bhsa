﻿// <auto-generated />
using System;
using Harissa.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Harissa.Data.Migrations
{
    [DbContext(typeof(HarissaContext))]
    partial class HarissaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Price")
                        .HasColumnType("nvarchar(max)");

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

                    b.ToTable("MediaPatronages");
                });

            modelBuilder.Entity("Harissa.Data.Data.Music", b =>
                {
                    b.Property<int>("MusicID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cover")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DateOfPublication")
                        .HasColumnType("int");

                    b.Property<string>("IFrame")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MusicID");

                    b.ToTable("Musics");
                });

            modelBuilder.Entity("Harissa.Data.Data.MusicLink", b =>
                {
                    b.Property<int>("MusicLinkID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("LinkToAlbum")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MusicID")
                        .HasColumnType("int");

                    b.Property<int>("MusicPlatformID")
                        .HasColumnType("int");

                    b.HasKey("MusicLinkID");

                    b.HasIndex("MusicID");

                    b.HasIndex("MusicPlatformID");

                    b.ToTable("MusicLinks");
                });

            modelBuilder.Entity("Harissa.Data.Data.MusicPlatform", b =>
                {
                    b.Property<int>("MusicPlatformID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Icon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MusicPlatformID");

                    b.ToTable("MusicPlatforms");
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
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
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

                    b.Property<string>("Logo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NoPicture")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PageSettingsID");

                    b.ToTable("PageSettings");
                });

            modelBuilder.Entity("Harissa.Data.Data.PrivacyPolicy", b =>
                {
                    b.Property<int>("PrivacyPolicyID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PageSettingsID")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PrivacyPolicyID");

                    b.HasIndex("PageSettingsID")
                        .IsUnique();

                    b.ToTable("PrivacyPolicies");
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

            modelBuilder.Entity("Harissa.Data.Data.Video", b =>
                {
                    b.Property<int>("VideoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Index")
                        .HasColumnType("int");

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VideoID");

                    b.ToTable("Videos");
                });

            modelBuilder.Entity("Harissa.Data.Data.MusicLink", b =>
                {
                    b.HasOne("Harissa.Data.Data.Music", "Music")
                        .WithMany("MusicLinks")
                        .HasForeignKey("MusicID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Harissa.Data.Data.MusicPlatform", "MusicPlatform")
                        .WithMany("MusicLinks")
                        .HasForeignKey("MusicPlatformID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Music");

                    b.Navigation("MusicPlatform");
                });

            modelBuilder.Entity("Harissa.Data.Data.PrivacyPolicy", b =>
                {
                    b.HasOne("Harissa.Data.Data.PageSettings", "pageSettings")
                        .WithOne("privacyPolicy")
                        .HasForeignKey("Harissa.Data.Data.PrivacyPolicy", "PageSettingsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("pageSettings");
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

            modelBuilder.Entity("Harissa.Data.Data.Music", b =>
                {
                    b.Navigation("MusicLinks");
                });

            modelBuilder.Entity("Harissa.Data.Data.MusicPlatform", b =>
                {
                    b.Navigation("MusicLinks");
                });

            modelBuilder.Entity("Harissa.Data.Data.PageSettings", b =>
                {
                    b.Navigation("privacyPolicy");

                    b.Navigation("socialMedias");
                });
#pragma warning restore 612, 618
        }
    }
}
