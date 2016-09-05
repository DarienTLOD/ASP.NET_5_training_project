using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using TrainingProject.Models;

namespace TrainingProject.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20160516095023_Mig22")]
    partial class Mig22
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("Relational:DefaultSchema", "dbo")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TrainingProject.Models.ApplicationUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("TrainingProject.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int>("StateId");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("TrainingProject.Models.State", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("TrainingProject.Models.City", b =>
                {
                    b.HasOne("TrainingProject.Models.State")
                        .WithMany()
                        .HasForeignKey("StateId");
                });
        }
    }
}
