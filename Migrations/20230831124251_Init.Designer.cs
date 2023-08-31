﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Writely.Models;

#nullable disable

namespace Writely.Migrations
{
    [DbContext(typeof(WritelyContext))]
    [Migration("20230831124251_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Writely.Models.Notebook", b =>
                {
                    b.Property<int>("NotebookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NotebookId"), 1L, 1);

                    b.Property<string>("NotebookName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NotebookId");

                    b.ToTable("Notebooks");
                });

            modelBuilder.Entity("Writely.Models.NotebooksMenu", b =>
                {
                    b.Property<int>("NotebooksMenuId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NotebooksMenuId"), 1L, 1);

                    b.HasKey("NotebooksMenuId");

                    b.ToTable("NotebooksMenus");
                });
#pragma warning restore 612, 618
        }
    }
}
