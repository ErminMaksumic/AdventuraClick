﻿// <auto-generated />
using System;
using AdventuraClick.Service.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AdventuraClick.Service.Migrations
{
    [DbContext(typeof(AdventuraClickInitContext))]
    partial class AdventuraClickContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AdventuraClick.Service.Database.AdditionalService", b =>
                {
                    b.Property<int>("AddServiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("addServiceId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AddServiceId"));

                    b.Property<string>("Name")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)")
                        .HasColumnName("name");

                    b.Property<float>("Price")
                        .HasColumnType("real")
                        .HasColumnName("price");

                    b.HasKey("AddServiceId")
                        .HasName("PK_9");

                    b.ToTable("AdditionalService", (string)null);
                });

            modelBuilder.Entity("AdventuraClick.Service.Database.AdditionalServiceReservation", b =>
                {
                    b.Property<int>("AdditionalServiceReservationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AdditionalServiceReservationId"));

                    b.Property<int>("AdditionalServiceId")
                        .HasColumnType("int");

                    b.Property<int>("ReservationId")
                        .HasColumnType("int");

                    b.Property<int?>("TravelId")
                        .HasColumnType("int");

                    b.HasKey("AdditionalServiceReservationId");

                    b.HasIndex("AdditionalServiceId");

                    b.HasIndex("ReservationId");

                    b.HasIndex("TravelId");

                    b.ToTable("AdditionalServiceReservations");
                });

            modelBuilder.Entity("AdventuraClick.Service.Database.IncludedItem", b =>
                {
                    b.Property<int>("IncludedItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IncludedItemId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IncludedItemId");

                    b.ToTable("IncludedItem");
                });

            modelBuilder.Entity("AdventuraClick.Service.Database.IncludedItemTravel", b =>
                {
                    b.Property<int>("IncludedItemTravelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IncludedItemTravelId"));

                    b.Property<int?>("IncludedItemId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("TravelId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("IncludedItemTravelId");

                    b.HasIndex("IncludedItemId");

                    b.HasIndex("TravelId");

                    b.ToTable("IncludedItemTravels");
                });

            modelBuilder.Entity("AdventuraClick.Service.Database.Location", b =>
                {
                    b.Property<int>("LocationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("locationId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LocationId"));

                    b.Property<string>("CityName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CountryName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LocationId")
                        .HasName("PK_7");

                    b.ToTable("Location", (string)null);
                });

            modelBuilder.Entity("AdventuraClick.Service.Database.Payment", b =>
                {
                    b.Property<int>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("paymentId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PaymentId"));

                    b.Property<float>("Amount")
                        .HasColumnType("real")
                        .HasColumnName("amount");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime")
                        .HasColumnName("date");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TransactionNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TravelId")
                        .HasColumnType("int")
                        .HasColumnName("travelId");

                    b.HasKey("PaymentId")
                        .HasName("PK_6");

                    b.HasIndex("TravelId");

                    b.ToTable("Payment", (string)null);
                });

            modelBuilder.Entity("AdventuraClick.Service.Database.Rating", b =>
                {
                    b.Property<int>("RatingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ratingId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RatingId"));

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rate")
                        .HasColumnType("int");

                    b.Property<int?>("TravelId")
                        .HasColumnType("int")
                        .HasColumnName("travelId");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("RatingId")
                        .HasName("PK_3");

                    b.HasIndex("TravelId");

                    b.HasIndex("UserId");

                    b.ToTable("Rating", (string)null);
                });

            modelBuilder.Entity("AdventuraClick.Service.Database.Reservation", b =>
                {
                    b.Property<int>("ReservationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("reservationId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReservationId"));

                    b.Property<int?>("AdditionalServiceAddServiceId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasMaxLength(40)
                        .HasColumnType("datetime2")
                        .HasColumnName("date");

                    b.Property<int>("NumberOfPassengers")
                        .HasColumnType("int");

                    b.Property<int?>("PaymentId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("status");

                    b.Property<int?>("TravelId")
                        .HasColumnType("int")
                        .HasColumnName("travelId");

                    b.Property<int?>("TravelInformationId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ReservationId")
                        .HasName("PK_4");

                    b.HasIndex("AdditionalServiceAddServiceId");

                    b.HasIndex("PaymentId");

                    b.HasIndex("TravelId");

                    b.HasIndex("TravelInformationId");

                    b.HasIndex("UserId");

                    b.ToTable("Reservation", (string)null);
                });

            modelBuilder.Entity("AdventuraClick.Service.Database.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("roleId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)")
                        .HasColumnName("name");

                    b.HasKey("RoleId")
                        .HasName("PK_2");

                    b.ToTable("Role", (string)null);
                });

            modelBuilder.Entity("AdventuraClick.Service.Database.Travel", b =>
                {
                    b.Property<int>("TravelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("travelId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TravelId"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("description");

                    b.Property<byte[]>("Image")
                        .IsRequired()
                        .HasColumnType("varbinary(max)")
                        .HasColumnName("image");

                    b.Property<int?>("LocationId")
                        .HasColumnType("int")
                        .HasColumnName("locationId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)")
                        .HasColumnName("name");

                    b.Property<int>("NumberOfNights")
                        .HasColumnType("int");

                    b.Property<float>("Price")
                        .HasColumnType("real")
                        .HasColumnName("price");

                    b.Property<string>("Status")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)")
                        .HasColumnName("status");

                    b.Property<int?>("TravelTypeId")
                        .HasColumnType("int")
                        .HasColumnName("travelTypeId");

                    b.HasKey("TravelId")
                        .HasName("PK_5");

                    b.HasIndex("LocationId");

                    b.HasIndex("TravelTypeId");

                    b.ToTable("Travel", (string)null);
                });

            modelBuilder.Entity("AdventuraClick.Service.Database.TravelInformation", b =>
                {
                    b.Property<int>("TravelInformationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TravelInformationId"));

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DepartureTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("TravelId")
                        .HasColumnType("int");

                    b.HasKey("TravelInformationId");

                    b.HasIndex("TravelId");

                    b.ToTable("TravelInformations");
                });

            modelBuilder.Entity("AdventuraClick.Service.Database.TravelType", b =>
                {
                    b.Property<int>("TravelTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("travelTypeId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TravelTypeId"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)")
                        .HasColumnName("name");

                    b.HasKey("TravelTypeId")
                        .HasName("PK_8");

                    b.ToTable("TravelType", (string)null);
                });

            modelBuilder.Entity("AdventuraClick.Service.Database.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("userId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("CreatedAt")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)")
                        .HasColumnName("createdAt");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)")
                        .HasColumnName("firstName");

                    b.Property<byte[]>("Image")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)")
                        .HasColumnName("lastName");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("passwordHash");

                    b.Property<string>("PasswordSalt")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("passwordSalt");

                    b.Property<int?>("RoleId")
                        .HasColumnType("int")
                        .HasColumnName("roleId");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)")
                        .HasColumnName("username");

                    b.HasKey("UserId")
                        .HasName("PK_1");

                    b.HasIndex("RoleId");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("AdventuraClick.Service.Database.AdditionalServiceReservation", b =>
                {
                    b.HasOne("AdventuraClick.Service.Database.AdditionalService", "AdditionalService")
                        .WithMany()
                        .HasForeignKey("AdditionalServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AdventuraClick.Service.Database.Reservation", "Reservation")
                        .WithMany("AdditionalServicesReservations")
                        .HasForeignKey("ReservationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AdventuraClick.Service.Database.Travel", null)
                        .WithMany("AdditionalServicesReservations")
                        .HasForeignKey("TravelId");

                    b.Navigation("AdditionalService");

                    b.Navigation("Reservation");
                });

            modelBuilder.Entity("AdventuraClick.Service.Database.IncludedItemTravel", b =>
                {
                    b.HasOne("AdventuraClick.Service.Database.IncludedItem", "IncludedItem")
                        .WithMany("IncludedItemTravels")
                        .HasForeignKey("IncludedItemId")
                        .IsRequired()
                        .HasConstraintName("FK_REFERENCE_26");

                    b.HasOne("AdventuraClick.Service.Database.Travel", "Travel")
                        .WithMany("IncludedItemTravels")
                        .HasForeignKey("TravelId")
                        .IsRequired()
                        .HasConstraintName("FK_REFERENCE_25");

                    b.Navigation("IncludedItem");

                    b.Navigation("Travel");
                });

            modelBuilder.Entity("AdventuraClick.Service.Database.Payment", b =>
                {
                    b.HasOne("AdventuraClick.Service.Database.Travel", "Travel")
                        .WithMany("Payments")
                        .HasForeignKey("TravelId")
                        .HasConstraintName("FK_REFERENCE_5");

                    b.Navigation("Travel");
                });

            modelBuilder.Entity("AdventuraClick.Service.Database.Rating", b =>
                {
                    b.HasOne("AdventuraClick.Service.Database.Travel", "Travel")
                        .WithMany("Ratings")
                        .HasForeignKey("TravelId")
                        .HasConstraintName("FK_REFERENCE_2");

                    b.HasOne("AdventuraClick.Service.Database.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Travel");

                    b.Navigation("User");
                });

            modelBuilder.Entity("AdventuraClick.Service.Database.Reservation", b =>
                {
                    b.HasOne("AdventuraClick.Service.Database.AdditionalService", null)
                        .WithMany("Reservations")
                        .HasForeignKey("AdditionalServiceAddServiceId");

                    b.HasOne("AdventuraClick.Service.Database.Payment", "Payment")
                        .WithMany("Reservations")
                        .HasForeignKey("PaymentId");

                    b.HasOne("AdventuraClick.Service.Database.Travel", "Travel")
                        .WithMany()
                        .HasForeignKey("TravelId");

                    b.HasOne("AdventuraClick.Service.Database.TravelInformation", "TravelInformation")
                        .WithMany()
                        .HasForeignKey("TravelInformationId");

                    b.HasOne("AdventuraClick.Service.Database.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Payment");

                    b.Navigation("Travel");

                    b.Navigation("TravelInformation");

                    b.Navigation("User");
                });

            modelBuilder.Entity("AdventuraClick.Service.Database.Travel", b =>
                {
                    b.HasOne("AdventuraClick.Service.Database.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId");

                    b.HasOne("AdventuraClick.Service.Database.TravelType", "TravelType")
                        .WithMany("Travels")
                        .HasForeignKey("TravelTypeId")
                        .HasConstraintName("FK_REFERENCE_3");

                    b.Navigation("Location");

                    b.Navigation("TravelType");
                });

            modelBuilder.Entity("AdventuraClick.Service.Database.TravelInformation", b =>
                {
                    b.HasOne("AdventuraClick.Service.Database.Travel", "Travel")
                        .WithMany("TravelInformations")
                        .HasForeignKey("TravelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Travel");
                });

            modelBuilder.Entity("AdventuraClick.Service.Database.User", b =>
                {
                    b.HasOne("AdventuraClick.Service.Database.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .HasConstraintName("FK_REFERENCE_1");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("AdventuraClick.Service.Database.AdditionalService", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("AdventuraClick.Service.Database.IncludedItem", b =>
                {
                    b.Navigation("IncludedItemTravels");
                });

            modelBuilder.Entity("AdventuraClick.Service.Database.Payment", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("AdventuraClick.Service.Database.Reservation", b =>
                {
                    b.Navigation("AdditionalServicesReservations");
                });

            modelBuilder.Entity("AdventuraClick.Service.Database.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("AdventuraClick.Service.Database.Travel", b =>
                {
                    b.Navigation("AdditionalServicesReservations");

                    b.Navigation("IncludedItemTravels");

                    b.Navigation("Payments");

                    b.Navigation("Ratings");

                    b.Navigation("TravelInformations");
                });

            modelBuilder.Entity("AdventuraClick.Service.Database.TravelType", b =>
                {
                    b.Navigation("Travels");
                });
#pragma warning restore 612, 618
        }
    }
}
