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
        [TestCase("testuser", "testpassword", ExpectedResult = true)]
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

        [TestCase("lo", ExpectedResult = false)]
        [TestCase("", ExpectedResult = false)]
        [TestCase("!!fuck", ExpectedResult = false)]
        [TestCase("lo23232#", ExpectedResult = false)]
        [TestCase("hehell433", ExpectedResult = true)]
        [TestCase("lggdsado", ExpectedResult = true)]
        [TestCase("asd", ExpectedResult = true)]
        [TestCase("sad4", ExpectedResult = true)]
        public bool ValidInputForUserRegister_GivesAstring_ReturnsIfInputIsValid(string input)
        {
            Register registerTest = new Register();
            return registerTest.IsInputValid(input);
        }
    }



    /// <summary>This class contains parameterized unit tests for MySqlCommands</summary>
    [PexClass(typeof(MySqlCommands))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestFixture]
    public partial class MySqlCommandsTest
    {
        /// <summary>Test stub for CreateNewUser(String, String, String, String)</summary>
        [PexMethod]
        internal bool CreateNewUserTest(
            string firstName,
            string lastName,
            string userName,
            string password
        )
        {
            bool result
               = MySqlCommands.CreateNewUser(firstName, lastName, userName, password);
            return result;
            // TODO: add assertions to method MySqlCommandsTest.CreateNewUserTest(String, String, String, String)
        }

        /// <summary>Test stub for FindUser(String, String)</summary>
        [PexMethod]
        internal bool FindUserTest(string userName, string password)
        {
            bool result = MySqlCommands.FindUser(userName, password);
            return result;
            // TODO: add assertions to method MySqlCommandsTest.FindUserTest(String, String)
        }

        /// <summary>Test stub for GetMovies()</summary>
        [PexMethod]
        internal List<MovieMenuItem> GetMoviesTest()
        {
            List<MovieMenuItem> result = MySqlCommands.GetMovies();
            return result;
            // TODO: add assertions to method MySqlCommandsTest.GetMoviesTest()
        }

        /// <summary>Test stub for UserExist(String)</summary>
        [PexMethod]
        internal bool UserExistTest(string userName)
        {
            bool result = MySqlCommands.UserExist(userName);
            return result;
            // TODO: add assertions to method MySqlCommandsTest.UserExistTest(String)
        }
    }
}
