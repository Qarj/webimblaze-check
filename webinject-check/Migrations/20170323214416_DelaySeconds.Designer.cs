using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using webinject_check.Models;

namespace webinject_check.Migrations
{
    [DbContext(typeof(webinjectcheckContext))]
    [Migration("20170323214416_DelaySeconds")]
    partial class DelaySeconds
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("webinject_check.Models.Recipe", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("Cuisine")
                        .IsRequired()
                        .HasMaxLength(24);

                    b.Property<int>("DelaySeconds");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.Property<decimal>("Serves");

                    b.Property<bool>("Vegetarian");

                    b.HasKey("ID");

                    b.ToTable("Recipe");
                });
        }
    }
}
