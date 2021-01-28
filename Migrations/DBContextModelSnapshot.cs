﻿// <auto-generated />
using System;
using Bug_Tracker_Backend.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Bug_Tracker_Backend.Migrations
{
    [DbContext(typeof(DBContext))]
    partial class DBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("ApplicationDeveloper", b =>
                {
                    b.Property<int>("ApplicationsApplicationID")
                        .HasColumnType("int");

                    b.Property<int>("DevelopersDeveloperID")
                        .HasColumnType("int");

                    b.HasKey("ApplicationsApplicationID", "DevelopersDeveloperID");

                    b.HasIndex("DevelopersDeveloperID");

                    b.ToTable("ApplicationDeveloper");
                });

            modelBuilder.Entity("Bug_Tracker_Backend.Application", b =>
                {
                    b.Property<int>("ApplicationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ApplicationName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ApplicationID");

                    b.ToTable("Applications");
                });

            modelBuilder.Entity("Bug_Tracker_Backend.Model.Developer", b =>
                {
                    b.Property<int>("DeveloperID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("DeveloperEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeveloperFirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeveloperLastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeveloperPhone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DeveloperID");

                    b.ToTable("Developers");
                });

            modelBuilder.Entity("Bug_Tracker_Backend.Ticket", b =>
                {
                    b.Property<int>("TicketID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("ApplicationID")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateDue")
                        .HasColumnType("datetime2");

                    b.Property<int>("DeveloperID")
                        .HasColumnType("int");

                    b.Property<string>("Severity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TicketDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TicketName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TicketID");

                    b.HasIndex("ApplicationID");

                    b.HasIndex("DeveloperID");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("ApplicationDeveloper", b =>
                {
                    b.HasOne("Bug_Tracker_Backend.Application", null)
                        .WithMany()
                        .HasForeignKey("ApplicationsApplicationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bug_Tracker_Backend.Model.Developer", null)
                        .WithMany()
                        .HasForeignKey("DevelopersDeveloperID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Bug_Tracker_Backend.Ticket", b =>
                {
                    b.HasOne("Bug_Tracker_Backend.Application", "Application")
                        .WithMany("Tickets")
                        .HasForeignKey("ApplicationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bug_Tracker_Backend.Model.Developer", "Developer")
                        .WithMany("Tickets")
                        .HasForeignKey("DeveloperID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Application");

                    b.Navigation("Developer");
                });

            modelBuilder.Entity("Bug_Tracker_Backend.Application", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("Bug_Tracker_Backend.Model.Developer", b =>
                {
                    b.Navigation("Tickets");
                });
#pragma warning restore 612, 618
        }
    }
}
