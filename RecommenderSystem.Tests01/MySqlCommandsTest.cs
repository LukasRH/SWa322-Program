// <copyright file="MySqlCommandsTest.cs">Copyright ©  2017</copyright>
using System;
using System.Collections.Generic;
using NUnit.Framework;
using RecommenderSystem;
using MySql.Data.MySqlClient;

namespace RecommenderSystem.Tests
{


    class NUnitTesting
    {
        [TestCase("testuser", "testuser", ExpectedResult = true)]
        [TestCase("thisusernameshouldneverbemade", "thispasswordshouldneverbegiven4545$£@{{€$", ExpectedResult = false)]
        [TestCase("", "", ExpectedResult = false)]
        public bool Login_ReceiveUsernameAndPasssword_returnsState(string username, string password)
        {
            return MySqlCommands.FindUser(username, password);
        }

        [TestCase("hey", ExpectedResult = true)]
        [TestCase("asdasdasdasdasdsadas", ExpectedResult = false)]
        [TestCase("", ExpectedResult = false)]
        [TestCase("NUnitTest", ExpectedResult = true)]
        public bool UsernameExists_ChecksIfUsernameExists_ReturnsStateIfUsernameExists(string username)
        {
            return MySqlCommands.UserExist(username);
        }

        [TestCase(20, "thumbsup", ExpectedResult = true)]
        [TestCase(12, "thumbsdown", ExpectedResult = true)]
        [TestCase(21, "thumbs up", ExpectedResult = false)]
        [TestCase(22, "thumbs down", ExpectedResult = false)]
        [TestCase(20, "", ExpectedResult = false)]
        [TestCase(0, "thumbsup", ExpectedResult = false)]
        [TestCase(20, "thumbsdown", ExpectedResult = true)]
        [TestCase(251, "thumbsup", ExpectedResult = false)]
        public bool RateMovie_ChecksIfMovieGetsRated_ReturnsTrueIfMovieIsRated(int movieId, string enumvalue)
        {
            new User("NUnitTest");

            return MySqlCommands.RateMovie(movieId, enumvalue);
        }

        [TestCase(20, ExpectedResult = true)]
        [TestCase(0, ExpectedResult = false)]
        [TestCase(10, ExpectedResult = false)]
        public bool IsMovieRated_ChecksIfMoviesAreRated_ReturnsTrueIfMovieIsRated(int movieId)
        {
            new User("NUnitTest");

            return MySqlCommands.IsMovieRated(movieId);
        }

        [TestCase(1, 2, 3)]
        [TestCase(99, 101, 50)]
        public void FindMovieFromID_FindsMoviesCorrespondingToMovieId_ReturnsTrueIfAllMoviesAreFound(params int[] id)
        {
            List<int> movieIds = new List<int>(id);
            List<MovieMenuItem> foundMovies = MySqlCommands.FindMovieFromId(movieIds);
            Assert.AreEqual(movieIds.Count, foundMovies.Count);
        }

        [TestCase(11, 22, 0)]
        [TestCase(251, 0, 15)]
        public void FindMovieFromID_FindsMoviesCorrespondingToMovieId_PassesIfAllMoviesNotAreFound(params int[] id)
        {
            List<int> movieIds = new List<int>(id);
            List<MovieMenuItem> foundMovies = MySqlCommands.FindMovieFromId(movieIds);
            Assert.AreNotEqual(movieIds.Count, foundMovies.Count);
        }

        [TestCase()]
        public void GetMovies_FindsAllMoviesInDatabase_PassesIfAllMoviesAreFound()
        {
            int numberOfMovies = MySqlCommands.NumberOfRowsInTable("imdbdata");
            List<MovieMenuItem> movies = MySqlCommands.GetMovies();
            Assert.AreEqual(numberOfMovies, movies.Count);
        }

        [TestCase(20)]
        [TestCase(12)]
        public void FindRatingFromMovieID_FindsRatingCorrespondingToMovieId_PassesIfRatingIsFound(int movieId)
        {
            new User("NUnitTest");
            string movieRating = MySqlCommands.FindRatingFromMovieId(movieId);
            Assert.AreNotEqual("notRated", movieRating);
        }

        [TestCase(0)]
        [TestCase(251)]
        [TestCase(100)]
        public void FindRatingFromMovieID_FindsRatingCorrespondingToMovieId_PassesIfRatingIsNotFound(int movieId)
        {
            new User("NUnitTest");
            string movieRating = MySqlCommands.FindRatingFromMovieId(movieId);
            Assert.AreEqual("notRated", movieRating);
        }

        //Kommenteret ud fordi at testen laver en ny user hver gang den køres. (Passer hver gang)
        //[TestCase("Testuser", "Testuser", "Testuser", "Testuser")]
        //public void CreateNewUser_ChecksIfUserGetsCreatedInDatabase_PassesIfTrue(string firstName, string lastName,
        //    string userName, string password)
        //{
        //    Assert.IsTrue(MySqlCommands.CreateNewUser(firstName, lastName, userName, password));
        //}

        //Kommenteret ud fordi at testen laver en ny user table hver gang den køres. (Passer hver gang)
        //[TestCase("Testuser")]
        //public void CreateUserTable_ChecksIfUserTableGetsCreatedInDatabase_PassesIfTrue(string userName)
        //{
        //    Assert.IsTrue(MySqlCommands.CreateUserTable(userName));
        //}

        [TestCase()]
        public void GetUserRatedMovies_SelectMoviesFromUsersTable_PassesIfGetsAllMovies()
        {
            new User("NUnitTest");
            int numberOfMoviesInTable = MySqlCommands.NumberOfRowsInTable("NUnitTest_movies");
            Assert.AreEqual(numberOfMoviesInTable, MySqlCommands.GetUserRatedMovies().Count);
        }

        
    }
}
