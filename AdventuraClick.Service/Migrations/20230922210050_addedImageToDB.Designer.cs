﻿// <auto-generated />
using System;
using AdventuraClick.Service.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AdventuraClick.Service.Migrations
{
    [DbContext(typeof(AdventuraClickInitContext))]
    [Migration("20230922210050_addedImageToDB")]
    partial class addedImageToDB
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

            modelBuilder.Entity("AdventuraClick.Service.Database.Location", b =>
                {
                    b.Property<int>("LocationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("locationId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LocationId"));

                    b.Property<string>("Name")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)")
                        .HasColumnName("name");

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

                    b.HasKey("RatingId")
                        .HasName("PK_3");

                    b.HasIndex("TravelId");

                    b.ToTable("Rating", (string)null);
                });

            modelBuilder.Entity("AdventuraClick.Service.Database.Reservation", b =>
                {
                    b.Property<int>("ReservationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("reservationId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReservationId"));

                    b.Property<string>("Date")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)")
                        .HasColumnName("date");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("note");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("status");

                    b.Property<int?>("TravelId")
                        .HasColumnType("int")
                        .HasColumnName("travelId");

                    b.HasKey("ReservationId")
                        .HasName("PK_4");

                    b.HasIndex("TravelId");

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

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime")
                        .HasColumnName("date");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("description");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("image");

                    b.Property<int?>("LocationId")
                        .HasColumnType("int")
                        .HasColumnName("locationId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)")
                        .HasColumnName("name");

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

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime")
                        .HasColumnName("dateOfBirth");

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

            modelBuilder.Entity("TravelAddService", b =>
                {
                    b.Property<int>("TravelId")
                        .HasColumnType("int")
                        .HasColumnName("travelId");

                    b.Property<int>("AddServiceId")
                        .HasColumnType("int")
                        .HasColumnName("addServiceId");

                    b.HasKey("TravelId", "AddServiceId")
                        .HasName("PK_11");

                    b.HasIndex("AddServiceId");

                    b.ToTable("TravelAddService", (string)null);
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

                    b.Navigation("Travel");
                });

            modelBuilder.Entity("AdventuraClick.Service.Database.Reservation", b =>
                {
                    b.HasOne("AdventuraClick.Service.Database.Travel", "Travel")
                        .WithMany("Reservations")
                        .HasForeignKey("TravelId")
                        .HasConstraintName("FK_REFERENCE_8");

                    b.Navigation("Travel");
                });

            modelBuilder.Entity("AdventuraClick.Service.Database.Travel", b =>
                {
                    b.HasOne("AdventuraClick.Service.Database.Location", "Location")
                        .WithMany("Travels")
                        .HasForeignKey("LocationId")
                        .HasConstraintName("FK_REFERENCE_4");

                    b.HasOne("AdventuraClick.Service.Database.TravelType", "TravelType")
                        .WithMany("Travels")
                        .HasForeignKey("TravelTypeId")
                        .HasConstraintName("FK_REFERENCE_3");

                    b.Navigation("Location");

                    b.Navigation("TravelType");
                });

            modelBuilder.Entity("AdventuraClick.Service.Database.User", b =>
                {
                    b.HasOne("AdventuraClick.Service.Database.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .HasConstraintName("FK_REFERENCE_1");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("TravelAddService", b =>
                {
                    b.HasOne("AdventuraClick.Service.Database.AdditionalService", null)
                        .WithMany()
                        .HasForeignKey("AddServiceId")
                        .IsRequired()
                        .HasConstraintName("FK_REFERENCE_7");

                    b.HasOne("AdventuraClick.Service.Database.Travel", null)
                        .WithMany()
                        .HasForeignKey("TravelId")
                        .IsRequired()
                        .HasConstraintName("FK_REFERENCE_6");
                });

            modelBuilder.Entity("AdventuraClick.Service.Database.Location", b =>
                {
                    b.Navigation("Travels");
                });

            modelBuilder.Entity("AdventuraClick.Service.Database.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("AdventuraClick.Service.Database.Travel", b =>
                {
                    b.Navigation("Payments");

                    b.Navigation("Ratings");

                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("AdventuraClick.Service.Database.TravelType", b =>
                {
                    b.Navigation("Travels");
                });
#pragma warning restore 612, 618
        }
    }
}
