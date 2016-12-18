using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using OdeToFood.Entities;

namespace OdeToFood.Migrations
{
    [DbContext(typeof(OdeToFoodDbContext))]
    [Migration("20161124172316_v4")]
    partial class v4
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OdeToFood.Entities.Diagnosis", b =>
                {
                    b.Property<int>("DiagnosisId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code");

                    b.Property<int?>("DiagnosisId1");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsDiag");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("DiagnosisId");

                    b.HasIndex("DiagnosisId1");

                    b.ToTable("Diagnoses");
                });

            modelBuilder.Entity("OdeToFood.Entities.Restaurant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Cuisine");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 80);

                    b.HasKey("Id");

                    b.ToTable("Restaurants");
                });

            modelBuilder.Entity("OdeToFood.Entities.Diagnosis", b =>
                {
                    b.HasOne("OdeToFood.Entities.Diagnosis")
                        .WithMany("Diagnoses")
                        .HasForeignKey("DiagnosisId1");
                });
        }
    }
}
