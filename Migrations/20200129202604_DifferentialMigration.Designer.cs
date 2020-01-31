﻿// <auto-generated />
using GolfHandicap.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GolfHandicap.Migrations
{
    [DbContext(typeof(RoundDbContext))]
    [Migration("20200129202604_DifferentialMigration")]
    partial class DifferentialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GolfHandicap.Models.Round", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Course")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Rating")
                        .HasColumnType("real");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.Property<float>("ScoreDifferential")
                        .HasColumnType("real");

                    b.Property<int>("Slope")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Rounds");
                });
#pragma warning restore 612, 618
        }
    }
}
