using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace Registrasi.Controllers.Tests
{
    [TestClass]
    public class RegistrasiControllerTests
    {
        private RegistrasiController registrasiController;

        [TestInitialize]
        public void Setup()
        {
            registrasiController = new RegistrasiController();
        }

        [TestMethod]
        public void RegisterUser_ValidUser_AddsUserToList()
        {
            // Arrange
            var user = new User
            {
                Username = "john",
                Email = "john@example.com",
                Password = "password"
            };

            // Act
            registrasiController.RegisterUser(user);

            // Assert
            Assert.IsTrue(registrasiController.UserExists(user.Email));
        }

        [TestMethod]
        public void RegisterUser_UserAlreadyExists_ThrowsContractException()
        {
            // Arrange
            var user = new User
            {
                Username = "john",
                Email = "john@example.com",
                Password = "password"
            };

            registrasiController.RegisterUser(user);

            // Act & Assert
            Assert.ThrowsException<ContractException>(() => registrasiController.RegisterUser(user));
        }

        [TestMethod]
        public void FindUserByEmail_UserExists_ReturnsUser()
        {
            // Arrange
            var user = new User
            {
                Username = "john",
                Email = "john@example.com",
                Password = "password"
            };

            registrasiController.RegisterUser(user);

            // Act
            var foundUser = registrasiController.FindUserByEmail(user.Email);

            // Assert
            Assert.AreEqual(user, foundUser);
        }

        [TestMethod]
        public void FindUserByEmail_UserDoesNotExist_ReturnsNull()
        {
            // Arrange
            var user = new User
            {
                Username = "john",
                Email = "john@example.com",
                Password = "password"
            };

            // Act
            var foundUser = registrasiController.FindUserByEmail(user.Email);

            // Assert
            Assert.IsNull(foundUser);
        }

        [TestMethod]
        public void TambahUser_ValidUser_CallsAddAction()
        {
            // Arrange
            var user = new User
            {
                Username = "john",
                Email = "john@example.com",
                Password = "password"
            };

            var table = new Dictionary<string, Action<List<User>, User>>();
            var isAddActionCalled = false;

            table["add"] = (users, newUser) =>
            {
                isAddActionCalled = true;
                Assert.AreEqual(users, registrasiController.users);
                Assert.AreEqual(newUser, user);
            };

            // Act
            registrasiController.TambahUser(user, table);

            // Assert
            Assert.IsTrue(isAddActionCalled);
        }
    }
}
