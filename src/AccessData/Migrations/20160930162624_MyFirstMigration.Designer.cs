using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using AccessData.Entity;

namespace AccessData.Migrations
{
    [DbContext(typeof(Contexte))]
    [Migration("20160930162624_MyFirstMigration")]
    partial class MyFirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1");

            modelBuilder.Entity("AccessData.Entity.Blog", b =>
                {
                    b.Property<int>("IdBlog")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nom");

                    b.Property<string>("Url");

                    b.HasKey("IdBlog");

                    b.ToTable("Blogs");
                });

            modelBuilder.Entity("AccessData.Entity.Post", b =>
                {
                    b.Property<int>("IdPoste")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content");

                    b.Property<int>("IdBlog");

                    b.Property<string>("Titre");

                    b.HasKey("IdPoste");

                    b.HasIndex("IdBlog");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("AccessData.Entity.Post", b =>
                {
                    b.HasOne("AccessData.Entity.Blog", "Blog")
                        .WithMany("Postes")
                        .HasForeignKey("IdBlog")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
