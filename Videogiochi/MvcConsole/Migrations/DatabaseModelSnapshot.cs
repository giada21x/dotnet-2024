﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MvcConsole.Migrations
{
    [DbContext(typeof(Database))]
    partial class DatabaseModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.2");

            modelBuilder.Entity("Genere", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Genere");
                });

            modelBuilder.Entity("Utente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Cognome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Eta")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Utenti");
                });

            modelBuilder.Entity("Videogioco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Anno")
                        .HasColumnType("INTEGER");

                    b.Property<int>("GenereId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Titolo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Voto")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("GenereId");

                    b.ToTable("Videogiochi");
                });

            modelBuilder.Entity("Videogioco", b =>
                {
                    b.HasOne("Genere", "Genere")
                        .WithMany()
                        .HasForeignKey("GenereId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genere");
                });
#pragma warning restore 612, 618
        }
    }
}
