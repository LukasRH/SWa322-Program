// <copyright file="MySqlCommandsTest.cs">Copyright ©  2017</copyright>
using System;
using System.Collections.Generic;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using NUnit.Framework;
using RecommenderSystem;

namespace RecommenderSystem.Tests
{


    class NUnitTesting
    {
        [TestCase("1234", "1234", ExpectedResult = true)]
        [TestCase("thisusernameshouldneverbemade", "thispasswordshouldneverbegiven4545$£@{{€$", ExpectedResult = false)]
        [TestCase("", "", ExpectedResult = false)]
        public bool Login_ReceiveUsernameAndPasssword_returnsState(string username, string password)
        {
            return MySqlCommands.FindUser(username, password);
        }

        [TestCase("hey", ExpectedResult = true)]
        [TestCase("asdasdasdasdasdsadas", ExpectedResult = false)]
        [TestCase("", ExpectedResult = true)]
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
            List<MovieMenuItem> foundMovies = MySqlCommands.FindMovieFromID(movieIds);
            Assert.AreEqual(movieIds.Count, foundMovies.Count);
        }

        [TestCase(11, 22, 0)]
        [TestCase(251, 0, 15)]
        public void FindMovieFromID_FindsMoviesCorrespondingToMovieId_PassesIfAllMoviesNotAreFound(params int[] id)
        {
            List<int> movieIds = new List<int>(id);
            List<MovieMenuItem> foundMovies = MySqlCommands.FindMovieFromID(movieIds);
            Assert.AreNotEqual(movieIds.Count, foundMovies.Count);
        }

        [TestCase()]
        public void GetMovies_FindsAllMoviesInDatabase_PassesIfAllMoviesAreFound()
        {
            int numberOfMovies = MySqlCommands.NumberOfRowsInTable("imdbdata");
            List<MovieMenuItem> movies = MySqlCommands.GetMovies();
            Assert.AreEqual(numberOfMovies, movies.Count);
        }
    }
}
