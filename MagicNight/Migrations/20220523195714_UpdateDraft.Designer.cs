﻿// <auto-generated />
using System;
using MagicNight.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MagicNight.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20220523195714_UpdateDraft")]
    partial class UpdateDraft
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

            modelBuilder.Entity("MagicNight.Models.Database.Drafts.Draft", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("TEXT");

                    b.Property<int>("PickTime")
                        .HasColumnType("INTEGER");

                    b.Property<int>("State")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Timer")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Drafts");
                });

            modelBuilder.Entity("MagicNight.Models.Database.Drafts.DraftPack", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("DraftId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsPicked")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ProfileId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("DraftId");

                    b.HasIndex("ProfileId");

                    b.ToTable("DraftPacks");
                });

            modelBuilder.Entity("MagicNight.Models.Database.Drafts.Values.DraftPackCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CardName")
                        .HasColumnType("TEXT");

                    b.Property<int?>("PackId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ProfileName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CardName");

                    b.HasIndex("PackId");

                    b.HasIndex("ProfileName");

                    b.ToTable("DraftPackCards");
                });

            modelBuilder.Entity("MagicNight.Models.Database.Drafts.Values.DraftProfile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("DraftId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("NextName")
                        .HasColumnType("TEXT");

                    b.Property<string>("PreviousName")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProfileName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("DraftId");

                    b.HasIndex("NextName");

                    b.HasIndex("PreviousName");

                    b.HasIndex("ProfileName");

                    b.ToTable("DraftProfiles");
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

            modelBuilder.Entity("MagicNight.Models.Database.Rolls.CommanderRoll", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("CommanderRolls");
                });

            modelBuilder.Entity("MagicNight.Models.Database.Rolls.SetRoll", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("SetRolls");
                });

            modelBuilder.Entity("MagicNight.Models.Database.Rolls.Values.CommanderRollEntry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CommanderName")
                        .HasColumnType("TEXT");

                    b.Property<int?>("CommanderRollId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PartnerName")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProfileName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CommanderName");

                    b.HasIndex("CommanderRollId");

                    b.HasIndex("PartnerName");

                    b.HasIndex("ProfileName");

                    b.ToTable("CommanderRollEntries");
                });

            modelBuilder.Entity("MagicNight.Models.Database.Rolls.Values.SetRollEntry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("DeckId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ProfileName")
                        .HasColumnType("TEXT");

                    b.Property<string>("SetCode")
                        .HasColumnType("TEXT");

                    b.Property<int?>("SetRollId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("DeckId");

                    b.HasIndex("ProfileName");

                    b.HasIndex("SetCode");

                    b.HasIndex("SetRollId");

                    b.ToTable("SetRollEntries");
                });

            modelBuilder.Entity("MagicNight.Models.Database.Sets.Set", b =>
                {
                    b.Property<string>("Code")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Type")
                        .HasColumnType("TEXT");

                    b.HasKey("Code");

                    b.ToTable("Sets");
                });

            modelBuilder.Entity("MagicNight.Models.Database.Sets.SetSettings", b =>
                {
                    b.Property<string>("Code")
                        .HasColumnType("TEXT");

                    b.Property<bool>("CanRoll")
                        .HasColumnType("INTEGER");

                    b.HasKey("Code");

                    b.ToTable("SetSettings");
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

                    b.Property<int>("State")
                        .HasColumnType("INTEGER");

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

            modelBuilder.Entity("MagicNight.Models.Database.Tournaments.Values.TournamentParticipant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ProfileName")
                        .HasColumnType("TEXT");

                    b.Property<int?>("TournamentId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ProfileName");

                    b.HasIndex("TournamentId");

                    b.ToTable("TournamentParticipant");
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

            modelBuilder.Entity("MagicNight.Models.Database.Drafts.DraftPack", b =>
                {
                    b.HasOne("MagicNight.Models.Database.Drafts.Draft", "Draft")
                        .WithMany("Packs")
                        .HasForeignKey("DraftId");

                    b.HasOne("MagicNight.Models.Database.Drafts.Values.DraftProfile", "Profile")
                        .WithMany()
                        .HasForeignKey("ProfileId");

                    b.Navigation("Draft");

                    b.Navigation("Profile");
                });

            modelBuilder.Entity("MagicNight.Models.Database.Drafts.Values.DraftPackCard", b =>
                {
                    b.HasOne("MagicNight.Models.Database.Cards.Card", "Card")
                        .WithMany()
                        .HasForeignKey("CardName");

                    b.HasOne("MagicNight.Models.Database.Drafts.DraftPack", "Pack")
                        .WithMany("Cards")
                        .HasForeignKey("PackId");

                    b.HasOne("MagicNight.Models.Database.Profiles.Profile", "Profile")
                        .WithMany()
                        .HasForeignKey("ProfileName");

                    b.Navigation("Card");

                    b.Navigation("Pack");

                    b.Navigation("Profile");
                });

            modelBuilder.Entity("MagicNight.Models.Database.Drafts.Values.DraftProfile", b =>
                {
                    b.HasOne("MagicNight.Models.Database.Drafts.Draft", "Draft")
                        .WithMany("Profiles")
                        .HasForeignKey("DraftId");

                    b.HasOne("MagicNight.Models.Database.Profiles.Profile", "Next")
                        .WithMany()
                        .HasForeignKey("NextName");

                    b.HasOne("MagicNight.Models.Database.Profiles.Profile", "Previous")
                        .WithMany()
                        .HasForeignKey("PreviousName");

                    b.HasOne("MagicNight.Models.Database.Profiles.Profile", "Profile")
                        .WithMany()
                        .HasForeignKey("ProfileName");

                    b.Navigation("Draft");

                    b.Navigation("Next");

                    b.Navigation("Previous");

                    b.Navigation("Profile");
                });

            modelBuilder.Entity("MagicNight.Models.Database.Rolls.Values.CommanderRollEntry", b =>
                {
                    b.HasOne("MagicNight.Models.Database.Cards.Card", "Commander")
                        .WithMany()
                        .HasForeignKey("CommanderName");

                    b.HasOne("MagicNight.Models.Database.Rolls.CommanderRoll", null)
                        .WithMany("Entries")
                        .HasForeignKey("CommanderRollId");

                    b.HasOne("MagicNight.Models.Database.Cards.Card", "Partner")
                        .WithMany()
                        .HasForeignKey("PartnerName");

                    b.HasOne("MagicNight.Models.Database.Profiles.Profile", "Profile")
                        .WithMany()
                        .HasForeignKey("ProfileName");

                    b.Navigation("Commander");

                    b.Navigation("Partner");

                    b.Navigation("Profile");
                });

            modelBuilder.Entity("MagicNight.Models.Database.Rolls.Values.SetRollEntry", b =>
                {
                    b.HasOne("MagicNight.Models.Database.Decks.Deck", "Deck")
                        .WithMany()
                        .HasForeignKey("DeckId");

                    b.HasOne("MagicNight.Models.Database.Profiles.Profile", "Profile")
                        .WithMany()
                        .HasForeignKey("ProfileName");

                    b.HasOne("MagicNight.Models.Database.Sets.Set", "Set")
                        .WithMany()
                        .HasForeignKey("SetCode");

                    b.HasOne("MagicNight.Models.Database.Rolls.SetRoll", "SetRoll")
                        .WithMany("Entries")
                        .HasForeignKey("SetRollId");

                    b.Navigation("Deck");

                    b.Navigation("Profile");

                    b.Navigation("Set");

                    b.Navigation("SetRoll");
                });

            modelBuilder.Entity("MagicNight.Models.Database.Sets.SetSettings", b =>
                {
                    b.HasOne("MagicNight.Models.Database.Sets.Set", "Set")
                        .WithOne("Settings")
                        .HasForeignKey("MagicNight.Models.Database.Sets.SetSettings", "Code")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Set");
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

            modelBuilder.Entity("MagicNight.Models.Database.Tournaments.Values.TournamentParticipant", b =>
                {
                    b.HasOne("MagicNight.Models.Database.Profiles.Profile", "Profile")
                        .WithMany()
                        .HasForeignKey("ProfileName");

                    b.HasOne("MagicNight.Models.Database.Tournaments.Tournament", "Tournament")
                        .WithMany("Participants")
                        .HasForeignKey("TournamentId");

                    b.Navigation("Profile");

                    b.Navigation("Tournament");
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

            modelBuilder.Entity("MagicNight.Models.Database.Drafts.Draft", b =>
                {
                    b.Navigation("Packs");

                    b.Navigation("Profiles");
                });

            modelBuilder.Entity("MagicNight.Models.Database.Drafts.DraftPack", b =>
                {
                    b.Navigation("Cards");
                });

            modelBuilder.Entity("MagicNight.Models.Database.Rolls.CommanderRoll", b =>
                {
                    b.Navigation("Entries");
                });

            modelBuilder.Entity("MagicNight.Models.Database.Rolls.SetRoll", b =>
                {
                    b.Navigation("Entries");
                });

            modelBuilder.Entity("MagicNight.Models.Database.Sets.Set", b =>
                {
                    b.Navigation("Settings");
                });

            modelBuilder.Entity("MagicNight.Models.Database.Tournaments.Group", b =>
                {
                    b.Navigation("Entries");

                    b.Navigation("Matches");
                });

            modelBuilder.Entity("MagicNight.Models.Database.Tournaments.Tournament", b =>
                {
                    b.Navigation("Participants");
                });
#pragma warning restore 612, 618
        }
    }
}
