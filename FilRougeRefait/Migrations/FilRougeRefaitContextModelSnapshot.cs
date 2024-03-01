﻿// <auto-generated />
using System;
using CoVoyageur.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CoVoyageur.API.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class FilRougeRefaitContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CoVoyageur.Core.Models.Feedback", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Comment");

                    b.Property<DateTime>("DateHour")
                        .HasColumnType("datetime2")
                        .HasColumnName("DateHour");

                    b.Property<int>("ID_Driver")
                        .HasColumnType("int")
                        .HasColumnName("Id_Driver");

                    b.Property<int>("ID_Passenger")
                        .HasColumnType("int")
                        .HasColumnName("Id_Passenger");

                    b.Property<int>("Rating")
                        .HasColumnType("int")
                        .HasColumnName("Rating");

                    b.Property<int?>("UserID")
                        .HasColumnType("int");

                    b.Property<int?>("UserID1")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ID_Driver");

                    b.HasIndex("ID_Passenger");

                    b.HasIndex("UserID");

                    b.HasIndex("UserID1");

                    b.ToTable("Feedback");
                });

            modelBuilder.Entity("CoVoyageur.Core.Models.Reservation", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("ID_Passenger")
                        .HasColumnType("int")
                        .HasColumnName("Id_Passenger");

                    b.Property<int>("ID_Ride")
                        .HasColumnType("int")
                        .HasColumnName("Id_Ride");

                    b.Property<int?>("PassengerID")
                        .HasColumnType("int");

                    b.Property<int?>("Statuts")
                        .HasColumnType("int")
                        .HasColumnName("Statuts");

                    b.Property<int?>("TravelID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("PassengerID");

                    b.HasIndex("TravelID");

                    b.ToTable("Reservation");
                });

            modelBuilder.Entity("CoVoyageur.Core.Models.Ride", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Arrival")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Arrival");

                    b.Property<DateTime>("DateHour")
                        .HasColumnType("datetime2")
                        .HasColumnName("DateHour");

                    b.Property<string>("Departure")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Departure");

                    b.Property<int?>("DriverID")
                        .HasColumnType("int");

                    b.Property<int>("ID_Driver")
                        .HasColumnType("int")
                        .HasColumnName("Id_Rider");

                    b.Property<int>("NbPlaces")
                        .HasColumnType("int")
                        .HasColumnName("NbPlaces");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("Price");

                    b.HasKey("ID");

                    b.HasIndex("DriverID");

                    b.ToTable("Ride");
                });

            modelBuilder.Entity("CoVoyageur.Core.Models.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("BirthDate");

                    b.Property<bool>("DrivingLicense")
                        .HasColumnType("bit")
                        .HasColumnName("DrivingLicence");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Email");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Firstname");

                    b.Property<DateTime>("InscriptionDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("InscriptionDate");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit")
                        .HasColumnName("IsAdmin");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("LastName");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Password");

                    b.HasKey("ID");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            BirthDate = new DateTime(2024, 3, 1, 10, 57, 43, 587, DateTimeKind.Local).AddTicks(298),
                            DrivingLicense = true,
                            Email = "test1@test.com",
                            FirstName = "Leo",
                            InscriptionDate = new DateTime(2024, 3, 1, 10, 57, 43, 585, DateTimeKind.Local).AddTicks(1460),
                            IsAdmin = true,
                            LastName = "Dorat",
                            Password = "Sup4Str0ngP455W0RD!!1"
                        },
                        new
                        {
                            ID = 2,
                            BirthDate = new DateTime(2024, 3, 1, 10, 57, 43, 587, DateTimeKind.Local).AddTicks(1708),
                            DrivingLicense = true,
                            Email = "test2@test.com",
                            FirstName = "Lea",
                            InscriptionDate = new DateTime(2024, 3, 1, 10, 57, 43, 587, DateTimeKind.Local).AddTicks(1696),
                            IsAdmin = false,
                            LastName = "Naconda",
                            Password = "Sup4Str0ngP455W0RD!!2"
                        },
                        new
                        {
                            ID = 3,
                            BirthDate = new DateTime(2024, 3, 1, 10, 57, 43, 587, DateTimeKind.Local).AddTicks(1714),
                            DrivingLicense = true,
                            Email = "test3@test.com",
                            FirstName = "Leon",
                            InscriptionDate = new DateTime(2024, 3, 1, 10, 57, 43, 587, DateTimeKind.Local).AddTicks(1712),
                            IsAdmin = false,
                            LastName = "Sendort",
                            Password = "Sup4Str0ngP455W0RD!!3"
                        });
                });

            modelBuilder.Entity("CoVoyageur.Core.Models.Feedback", b =>
                {
                    b.HasOne("CoVoyageur.Core.Models.User", "Driver")
                        .WithMany()
                        .HasForeignKey("ID_Driver")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CoVoyageur.Core.Models.User", "Author")
                        .WithMany()
                        .HasForeignKey("ID_Passenger")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CoVoyageur.Core.Models.User", null)
                        .WithMany("FeedbacksDrivers")
                        .HasForeignKey("UserID");

                    b.HasOne("CoVoyageur.Core.Models.User", null)
                        .WithMany("FeedbacksPassengers")
                        .HasForeignKey("UserID1");

                    b.Navigation("Author");

                    b.Navigation("Driver");
                });

            modelBuilder.Entity("CoVoyageur.Core.Models.Reservation", b =>
                {
                    b.HasOne("CoVoyageur.Core.Models.User", "Passenger")
                        .WithMany("Reservations")
                        .HasForeignKey("PassengerID");

                    b.HasOne("CoVoyageur.Core.Models.Ride", "Travel")
                        .WithMany("Reservations")
                        .HasForeignKey("TravelID");

                    b.Navigation("Passenger");

                    b.Navigation("Travel");
                });

            modelBuilder.Entity("CoVoyageur.Core.Models.Ride", b =>
                {
                    b.HasOne("CoVoyageur.Core.Models.User", "Driver")
                        .WithMany("Rides")
                        .HasForeignKey("DriverID");

                    b.Navigation("Driver");
                });

            modelBuilder.Entity("CoVoyageur.Core.Models.Ride", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("CoVoyageur.Core.Models.User", b =>
                {
                    b.Navigation("FeedbacksDrivers");

                    b.Navigation("FeedbacksPassengers");

                    b.Navigation("Reservations");

                    b.Navigation("Rides");
                });
#pragma warning restore 612, 618
        }
    }
}
