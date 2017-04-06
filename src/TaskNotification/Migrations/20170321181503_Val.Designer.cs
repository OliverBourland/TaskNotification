using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using TaskNotification.Repositories;

namespace TaskNotification.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20170321181503_Val")]
    partial class Val
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TaskNotification.Models.Customer", b =>
                {
                    b.Property<int>("CustomerID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("Company");

                    b.Property<string>("ContactName");

                    b.Property<string>("Email");

                    b.Property<string>("PhoneNumber");

                    b.HasKey("CustomerID");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("TaskNotification.Models.Order", b =>
                {
                    b.Property<int>("OrderID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreationDate");

                    b.Property<int?>("CustomerID");

                    b.Property<DateTime>("DueDate");

                    b.Property<string>("Title");

                    b.HasKey("OrderID");

                    b.HasIndex("CustomerID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("TaskNotification.Models.TaskNotify", b =>
                {
                    b.Property<int>("TaskNotifyID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 600);

                    b.Property<int?>("CompletedByUserID");

                    b.Property<DateTime>("CompletionDate");

                    b.Property<DateTime>("CreationDate");

                    b.Property<DateTime>("DueDate");

                    b.Property<int?>("OrderID");

                    b.Property<int?>("PostedByUserID");

                    b.Property<bool>("TaskCompleted");

                    b.Property<int?>("TaskForUserID");

                    b.Property<bool>("TaskViewed");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("TaskNotifyID");

                    b.HasIndex("CompletedByUserID");

                    b.HasIndex("OrderID");

                    b.HasIndex("PostedByUserID");

                    b.HasIndex("TaskForUserID");

                    b.ToTable("TaskNotifies");
                });

            modelBuilder.Entity("TaskNotification.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.Property<int?>("TaskNotifyID");

                    b.HasKey("UserID");

                    b.HasIndex("TaskNotifyID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TaskNotification.Models.Order", b =>
                {
                    b.HasOne("TaskNotification.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerID");
                });

            modelBuilder.Entity("TaskNotification.Models.TaskNotify", b =>
                {
                    b.HasOne("TaskNotification.Models.User", "CompletedBy")
                        .WithMany()
                        .HasForeignKey("CompletedByUserID");

                    b.HasOne("TaskNotification.Models.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderID");

                    b.HasOne("TaskNotification.Models.User", "PostedBy")
                        .WithMany()
                        .HasForeignKey("PostedByUserID");

                    b.HasOne("TaskNotification.Models.User", "TaskFor")
                        .WithMany()
                        .HasForeignKey("TaskForUserID");
                });

            modelBuilder.Entity("TaskNotification.Models.User", b =>
                {
                    b.HasOne("TaskNotification.Models.TaskNotify")
                        .WithMany("ViewedBy")
                        .HasForeignKey("TaskNotifyID");
                });
        }
    }
}
