﻿// <auto-generated />
using System;
using EFDomain.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EFDomain.Migrations
{
    [DbContext(typeof(SampleContext))]
    [Migration("20181018100059_AddedInquiryAndRelation")]
    partial class AddedInquiryAndRelation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EFDomain.Data.Inquiry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("InquiryString")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Inquiry");
                });

            modelBuilder.Entity("EFDomain.Data.Value", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<int?>("InquiryId");

                    b.HasKey("Id");

                    b.HasIndex("InquiryId");

                    b.ToTable("Entities");
                });

            modelBuilder.Entity("EFDomain.Data.Value", b =>
                {
                    b.HasOne("EFDomain.Data.Inquiry", "Inquiry")
                        .WithMany()
                        .HasForeignKey("InquiryId");
                });
#pragma warning restore 612, 618
        }
    }
}
