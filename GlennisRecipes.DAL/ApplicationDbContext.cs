using GlennisRecipes.Model.Entities;
using GlennisRecipes.Model.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlennisRecipes.DAL
{
    public class ApplicationDbContext: IdentityDbContext<User>
    {
        public override DbSet<User> Users { get; set; }
        public DbSet<IdentityRole> IdentityRoles { get; set; }
        public DbSet<IdentityUserRole<string>> IdentityUserRoles { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<UserComment> UserComments { get; set; }
        public DbSet<UserRating> UserRatings { get; set; }

        //public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        //{

        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB; Database=GlennisRecipes; Integrated Security=True; Connect Timeout=180");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.NoAction;
            }

            SeedData(builder);
        }

        private void SeedData(ModelBuilder builder)
        {
            #region Creating Entities
            var passwordHasher = new PasswordHasher<IdentityUser>();

            var chefJoeUser = new User
            {
                Id = "a8b93270-4150-4411-a54b-6521de4a49aa",
                Email = "chefjoe@mail.com",
                NormalizedEmail = "chefjoe@mail.com",
                UserName = "Chef Joe",
                NormalizedUserName = "Chef Joe",
            };
            chefJoeUser.PasswordHash = passwordHasher.HashPassword(chefJoeUser, "Password1$");

            var bakerPeterUser = new User
            {
                Id = "81139b48-6c24-4fc8-ad72-6c1423608d83",
                Email = "bakerpeter@mail.com",
                NormalizedEmail = "bakerpeter@mail.com",
                UserName = "Baker Peter",
                NormalizedUserName = "Baker Peter",
            };
            bakerPeterUser.PasswordHash = passwordHasher.HashPassword(bakerPeterUser, "Password1$");

            var jakeUser = new User
            {
                Id = "b295bea7-efc3-42a7-8e26-ea3fd5c99ec6",
                Email = "jake@mail.com",
                NormalizedEmail = "jake@mail.com",
                UserName = "Jake",
                NormalizedUserName = "Jake",
            };
            jakeUser.PasswordHash = passwordHasher.HashPassword(jakeUser, "Password1$");

            var jillUser = new User
            {
                Id = "7a0f0fc8-de75-4231-bca4-f02595b8fc22",
                Email = "jill@mail.com",
                NormalizedEmail = "jill@mail.com",
                UserName = "Jill",
                NormalizedUserName = "Jill",
            };
            jillUser.PasswordHash = passwordHasher.HashPassword(jillUser, "Password1$");

            var redVelvetCake = new Recipe
            {
                Id = "20bf6a09-4f7f-45c0-80df-defdfb494656",
                Name = "Red Velvet Cake",
                Instructions = "This is how you can create a Red Velvet Cake",
                OwnerId = chefJoeUser.Id,
                ImagePath = "RedVelvetCake202303142234211747.png",
            };

            var chocolateCake = new Recipe
            {
                Id = "0fccd974-5b7e-4157-887d-87ce146756e1",
                Name = "Chocolate Cake",
                Instructions = "This is how you can create a Chocolate Cake",
                OwnerId = chefJoeUser.Id,
                ImagePath = "ChocolateCake202303142235021967.png",
            };

            var lemonSpongeCake = new Recipe
            {
                Id = "604f5685-08d4-40a0-94a1-63f309bb07e7",
                Name = "Lemon Sponge Cake",
                Instructions = "This is how you can create a Lemon Sponge Cake",
                OwnerId = bakerPeterUser.Id,
                ImagePath = "LemonSpongeCake202303142234497511.png",
            };

            var jakeRating1 = new UserRating
            {
                Id = "d9a6be63-0c3a-4feb-9cda-eae06d2b3509",
                Rating = RatingEnum.Five,
                RecipeId = redVelvetCake.Id,
                UserId = jakeUser.Id
            };

            var jakeRating2 = new UserRating
            {
                Id = "611b0a25-1fd0-46d8-a534-10e986150ba1",
                Rating = RatingEnum.Five,
                RecipeId = chocolateCake.Id,
                UserId = jakeUser.Id
            };

            var jakeRating3 = new UserRating
            {
                Id = "d95b7961-a1b1-4ab4-9e80-465f6516d453",
                Rating = RatingEnum.Five,
                RecipeId = lemonSpongeCake.Id,
                UserId = jakeUser.Id
            };

            var jillRating1 = new UserRating
            {
                Id = "66e453c5-d55b-47be-9773-5d9aa8ea8aaa",
                Rating = RatingEnum.Three,
                RecipeId = redVelvetCake.Id,
                UserId = jillUser.Id
            };

            var jillRating2 = new UserRating
            {
                Id = "c23d966b-9e78-4b8a-9e9d-c50be6d0b9a5",
                Rating = RatingEnum.Three,
                RecipeId = chocolateCake.Id,
                UserId = jillUser.Id
            };

            var jakeComment1 = new UserComment
            {
                Id = "6d721ff4-8c3e-4d01-9ae9-a80310ecd988",
                Comment = "This cake was amazing !!!!!",
                RecipeId = redVelvetCake.Id,
                UserId = jakeUser.Id,
                TimeStamp = DateTime.Parse("3/15/2023 10:37:50 PM"),
        };

            var normalRole = new IdentityRole
            {
                Id = "4fe86bb9-bf7e-46ec-a5b9-b29d38929611",
                Name = "Normal",
                NormalizedName = "Normal",
            };
            #endregion

            #region Seeding Entities

            builder.Entity<IdentityRole>()
                .HasData(new IdentityRole[]
                {
                    normalRole
                });

            builder.Entity<User>()
                .HasData(new User[]
                {
                    chefJoeUser,
                    bakerPeterUser,
                    jakeUser,
                    jillUser,
                });

            builder.Entity<IdentityUserRole<string>>()
                .HasData(new IdentityUserRole<string>[]
                {
                    new IdentityUserRole<string>
                    {
                        RoleId = normalRole.Id,
                        UserId = chefJoeUser.Id,
                    },
                    new IdentityUserRole<string>
                    {
                        RoleId = normalRole.Id,
                        UserId = bakerPeterUser.Id,
                    },
                    new IdentityUserRole<string>
                    {
                        RoleId = normalRole.Id,
                        UserId = jakeUser.Id,
                    },
                    new IdentityUserRole<string>
                    {
                        RoleId = normalRole.Id,
                        UserId = jillUser.Id,
                    },
                });

            builder.Entity<Recipe>()
                .HasData(new Recipe[]
                {
                    redVelvetCake,
                    chocolateCake,
                    lemonSpongeCake
                });

            builder.Entity<UserComment>()
                .HasData(new UserComment[]
                {
                    jakeComment1
                });

            builder.Entity<UserRating>()
                .HasData(new UserRating[]
                {
                    jakeRating1,
                    jakeRating2,
                    jakeRating3,
                    jillRating1,
                    jillRating2,
                });

            #endregion
        }
    }
}
