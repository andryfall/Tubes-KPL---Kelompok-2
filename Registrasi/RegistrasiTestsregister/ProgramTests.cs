using Microsoft.VisualStudio.TestTools.UnitTesting;
using Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void TestValidRegistration()
        {
            // Arrange
            string username = "qui";
            string password = "P@ssw0rd";
            RegistrationType registrationType = RegistrationType.Default;

            // Act
            bool result = Program.ValidateRegistration(username, password, registrationType);

            // Assert
            Assert.IsTrue(result, "Valid registration should return true.");
        }

        [TestMethod]
        public void TestInvalidRegistration()
        {
            // Arrange
            string username = "ui";
            string password = "123456"; // Invalid password
            RegistrationType registrationType = RegistrationType.Admin;

            // Act
            bool result = Program.ValidateRegistration(username, password, registrationType);

            // Assert
            Assert.IsFalse(result, "Invalid registration should return false.");
        }
    }
}