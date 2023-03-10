// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SignalR.Models;

namespace SignalR.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20230113073055_DbInitializationWithSeed2")]
    partial class DbInitializationWithSeed2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.32")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SignalR.Models.MarketTrends", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Expenses")
                        .HasColumnType("int");

                    b.Property<int>("Income")
                        .HasColumnType("int");

                    b.Property<int>("WeekDays")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("MarketTrends");
                });

            modelBuilder.Entity("SignalR.Models.Room", b =>
                {
                    b.Property<int>("RoomID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RoomName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoomID");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("SignalR.Models.Statistic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BuyedCourseIncreaseRate")
                        .HasColumnType("int");

                    b.Property<int>("BuyedCourses")
                        .HasColumnType("int");

                    b.Property<int>("NewUsers")
                        .HasColumnType("int");

                    b.Property<int>("PageViewsCount")
                        .HasColumnType("int");

                    b.Property<int>("TotalDislikes")
                        .HasColumnType("int");

                    b.Property<int>("TotalLikes")
                        .HasColumnType("int");

                    b.Property<int>("UsersCount")
                        .HasColumnType("int");

                    b.Property<int>("UsersIncreaseRate")
                        .HasColumnType("int");

                    b.Property<int>("ViewsCount")
                        .HasColumnType("int");

                    b.Property<DateTime>("dateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Statistics");
                });

            modelBuilder.Entity("SignalR.Models.Traffic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EmailMarketing")
                        .HasColumnType("int");

                    b.Property<int>("GoogleSearch")
                        .HasColumnType("int");

                    b.Property<int>("Referrals")
                        .HasColumnType("int");

                    b.Property<int>("SocialMedia")
                        .HasColumnType("int");

                    b.Property<DateTime>("dateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Traffics");
                });

            modelBuilder.Entity("SignalR.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RoomID")
                        .HasColumnType("int");

                    b.HasKey("UserID");

                    b.HasIndex("RoomID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SignalR.Models.User", b =>
                {
                    b.HasOne("SignalR.Models.Room", "Room")
                        .WithMany("Users")
                        .HasForeignKey("RoomID");
                });
#pragma warning restore 612, 618
        }
    }
}
