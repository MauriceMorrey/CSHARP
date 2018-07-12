﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using RESTauranter.Models;
using System;

namespace RESTauranter.Migrations
{
    [DbContext(typeof(ReviewsContext))]
    [Migration("20180511010337_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125");

            modelBuilder.Entity("RESTauranter.Models.RegisterViewModels", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateOfVisit");

                    b.Property<string>("RestaurantName")
                        .IsRequired();

                    b.Property<string>("Review")
                        .IsRequired();

                    b.Property<string>("ReviewerName")
                        .IsRequired();

                    b.Property<int>("Stars");

                    b.HasKey("id");

                    b.ToTable("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}
