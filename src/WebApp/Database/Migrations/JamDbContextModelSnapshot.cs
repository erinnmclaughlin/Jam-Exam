﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApp.Database;

#nullable disable

namespace WebApp.Database.Migrations
{
    [DbContext(typeof(JamDbContext))]
    partial class JamDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebApp.Models.GameResult", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("PlayerName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("PlaylistId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.Property<int>("TotalCorrect")
                        .HasColumnType("int");

                    b.Property<int>("TotalGuessed")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PlayerName");

                    b.HasIndex("PlaylistId");

                    b.HasIndex("Timestamp");

                    b.ToTable("GameResults");
                });

            modelBuilder.Entity("WebApp.Models.Playlist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("SpotifyId")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("SpotifyId")
                        .IsUnique();

                    b.ToTable("Playlists");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Classic Rock",
                            SpotifyId = "37i9dQZF1DWXRqgorJj26U"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Indie",
                            SpotifyId = "37i9dQZF1DX2Nc3B70tvx0"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Pop",
                            SpotifyId = "37i9dQZF1DXcBWIGoYBM5M"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Hip Hop",
                            SpotifyId = "37i9dQZF1DX0XUsuxWHRQd"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Country",
                            SpotifyId = "37i9dQZF1DX1lVhptIYRda"
                        },
                        new
                        {
                            Id = 6,
                            Name = "1960's",
                            SpotifyId = "37i9dQZF1DWWzBc3TOlaAV"
                        },
                        new
                        {
                            Id = 7,
                            Name = "1970's",
                            SpotifyId = "37i9dQZF1DWTJ7xPn4vNaz"
                        },
                        new
                        {
                            Id = 8,
                            Name = "1980's",
                            SpotifyId = "37i9dQZF1DX4UtSsGT1Sbe"
                        },
                        new
                        {
                            Id = 9,
                            Name = "1990's",
                            SpotifyId = "37i9dQZF1DXbTxeAdrVG2l"
                        },
                        new
                        {
                            Id = 10,
                            Name = "2000's",
                            SpotifyId = "37i9dQZF1DX4o1oenSJRJd"
                        },
                        new
                        {
                            Id = 11,
                            Name = "All Time Hits",
                            SpotifyId = "6i2Qd6OpeRBAzxfscNXeWp"
                        });
                });

            modelBuilder.Entity("WebApp.Models.GameResult", b =>
                {
                    b.HasOne("WebApp.Models.Playlist", "Playlist")
                        .WithMany()
                        .HasForeignKey("PlaylistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Playlist");
                });
#pragma warning restore 612, 618
        }
    }
}
