﻿// <auto-generated />
using System;
using GlennisRecipes.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GlennisRecipes.DAL.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GlennisRecipes.Model.Entities.Recipe", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Instructions")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OwnerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Recipes");

                    b.HasData(
                        new
                        {
                            Id = "20bf6a09-4f7f-45c0-80df-defdfb494656",
                            ImagePath = "RedVelvetCake202303142234211747.png",
                            Instructions = "This is how you can create a Red Velvet Cake",
                            Name = "Red Velvet Cake",
                            OwnerId = "a8b93270-4150-4411-a54b-6521de4a49aa"
                        },
                        new
                        {
                            Id = "0fccd974-5b7e-4157-887d-87ce146756e1",
                            ImagePath = "ChocolateCake202303142235021967.png",
                            Instructions = "This is how you can create a Chocolate Cake",
                            Name = "Chocolate Cake",
                            OwnerId = "a8b93270-4150-4411-a54b-6521de4a49aa"
                        },
                        new
                        {
                            Id = "604f5685-08d4-40a0-94a1-63f309bb07e7",
                            ImagePath = "LemonSpongeCake202303142234497511.png",
                            Instructions = "This is how you can create a Lemon Sponge Cake",
                            Name = "Lemon Sponge Cake",
                            OwnerId = "81139b48-6c24-4fc8-ad72-6c1423608d83"
                        });
                });

            modelBuilder.Entity("GlennisRecipes.Model.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "a8b93270-4150-4411-a54b-6521de4a49aa",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "f00decd4-c379-45b4-b767-a8684baa22fa",
                            Email = "chefjoe@mail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "chefjoe@mail.com",
                            NormalizedUserName = "Chef Joe",
                            PasswordHash = "AQAAAAEAACcQAAAAENQcSjJm5l8f5fyDPqk579BTmHHuOpPTwwmeEjfwRLyns6gshONfnF4R2YjMDCcV/Q==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "ddd6afd7-8eab-4cd2-87c9-2020586a3753",
                            TwoFactorEnabled = false,
                            UserName = "Chef Joe"
                        },
                        new
                        {
                            Id = "81139b48-6c24-4fc8-ad72-6c1423608d83",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "3360c207-67a1-47c9-834f-d116a57a7b44",
                            Email = "bakerpeter@mail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "bakerpeter@mail.com",
                            NormalizedUserName = "Baker Peter",
                            PasswordHash = "AQAAAAEAACcQAAAAEB0mPll/84h3Z1EAZeD14OjzUVtI0Mx+EUx35Yz3UYdTJer2a1z2xK5uoou/QptNPw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "9d8f4d73-705f-496d-a804-2c0334fd15f9",
                            TwoFactorEnabled = false,
                            UserName = "Baker Peter"
                        },
                        new
                        {
                            Id = "b295bea7-efc3-42a7-8e26-ea3fd5c99ec6",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "006d3d4d-425c-4aa7-80fe-044cbc1ccd47",
                            Email = "jake@mail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "jake@mail.com",
                            NormalizedUserName = "Jake",
                            PasswordHash = "AQAAAAEAACcQAAAAEMZFovJ8EqI6EOcRZ6JEC/8IZTj0mM36euclwuTw2VNxLZUUgwFpldL2nUuH539dRw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "12bf7e55-f527-4c05-9c92-7c2e8dbbd98a",
                            TwoFactorEnabled = false,
                            UserName = "Jake"
                        },
                        new
                        {
                            Id = "7a0f0fc8-de75-4231-bca4-f02595b8fc22",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "f0c13a7c-7ee3-44be-8480-812407c86ace",
                            Email = "jill@mail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "jill@mail.com",
                            NormalizedUserName = "Jill",
                            PasswordHash = "AQAAAAEAACcQAAAAEBXjZGn1q2pxtESReNiNgliUSfKsTFzN0ItgeHbHhWFNdVswgBBe0iXTSnzckfG5hA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "f7e1adb6-969a-4dc2-8d5c-33c59d53238e",
                            TwoFactorEnabled = false,
                            UserName = "Jill"
                        });
                });

            modelBuilder.Entity("GlennisRecipes.Model.Entities.UserComment", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RecipeId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RecipeId");

                    b.HasIndex("UserId");

                    b.ToTable("UserComments");

                    b.HasData(
                        new
                        {
                            Id = "6d721ff4-8c3e-4d01-9ae9-a80310ecd988",
                            Comment = "This cake was amazing !!!!!",
                            RecipeId = "20bf6a09-4f7f-45c0-80df-defdfb494656",
                            UserId = "b295bea7-efc3-42a7-8e26-ea3fd5c99ec6"
                        });
                });

            modelBuilder.Entity("GlennisRecipes.Model.Entities.UserRating", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<string>("RecipeId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RecipeId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRatings");

                    b.HasData(
                        new
                        {
                            Id = "d9a6be63-0c3a-4feb-9cda-eae06d2b3509",
                            Rating = 5,
                            RecipeId = "20bf6a09-4f7f-45c0-80df-defdfb494656",
                            UserId = "b295bea7-efc3-42a7-8e26-ea3fd5c99ec6"
                        },
                        new
                        {
                            Id = "611b0a25-1fd0-46d8-a534-10e986150ba1",
                            Rating = 5,
                            RecipeId = "0fccd974-5b7e-4157-887d-87ce146756e1",
                            UserId = "b295bea7-efc3-42a7-8e26-ea3fd5c99ec6"
                        },
                        new
                        {
                            Id = "d95b7961-a1b1-4ab4-9e80-465f6516d453",
                            Rating = 5,
                            RecipeId = "604f5685-08d4-40a0-94a1-63f309bb07e7",
                            UserId = "b295bea7-efc3-42a7-8e26-ea3fd5c99ec6"
                        },
                        new
                        {
                            Id = "66e453c5-d55b-47be-9773-5d9aa8ea8aaa",
                            Rating = 3,
                            RecipeId = "20bf6a09-4f7f-45c0-80df-defdfb494656",
                            UserId = "7a0f0fc8-de75-4231-bca4-f02595b8fc22"
                        },
                        new
                        {
                            Id = "c23d966b-9e78-4b8a-9e9d-c50be6d0b9a5",
                            Rating = 3,
                            RecipeId = "0fccd974-5b7e-4157-887d-87ce146756e1",
                            UserId = "7a0f0fc8-de75-4231-bca4-f02595b8fc22"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "4fe86bb9-bf7e-46ec-a5b9-b29d38929611",
                            ConcurrencyStamp = "968d9eb4-b2e3-49d7-87bf-ffa3fe3264c9",
                            Name = "Normal",
                            NormalizedName = "Normal"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "a8b93270-4150-4411-a54b-6521de4a49aa",
                            RoleId = "4fe86bb9-bf7e-46ec-a5b9-b29d38929611"
                        },
                        new
                        {
                            UserId = "81139b48-6c24-4fc8-ad72-6c1423608d83",
                            RoleId = "4fe86bb9-bf7e-46ec-a5b9-b29d38929611"
                        },
                        new
                        {
                            UserId = "b295bea7-efc3-42a7-8e26-ea3fd5c99ec6",
                            RoleId = "4fe86bb9-bf7e-46ec-a5b9-b29d38929611"
                        },
                        new
                        {
                            UserId = "7a0f0fc8-de75-4231-bca4-f02595b8fc22",
                            RoleId = "4fe86bb9-bf7e-46ec-a5b9-b29d38929611"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("GlennisRecipes.Model.Entities.Recipe", b =>
                {
                    b.HasOne("GlennisRecipes.Model.Entities.User", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("GlennisRecipes.Model.Entities.UserComment", b =>
                {
                    b.HasOne("GlennisRecipes.Model.Entities.Recipe", "Recipe")
                        .WithMany("UserComments")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("GlennisRecipes.Model.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Recipe");

                    b.Navigation("User");
                });

            modelBuilder.Entity("GlennisRecipes.Model.Entities.UserRating", b =>
                {
                    b.HasOne("GlennisRecipes.Model.Entities.Recipe", "Recipe")
                        .WithMany("UserRatings")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("GlennisRecipes.Model.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Recipe");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("GlennisRecipes.Model.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("GlennisRecipes.Model.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("GlennisRecipes.Model.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("GlennisRecipes.Model.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("GlennisRecipes.Model.Entities.Recipe", b =>
                {
                    b.Navigation("UserComments");

                    b.Navigation("UserRatings");
                });
#pragma warning restore 612, 618
        }
    }
}
