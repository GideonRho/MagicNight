﻿// <auto-generated />
using MagicNight.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MagicNight.Migrations.Cards
{
    [DbContext(typeof(CardsContext))]
    [Migration("20220218183038_AddPriceAndRanking")]
    partial class AddPriceAndRanking
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.14");

            modelBuilder.Entity("MagicNight.Models.Database.Cards.Card", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("Colors")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Cost")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("Image")
                        .HasColumnType("TEXT");

                    b.Property<int>("Legalities")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PartnerName")
                        .HasColumnType("TEXT");

                    b.Property<string>("PartnerString")
                        .HasColumnType("TEXT");

                    b.Property<int>("Power")
                        .HasColumnType("INTEGER");

                    b.Property<float>("Price")
                        .HasColumnType("REAL");

                    b.Property<int>("ProducedMana")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Rank")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ReleaseDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Text")
                        .HasColumnType("TEXT");

                    b.Property<string>("Thumbnail")
                        .HasColumnType("TEXT");

                    b.Property<int>("Toughness")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Types")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Uri")
                        .HasColumnType("TEXT");

                    b.HasKey("Name");

                    b.HasIndex("PartnerName");

                    b.ToTable("Cards");
                });

            modelBuilder.Entity("MagicNight.Models.Database.Cards.CardKeyword", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CardName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CardName");

                    b.ToTable("CardKeyword");
                });

            modelBuilder.Entity("MagicNight.Models.Database.Cards.CardMinorType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CardName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Type")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CardName");

                    b.ToTable("CardMinorTypes");
                });

            modelBuilder.Entity("MagicNight.Models.Database.Cards.CardSynergy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CardName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Type")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CardName");

                    b.ToTable("CardSynergies");
                });

            modelBuilder.Entity("MagicNight.Models.Database.Cards.Commander", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CardName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CardName");

                    b.ToTable("Commander");
                });

            modelBuilder.Entity("MagicNight.Models.Database.Cards.Card", b =>
                {
                    b.HasOne("MagicNight.Models.Database.Cards.Card", "Partner")
                        .WithMany()
                        .HasForeignKey("PartnerName");

                    b.Navigation("Partner");
                });

            modelBuilder.Entity("MagicNight.Models.Database.Cards.CardKeyword", b =>
                {
                    b.HasOne("MagicNight.Models.Database.Cards.Card", "Card")
                        .WithMany("Keywords")
                        .HasForeignKey("CardName");

                    b.Navigation("Card");
                });

            modelBuilder.Entity("MagicNight.Models.Database.Cards.CardMinorType", b =>
                {
                    b.HasOne("MagicNight.Models.Database.Cards.Card", "Card")
                        .WithMany("MinorTypes")
                        .HasForeignKey("CardName");

                    b.Navigation("Card");
                });

            modelBuilder.Entity("MagicNight.Models.Database.Cards.CardSynergy", b =>
                {
                    b.HasOne("MagicNight.Models.Database.Cards.Card", "Card")
                        .WithMany("Synergies")
                        .HasForeignKey("CardName");

                    b.Navigation("Card");
                });

            modelBuilder.Entity("MagicNight.Models.Database.Cards.Commander", b =>
                {
                    b.HasOne("MagicNight.Models.Database.Cards.Card", "Card")
                        .WithMany("Commanders")
                        .HasForeignKey("CardName");

                    b.Navigation("Card");
                });

            modelBuilder.Entity("MagicNight.Models.Database.Cards.Card", b =>
                {
                    b.Navigation("Commanders");

                    b.Navigation("Keywords");

                    b.Navigation("MinorTypes");

                    b.Navigation("Synergies");
                });
#pragma warning restore 612, 618
        }
    }
}
