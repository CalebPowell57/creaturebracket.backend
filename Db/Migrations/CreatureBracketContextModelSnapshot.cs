﻿// <auto-generated />
using System;
using Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Db.Migrations
{
    [DbContext(typeof(CreatureBracketContext))]
    partial class CreatureBracketContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Model.Db.Bracket", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("CreatureCount")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Phase")
                        .HasColumnType("bigint");

                    b.Property<long>("RoundCount")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Bracket");
                });

            modelBuilder.Entity("Model.Db.Creature", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("BracketId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BracketId");

                    b.ToTable("Creature");
                });

            modelBuilder.Entity("Model.Db.CreatureSubmission", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("BracketId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BracketId");

                    b.ToTable("CreatureSubmission");
                });

            modelBuilder.Entity("Model.Db.CreatureSubmissionVote", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("CreatureSubmissionId")
                        .HasColumnType("bigint");

                    b.Property<string>("User")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CreatureSubmissionId");

                    b.ToTable("CreatureSubmissionVote");
                });

            modelBuilder.Entity("Model.Db.Matchup", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("BracketId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("Creature1Id")
                        .HasColumnType("bigint");

                    b.Property<long?>("Creature2Id")
                        .HasColumnType("bigint");

                    b.Property<long>("Rank")
                        .HasColumnType("bigint");

                    b.Property<long>("Round")
                        .HasColumnType("bigint");

                    b.Property<long?>("WinnerId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("BracketId");

                    b.HasIndex("Creature1Id");

                    b.HasIndex("Creature2Id");

                    b.HasIndex("WinnerId");

                    b.ToTable("Matchup");
                });

            modelBuilder.Entity("Model.Db.UserMatchup", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("BracketId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("Creature1Id")
                        .HasColumnType("bigint");

                    b.Property<long?>("Creature2Id")
                        .HasColumnType("bigint");

                    b.Property<long>("Rank")
                        .HasColumnType("bigint");

                    b.Property<long>("Round")
                        .HasColumnType("bigint");

                    b.Property<string>("User")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("WinnerId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("BracketId");

                    b.HasIndex("Creature1Id");

                    b.HasIndex("Creature2Id");

                    b.HasIndex("WinnerId");

                    b.ToTable("UserMatchup");
                });

            modelBuilder.Entity("Model.Db.Creature", b =>
                {
                    b.HasOne("Model.Db.Bracket", null)
                        .WithMany("Creatures")
                        .HasForeignKey("BracketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Model.Db.CreatureSubmission", b =>
                {
                    b.HasOne("Model.Db.Bracket", null)
                        .WithMany("CreatureSubmissions")
                        .HasForeignKey("BracketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Model.Db.CreatureSubmissionVote", b =>
                {
                    b.HasOne("Model.Db.CreatureSubmission", null)
                        .WithMany("Votes")
                        .HasForeignKey("CreatureSubmissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Model.Db.Matchup", b =>
                {
                    b.HasOne("Model.Db.Bracket", null)
                        .WithMany("Matchups")
                        .HasForeignKey("BracketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Model.Db.Creature", "Creature1")
                        .WithMany()
                        .HasForeignKey("Creature1Id");

                    b.HasOne("Model.Db.Creature", "Creature2")
                        .WithMany()
                        .HasForeignKey("Creature2Id");

                    b.HasOne("Model.Db.Creature", "Winner")
                        .WithMany()
                        .HasForeignKey("WinnerId");

                    b.Navigation("Creature1");

                    b.Navigation("Creature2");

                    b.Navigation("Winner");
                });

            modelBuilder.Entity("Model.Db.UserMatchup", b =>
                {
                    b.HasOne("Model.Db.Bracket", null)
                        .WithMany("UserMatchups")
                        .HasForeignKey("BracketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Model.Db.Creature", "Creature1")
                        .WithMany()
                        .HasForeignKey("Creature1Id");

                    b.HasOne("Model.Db.Creature", "Creature2")
                        .WithMany()
                        .HasForeignKey("Creature2Id");

                    b.HasOne("Model.Db.Creature", "Winner")
                        .WithMany()
                        .HasForeignKey("WinnerId");

                    b.Navigation("Creature1");

                    b.Navigation("Creature2");

                    b.Navigation("Winner");
                });

            modelBuilder.Entity("Model.Db.Bracket", b =>
                {
                    b.Navigation("CreatureSubmissions");

                    b.Navigation("Creatures");

                    b.Navigation("Matchups");

                    b.Navigation("UserMatchups");
                });

            modelBuilder.Entity("Model.Db.CreatureSubmission", b =>
                {
                    b.Navigation("Votes");
                });
#pragma warning restore 612, 618
        }
    }
}
