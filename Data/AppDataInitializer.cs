﻿//using eTickets.Data.Enums;
//using eTickets.Models;

//namespace eTickets.Data
//{
//    public class AppDataInitializer
//    {
//        public static void Seed(IApplicationBuilder applicationBuilder)
//        {
//            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
//            {
//                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
//                context.Database.EnsureCreated();



//                //Cinema
//                if (!context.Cinemas.Any())
//                {
//                    context.Cinemas.AddRange(new List<Cinema>()
//                   {
//                        new Cinema()
//                        {
//                            Name = "Cinema 1",
//                            Logo = "http://dotnethow.net/images/cinemas/cinema-1.jpeg",
//                            Description = "This is the description of the first cinema"

//                        },
//                         new Cinema()
//                         {
//                             Name = "Cinema 2",
//                             Logo = "http://dotnethow.net/images/cinemas/cinema-2.jpeg",
//                             Description = "This is the description of the second cinema"

//                         },
//                          new Cinema()
//                          {
//                              Name = "Cinema 3",
//                              Logo = "http://dotnethow.net/images/cinemas/cinema-3.jpeg",
//                              Description = "This is the description of the third cinema"

//                          },
//                          new Cinema()
//                          {
//                              Name = "Cinema 4",
//                              Logo = "http://dotnethow.net/images/cinemas/cinema-4.jpeg",
//                              Description = "This is the description of the forth cinema"

//                          },
//                          new Cinema()
//                          {
//                              Name = "Cinema 5",
//                              Logo = "http://dotnethow.net/images/cinemas/cinema-5.jpeg" ,
//                              Description = "This is the description of the fifth cinema"

//                          },



//                   });

//                    context.SaveChanges();

//                }
//                //Actor
//                if (!context.Actors.Any())
//                {
//                    context.Actors.AddRange(new List<Actor>()
//                   {
//                        new Actor()
//                        {
//                            FullName = "Actor 1",
//                            Bio = "This is the bio for first actor",
//                            ProfilePictureUrl = "http://dotnethow.net/images/actors/actor-1.jpeg"

//                        },
//                         new Actor()
//                        {
//                            FullName = "Actor 2",
//                            Bio = "This is the bio for second actor",
//                            ProfilePictureUrl = "http://dotnethow.net/images/actors/actor-2.jpeg"

//                        },
//                          new Actor()
//                        {
//                            FullName = "Actor 3",
//                            Bio = "This is the bio for third actor",
//                            ProfilePictureUrl= "http://dotnethow.net/images/actors/actor-3.jpeg"

//                        },
//                         new Actor()
//                        {
//                            FullName = "Actor 4",
//                            Bio = "This is the bio for forth actor",
//                            ProfilePictureUrl = "http://dotnethow.net/images/actors/actor-4.jpeg"

//                        },
//                          new Actor()
//                        {
//                            FullName = "Actor 5",
//                            Bio = "This is the bio for fifth actor",
//                            ProfilePictureUrl = "http://dotnethow.net/images/actors/actor-5.jpeg"

//                        },

//                   });
//                    context.SaveChanges();

//                }
//                //Producer
//                if (!context.Producers.Any())
//                {
//                    context.Producers.AddRange(new List<Producer>()
//                   {
//                        new Producer()
//                        {
//                            FullName = "Producer 1",
//                            Bio = "This is the bio for first Producer",
//                            ProfilePictureUrl = "http://dotnethow.net/images/producers/producer-1.jpeg"

//                        },
//                         new Producer()
//                        {
//                            FullName = "Producer 2",
//                            Bio = "This is the bio for second Producer",
//                            ProfilePictureUrl = "http://dotnethow.net/images/producers/producer-2.jpeg"

//                        },
//                          new Producer()
//                        {
//                            FullName = "Producer 3",
//                            Bio = "This is the bio for third Producer",
//                            ProfilePictureUrl = "http://dotnethow.net/images/producers/producer-3.jpeg"

//                        },
//                         new Producer()
//                        {
//                            FullName = "Producer 4",
//                            Bio = "This is the bio for forth Producer",
//                            ProfilePictureUrl = "http://dotnethow.net/images/producers/producer-4.jpeg"

//                        },
//                          new Producer()
//                        {
//                            FullName = "Producer 5",
//                            Bio = "This is the bio for fifth Producer",
//                            ProfilePictureUrl = "http://dotnethow.net/images/producers/producer-5.jpeg"

//                        },

//                   });
//                    context.SaveChanges();

//                }
//                //Movies
//                if (!context.Movies.Any())
//                {
//                    context.Movies.AddRange(new List<Movie>()
//                   {
//                        new Movie()
//                        {
//                            Name = "Life",
//                            Description = "This is a life movie description",
//                            Price = 750,
//                            ImageUrl = "http://dotnethow.net/images/movies/movie-1.jpeg",
//                            StartDate = DateTime.Now.AddDays(-10),
//                            EndDate = DateTime.Now.AddDays(10),
//                            CinemaId = 2,
//                            ProducerId = 2,
                            
//                        },
//                         new Movie()
//                        {
//                            Name = "Scoop",
//                            Description = "This is the Scoop movie description",
//                            Price = 650,
//                            ImageUrl = "http://dotnethow.net/images/movies/movie-2.jpeg",
//                            StartDate = DateTime.Now.AddDays(-10),
//                            EndDate = DateTime.Now.AddDays(10),
//                            CinemaId = 3,
//                            ProducerId = 3,
                            
//                        },

//                           new Movie()
//                        {
//                            Name = "Ghost",
//                            Description = "This is the ghost movie description",
//                            Price = 850,
//                            ImageUrl = "http://dotnethow.net/images/movies/movie-3.jpeg",
//                            StartDate = DateTime.Now.AddDays(-10),
//                            EndDate = DateTime.Now.AddDays(10),
//                            CinemaId = 4,
//                            ProducerId = 4,
                            
//                        },



//                   });
//                    context.SaveChanges();


//                }
//                //Actors & Movies
//                if (!context.Actors_Movies.Any())
//                {
//                    context.Actors_Movies.AddRange(new List<Actor_Movie>()
//                   {
//                        new Actor_Movie()
//                        {
//                            ActorId = 1,
//                            MovieId = 1,

//                        },
//                         new Actor_Movie()
//                         {
//                            ActorId = 2,
//                            MovieId = 1,
//                         },
//                          new Actor_Movie()
//                          {
//                            ActorId = 3,
//                            MovieId = 1,

//                          },
//                          new Actor_Movie()
//                          {
//                            ActorId = 1,
//                            MovieId = 2,
//                          },
//                          new Actor_Movie()
//                          {
//                            ActorId = 2,
//                            MovieId = 2,

//                          },
//                           new Actor_Movie()
//                          {
//                            ActorId = 3,
//                            MovieId = 2,

//                          },
//                           new Actor_Movie()
//                          {
//                            ActorId = 1,
//                            MovieId = 3,

//                          },
//                           new Actor_Movie()
//                          {
//                            ActorId = 2,
//                            MovieId = 3,

//                          },
//                             new Actor_Movie()
//                          {
//                            ActorId = 3,
//                            MovieId = 3,

//                          },
//                              new Actor_Movie()
//                          {
//                            ActorId = 4,
//                            MovieId = 3,

//                          },



//                   });

//                    context.SaveChanges();



//                }

//            }
//        }
//    }
//}
