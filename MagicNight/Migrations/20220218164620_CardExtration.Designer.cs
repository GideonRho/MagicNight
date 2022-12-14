// <auto-generated />
using System;
using MagicNight.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MagicNight.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20220218164620_CardExtration")]
    partial class CardExtration
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

                    b.Property<int>("ProducedMana")
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

                    b.ToTable("Card");
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

                    b.ToTable("CardMinorType");
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

                    b.ToTable("CardSynergy");
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

                    b.ToTable("Commanders");
                });

            modelBuilder.Entity("MagicNight.Models.Database.Decks.Deck", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("OwnerName")
                        .HasColumnType("TEXT");

                    b.Property<int>("Type")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("OwnerName");

                    b.ToTable("Decks");
                });

            modelBuilder.Entity("MagicNight.Models.Database.Decks.Values.DeckCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CardName")
                        .HasColumnType("TEXT");

                    b.Property<int?>("DeckId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CardName");

                    b.HasIndex("DeckId");

                    b.ToTable("DeckCards");
                });

            modelBuilder.Entity("MagicNight.Models.Database.Profiles.Profile", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDisabled")
                        .HasColumnType("INTEGER");

                    b.HasKey("Name");

                    b.ToTable("Profiles");
                });

            modelBuilder.Entity("MagicNight.Models.Database.Tournaments.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("MagicNight.Models.Database.Tournaments.Match", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("GroupId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PlayerAName")
                        .HasColumnType("TEXT");

                    b.Property<string>("PlayerBName")
                        .HasColumnType("TEXT");

                    b.Property<int>("Winner")
                        .HasColumnType("INTEGER");

                    b.Property<int>("WinsA")
                        .HasColumnType("INTEGER");

                    b.Property<int>("WinsB")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("PlayerAName");

                    b.HasIndex("PlayerBName");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("MagicNight.Models.Database.Tournaments.Tournament", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("GroupId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("Type")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.ToTable("Tournaments");
                });

            modelBuilder.Entity("MagicNight.Models.Database.Tournaments.Values.GroupEntry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Buchholz")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("GroupId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Loses")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("Rank")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Wins")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("Name");

                    b.ToTable("GroupEntries");
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

            modelBuilder.Entity("MagicNight.Models.Database.Decks.Deck", b =>
                {
                    b.HasOne("MagicNight.Models.Database.Profiles.Profile", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerName");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("MagicNight.Models.Database.Decks.Values.DeckCard", b =>
                {
                    b.HasOne("MagicNight.Models.Database.Cards.Card", "Card")
                        .WithMany()
                        .HasForeignKey("CardName");

                    b.HasOne("MagicNight.Models.Database.Decks.Deck", "Deck")
                        .WithMany("Cards")
                        .HasForeignKey("DeckId");

                    b.Navigation("Card");

                    b.Navigation("Deck");
                });

            modelBuilder.Entity("MagicNight.Models.Database.Tournaments.Match", b =>
                {
                    b.HasOne("MagicNight.Models.Database.Tournaments.Group", "Group")
                        .WithMany("Matches")
                        .HasForeignKey("GroupId");

                    b.HasOne("MagicNight.Models.Database.Profiles.Profile", "PlayerA")
                        .WithMany()
                        .HasForeignKey("PlayerAName");

                    b.HasOne("MagicNight.Models.Database.Profiles.Profile", "PlayerB")
                        .WithMany()
                        .HasForeignKey("PlayerBName");

                    b.Navigation("Group");

                    b.Navigation("PlayerA");

                    b.Navigation("PlayerB");
                });

            modelBuilder.Entity("MagicNight.Models.Database.Tournaments.Tournament", b =>
                {
                    b.HasOne("MagicNight.Models.Database.Tournaments.Group", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId");

                    b.Navigation("Group");
                });

            modelBuilder.Entity("MagicNight.Models.Database.Tournaments.Values.GroupEntry", b =>
                {
                    b.HasOne("MagicNight.Models.Database.Tournaments.Group", "Group")
                        .WithMany("Entries")
                        .HasForeignKey("GroupId");

                    b.HasOne("MagicNight.Models.Database.Profiles.Profile", "Profile")
                        .WithMany()
                        .HasForeignKey("Name");

                    b.Navigation("Group");

                    b.Navigation("Profile");
                });

            modelBuilder.Entity("MagicNight.Models.Database.Cards.Card", b =>
                {
                    b.Navigation("Commanders");

                    b.Navigation("Keywords");

                    b.Navigation("MinorTypes");

                    b.Navigation("Synergies");
                });

            modelBuilder.Entity("MagicNight.Models.Database.Decks.Deck", b =>
                {
                    b.Navigation("Cards");
                });

            modelBuilder.Entity("MagicNight.Models.Database.Tournaments.Group", b =>
                {
                    b.Navigation("Entries");

                    b.Navigation("Matches");
                });
#pragma warning restore 612, 618
        }
    }
}
