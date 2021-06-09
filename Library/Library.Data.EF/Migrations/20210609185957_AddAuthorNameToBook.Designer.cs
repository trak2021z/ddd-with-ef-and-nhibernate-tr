﻿// <auto-generated />
using System;
using Library.Data.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Library.Data.EF.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210609185957_AddAuthorNameToBook")]
    partial class AddAuthorNameToBook
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Library.Data.EF.Model.Book", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("Library.Data.EF.Model.Borrowing", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("BookId")
                        .HasColumnType("bigint");

                    b.Property<long?>("CurrentBorrowerId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("CurrentBorrowerId");

                    b.ToTable("Borrowings");
                });

            modelBuilder.Entity("Library.Data.EF.Model.Member", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("FavoriteBookId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("FavoriteBookId");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("Library.Data.EF.Model.Suffix", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Suffix");
                });

            modelBuilder.Entity("Library.Data.EF.Model.Book", b =>
                {
                    b.OwnsOne("Library.Data.EF.Model.Name", "AuthorName", b1 =>
                        {
                            b1.Property<long>("BookId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("bigint")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("First")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("FirstName");

                            b1.Property<string>("Last")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("LastName");

                            b1.Property<long?>("NameSuffixId")
                                .HasColumnType("bigint")
                                .HasColumnName("NameSuffixId");

                            b1.HasKey("BookId");

                            b1.HasIndex("NameSuffixId");

                            b1.ToTable("Books");

                            b1.WithOwner()
                                .HasForeignKey("BookId");

                            b1.HasOne("Library.Data.EF.Model.Suffix", "Suffix")
                                .WithMany()
                                .HasForeignKey("NameSuffixId");

                            b1.Navigation("Suffix");
                        });

                    b.Navigation("AuthorName");
                });

            modelBuilder.Entity("Library.Data.EF.Model.Borrowing", b =>
                {
                    b.HasOne("Library.Data.EF.Model.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId");

                    b.HasOne("Library.Data.EF.Model.Member", "CurrentBorrower")
                        .WithMany("Borrowings")
                        .HasForeignKey("CurrentBorrowerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Book");

                    b.Navigation("CurrentBorrower");
                });

            modelBuilder.Entity("Library.Data.EF.Model.Member", b =>
                {
                    b.HasOne("Library.Data.EF.Model.Book", "FavoriteBook")
                        .WithMany()
                        .HasForeignKey("FavoriteBookId");

                    b.OwnsOne("Library.Data.EF.Model.Name", "Name", b1 =>
                        {
                            b1.Property<long>("MemberId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("bigint")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("First")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("FirstName");

                            b1.Property<string>("Last")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("LastName");

                            b1.Property<long?>("NameSuffixId")
                                .HasColumnType("bigint")
                                .HasColumnName("NameSuffixId");

                            b1.HasKey("MemberId");

                            b1.HasIndex("NameSuffixId");

                            b1.ToTable("Members");

                            b1.WithOwner()
                                .HasForeignKey("MemberId");

                            b1.HasOne("Library.Data.EF.Model.Suffix", "Suffix")
                                .WithMany()
                                .HasForeignKey("NameSuffixId");

                            b1.Navigation("Suffix");
                        });

                    b.Navigation("FavoriteBook");

                    b.Navigation("Name");
                });

            modelBuilder.Entity("Library.Data.EF.Model.Member", b =>
                {
                    b.Navigation("Borrowings");
                });
#pragma warning restore 612, 618
        }
    }
}