// <auto-generated />
using System;
using Library.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Library.Migrations
{
    [DbContext(typeof(LibraryContext))]
    partial class LibraryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Library.Models.Book", b =>
                {
                    b.Property<int?>("book_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("book_id"));

                    b.Property<string>("author")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("available")
                        .HasColumnType("int");

                    b.Property<string>("book_desc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("book_description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("book_title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("cover")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("pages")
                        .HasColumnType("int");

                    b.Property<string>("publisher")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("book_id");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("Library.Models.User", b =>
                {
                    b.Property<int?>("user_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("user_id"));

                    b.Property<string>("account")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("date_create")
                        .HasColumnType("datetime2");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("last_login")
                        .HasColumnType("datetime2");

                    b.Property<string>("password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("user_id");

                    b.ToTable("User");
                });
#pragma warning restore 612, 618
        }
    }
}
