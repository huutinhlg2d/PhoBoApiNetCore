// <auto-generated />
using System;
using BussinessObject.PhoBo.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BussinessObject.Migrations
{
    [DbContext(typeof(PhoBoContext))]
    partial class PhoBoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BussinessObject.PhoBo.Models.Booking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BookingDate")
                        .HasColumnType("datetime2");

                    b.Property<float>("BookingRate")
                        .HasColumnType("real");

                    b.Property<int>("ConceptId")
                        .HasColumnType("int");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<float>("Duration")
                        .HasColumnType("real");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PhotographerId")
                        .HasColumnType("int");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ConceptId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("PhotographerId");

                    b.ToTable("Booking");
                });

            modelBuilder.Entity("BussinessObject.PhoBo.Models.BookingConceptConfig", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ConceptId")
                        .HasColumnType("int");

                    b.Property<string>("DurationConfig")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PhotographerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ConceptId");

                    b.HasIndex("PhotographerId");

                    b.ToTable("BookingConceptConfig");
                });

            modelBuilder.Entity("BussinessObject.PhoBo.Models.BookingConceptImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ConfigId")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ConfigId");

                    b.ToTable("BookingConceptImage");
                });

            modelBuilder.Entity("BussinessObject.PhoBo.Models.Concept", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Concept");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsDeleted = false,
                            Name = "Marriage"
                        },
                        new
                        {
                            Id = 2,
                            IsDeleted = false,
                            Name = "Graduation"
                        },
                        new
                        {
                            Id = 3,
                            IsDeleted = false,
                            Name = "Anniversary"
                        },
                        new
                        {
                            Id = 4,
                            IsDeleted = false,
                            Name = "Birthday"
                        },
                        new
                        {
                            Id = 5,
                            IsDeleted = false,
                            Name = "Travel"
                        });
                });

            modelBuilder.Entity("BussinessObject.PhoBo.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AvatarUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateOfBirth = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "admin@phobo.com",
                            Gender = 0,
                            IsDeleted = false,
                            Name = "Admin",
                            Password = "admin@@",
                            Role = 0
                        });
                });

            modelBuilder.Entity("BussinessObject.PhoBo.Models.Customer", b =>
                {
                    b.HasBaseType("BussinessObject.PhoBo.Models.User");

                    b.ToTable("Customer");

                    b.HasData(
                        new
                        {
                            Id = 4,
                            AvatarUrl = "Resource/Images/uyentrang.jpg",
                            DateOfBirth = new DateTime(2001, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "uyentrang@phobo.com",
                            Gender = 0,
                            IsDeleted = false,
                            Name = "Trương Thị Uyên Trang",
                            Password = "123123",
                            Role = 1
                        },
                        new
                        {
                            Id = 5,
                            AvatarUrl = "Resource/Images/quockhanh.jpg",
                            DateOfBirth = new DateTime(2001, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "quockhanh@phobo.com",
                            Gender = 0,
                            IsDeleted = false,
                            Name = "Trần Quốc Khánh",
                            Password = "123123",
                            Role = 1
                        });
                });

            modelBuilder.Entity("BussinessObject.PhoBo.Models.Photographer", b =>
                {
                    b.HasBaseType("BussinessObject.PhoBo.Models.User");

                    b.Property<float>("Rate")
                        .HasColumnType("real");

                    b.ToTable("Photographer");

                    b.HasData(
                        new
                        {
                            Id = 2,
                            AvatarUrl = "Resource/Images/huutinh.jpg",
                            DateOfBirth = new DateTime(2001, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "huutinh@phobo.com",
                            Gender = 0,
                            IsDeleted = false,
                            Name = "Hồ Hữu Tình",
                            Password = "123123",
                            Role = 2,
                            Rate = 0f
                        },
                        new
                        {
                            Id = 3,
                            AvatarUrl = "Resource/Images/tanhoang.jpg",
                            DateOfBirth = new DateTime(1999, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "tanhoang@phobo.com",
                            Gender = 0,
                            IsDeleted = false,
                            Name = "Phạm Tấn Hoàng",
                            Password = "123123",
                            Role = 2,
                            Rate = 0f
                        });
                });

            modelBuilder.Entity("BussinessObject.PhoBo.Models.Booking", b =>
                {
                    b.HasOne("BussinessObject.PhoBo.Models.Concept", "Concept")
                        .WithMany()
                        .HasForeignKey("ConceptId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BussinessObject.PhoBo.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BussinessObject.PhoBo.Models.Photographer", "Photographer")
                        .WithMany("PhotographerBookings")
                        .HasForeignKey("PhotographerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Concept");

                    b.Navigation("Customer");

                    b.Navigation("Photographer");
                });

            modelBuilder.Entity("BussinessObject.PhoBo.Models.BookingConceptConfig", b =>
                {
                    b.HasOne("BussinessObject.PhoBo.Models.Concept", "Concept")
                        .WithMany()
                        .HasForeignKey("ConceptId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BussinessObject.PhoBo.Models.Photographer", "Photographer")
                        .WithMany("BookingConceptConfigs")
                        .HasForeignKey("PhotographerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Concept");

                    b.Navigation("Photographer");
                });

            modelBuilder.Entity("BussinessObject.PhoBo.Models.BookingConceptImage", b =>
                {
                    b.HasOne("BussinessObject.PhoBo.Models.BookingConceptConfig", "Config")
                        .WithMany()
                        .HasForeignKey("ConfigId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Config");
                });

            modelBuilder.Entity("BussinessObject.PhoBo.Models.Customer", b =>
                {
                    b.HasOne("BussinessObject.PhoBo.Models.User", null)
                        .WithOne()
                        .HasForeignKey("BussinessObject.PhoBo.Models.Customer", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BussinessObject.PhoBo.Models.Photographer", b =>
                {
                    b.HasOne("BussinessObject.PhoBo.Models.User", null)
                        .WithOne()
                        .HasForeignKey("BussinessObject.PhoBo.Models.Photographer", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BussinessObject.PhoBo.Models.Photographer", b =>
                {
                    b.Navigation("BookingConceptConfigs");

                    b.Navigation("PhotographerBookings");
                });
#pragma warning restore 612, 618
        }
    }
}
