﻿// <auto-generated />
using FinanceAPI.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FinanceAPI.Migrations
{
    [DbContext(typeof(FinanceDbContext))]
    partial class FinanceDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CompanyWatchlist", b =>
                {
                    b.Property<int>("CompaniesCompanyId")
                        .HasColumnType("int");

                    b.Property<int>("WatchlistsWatchlistId")
                        .HasColumnType("int");

                    b.HasKey("CompaniesCompanyId", "WatchlistsWatchlistId");

                    b.HasIndex("WatchlistsWatchlistId");

                    b.ToTable("WatchlistCompanies", (string)null);
                });

            modelBuilder.Entity("FinanceAPI.DAL.Company", b =>
                {
                    b.Property<int>("CompanyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CompanyId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TickerSymbol")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CompanyId");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("FinanceAPI.DAL.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("FinanceAPI.DAL.Watchlist", b =>
                {
                    b.Property<int>("WatchlistId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WatchlistId"));

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("WatchlistId");

                    b.HasIndex("UserId");

                    b.ToTable("Watchlists");
                });

            modelBuilder.Entity("CompanyWatchlist", b =>
                {
                    b.HasOne("FinanceAPI.DAL.Company", null)
                        .WithMany()
                        .HasForeignKey("CompaniesCompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FinanceAPI.DAL.Watchlist", null)
                        .WithMany()
                        .HasForeignKey("WatchlistsWatchlistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FinanceAPI.DAL.Watchlist", b =>
                {
                    b.HasOne("FinanceAPI.DAL.User", "User")
                        .WithMany("Watchlists")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("FinanceAPI.DAL.User", b =>
                {
                    b.Navigation("Watchlists");
                });
#pragma warning restore 612, 618
        }
    }
}
