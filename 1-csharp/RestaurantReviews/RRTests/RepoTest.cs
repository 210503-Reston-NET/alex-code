using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Net.Http.Headers;
using System.Xml;
using System;
using System.Reflection.Metadata;
namespace RRTests
{
    
        /// <summary>
        /// Test class for data access methods in my repo
        /// </summary>
        public class RepoTest
        {
            private readonly DBContextOptions<Entity.RestaurantDBContext> options;
            public RepoTest(){
                options = new DBContextOptions<Entity.RestaurantDBContext>()
                .UseSqlLite("Filename=Test.DB");
            }
            //xunit creates new instances of test unit classes, so you need to make sure that your db seeded for each class
            private void Seed(){
                //example using block
                using (var context = new Entity.RestaurantDBContext(options)){
                    //Makes sure state of rb gets recreated everytime for modularity
                    context.Database.EnsureDeleted();
                    context.Database.EnsureCreated();
                    context.Restaurant.AddRange
                    (
                        new Entity.Restaurant
                        {
                            Id = 1,
                            Name = "Good Taste",
                            City = "Baguio City",
                            State = "Benguet",
                            Reviews = new List<Entity.Reviews>()
                            {
                                new Entity.Review{
                                    Id = 1,
                                    Rating = 5,
                                    Description = "good"
                                },
                                new Entity.Review{
                                    Id = 2,
                                    Rating = 4,
                                    Description = "coffee could be better"
                                }
                            }
                        }
                    );
                }
            }
        }
}