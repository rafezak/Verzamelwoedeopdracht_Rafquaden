﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VerzamelingFinished;

#nullable disable

namespace VerzamelingFinished.Migrations
{
    [DbContext(typeof(DBcontext))]
    [Migration("20240919113639_addd")]
    partial class addd
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0-rc.1.24451.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("VerzamelingFinished.Models.Card", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DeckId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Element")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DeckId");

                    b.ToTable("cards");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DeckId = 0,
                            Description = "An electric-type Pokémon",
                            Element = "Electric",
                            Name = "Pikachu",
                            Price = 10,
                            Quantity = 1
                        });
                });

            modelBuilder.Entity("VerzamelingFinished.Models.Deck", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("decks");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "A deck full of electric-type Pokémon",
                            Image = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.pinterest.com%2Fpin%2Felectric-energy-card-vector-symbol-by-biochao-on-deviantart--635852041162050260%2F&psig=AOvVaw1VhoMWHjxJd-1TAgrQrnv9&ust=1726831793197000&source=images&cd=vfe&opi=89978449&ved=0CBQQjRxqFwoTCICN3vLzzogDFQAAAAAdAAAAABAJ",
                            Name = "Electric Deck"
                        });
                });

            modelBuilder.Entity("VerzamelingFinished.Models.Card", b =>
                {
                    b.HasOne("VerzamelingFinished.Models.Deck", "Deck")
                        .WithMany("Cards")
                        .HasForeignKey("DeckId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Deck");
                });

            modelBuilder.Entity("VerzamelingFinished.Models.Deck", b =>
                {
                    b.Navigation("Cards");
                });
#pragma warning restore 612, 618
        }
    }
}
