using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using webimblaze_check.Models;

namespace webimblaze_check.Migrations
{
    [DbContext(typeof(webinjectcheckContext))]
    [Migration("20170321195415_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("webimblaze_check.Models.Recipe", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("Cuisine");

                    b.Property<string>("Name");

                    b.Property<decimal>("Serves");

                    b.Property<bool>("Vegetarian");

                    b.HasKey("ID");

                    b.ToTable("Recipe");
                });
        }
    }
}
