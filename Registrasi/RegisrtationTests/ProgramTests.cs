using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Regisrtation;

namespace Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void RegisterUser_WithValidInput_ShouldSucceed()
        {
            // Arrange
            var username = "ui";
            var password = "password";
            var confirmpassword = "password";
            var registrationTypeInpute = "1";

            StringWriter consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            Class1.RegisterUser(username, password, confirmpassword, registrationTypeInpute);

            // Assert
            string output = consoleOutput.ToString(); 

            // Cek registrasi berhasil
            Assert.IsTrue(output.Contains("Registrasi berhasil!"), "Expected success message not found.");

            // Cek bila gagal
            Assert.IsFalse(output.Contains("Registrasi gagal, coba lagi."), "Unexpected failure message found.");


        }
    }
}