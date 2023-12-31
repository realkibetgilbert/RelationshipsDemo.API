﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RelationshipsDemo.API.Infrastructure.Data;

#nullable disable

namespace RelationshipsDemo.API.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RelationshipsDemo.API.Core.Models.Author", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("PublisherId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("RelationshipsDemo.API.Core.Models.Book", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("AuthorId")
                        .HasColumnType("bigint");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("RelationshipsDemo.API.Core.Models.BookPublisher", b =>
                {
                    b.Property<long>("PublisherId")
                        .HasColumnType("bigint");

                    b.Property<long>("BookId")
                        .HasColumnType("bigint");

                    b.HasKey("PublisherId", "BookId");

                    b.HasIndex("BookId");

                    b.ToTable("BookPublishers");
                });

            modelBuilder.Entity("RelationshipsDemo.API.Core.Models.Publisher", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("AuthorId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId")
                        .IsUnique();

                    b.ToTable("Publishers");
                });

            modelBuilder.Entity("RelationshipsDemo.API.Core.Models.Book", b =>
                {
                    b.HasOne("RelationshipsDemo.API.Core.Models.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("RelationshipsDemo.API.Core.Models.BookPublisher", b =>
                {
                    b.HasOne("RelationshipsDemo.API.Core.Models.Book", "Book")
                        .WithMany("BookPublishers")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("RelationshipsDemo.API.Core.Models.Publisher", "Publisher")
                        .WithMany("BookPublishers")
                        .HasForeignKey("PublisherId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Publisher");
                });

            modelBuilder.Entity("RelationshipsDemo.API.Core.Models.Publisher", b =>
                {
                    b.HasOne("RelationshipsDemo.API.Core.Models.Author", "Author")
                        .WithOne("Publisher")
                        .HasForeignKey("RelationshipsDemo.API.Core.Models.Publisher", "AuthorId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("RelationshipsDemo.API.Core.Models.Author", b =>
                {
                    b.Navigation("Books");

                    b.Navigation("Publisher")
                        .IsRequired();
                });

            modelBuilder.Entity("RelationshipsDemo.API.Core.Models.Book", b =>
                {
                    b.Navigation("BookPublishers");
                });

            modelBuilder.Entity("RelationshipsDemo.API.Core.Models.Publisher", b =>
                {
                    b.Navigation("BookPublishers");
                });
#pragma warning restore 612, 618
        }
    }
}
