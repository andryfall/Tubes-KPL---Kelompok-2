using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regisrtation
{
    public class Class1
    {
        public static string[] existingUsernames = new string[0];
        public enum RegistrationType
        {
            Default,
            Admin
        }

        public static void RegisterUser(string username, string password, string confirmpassword, string registrationTypeInput)
        {

            Contract.Requires<ArgumentException>(!string.IsNullOrEmpty(username), "Username cannot be empty.");
            Contract.Requires<ArgumentException>(!string.IsNullOrEmpty(password), "Password cannot be empty.");
            Contract.Requires<ArgumentException>(!string.IsNullOrEmpty(confirmpassword), "Confirmation password cannot be empty.");
            Contract.Requires<ArgumentException>(password == confirmpassword, "Password and confirmation password must match.");
            RegistrationType registrationType;
            Contract.Requires<ArgumentException>(Enum.TryParse(registrationTypeInput, out registrationType), "Invalid registration type.");

            // Perform additional validation if needed

            if (ValidateRegistration(username, password, registrationType))
            {
                Console.WriteLine("Registrasi berhasil!");
            }
            else
            {
                Console.WriteLine("Registrasi gagal, coba lagi.");
            }
        }

        public static bool ValidateRegistration(string username, string password, RegistrationType registrationType)
        {
            // Perform any additional validation or checks here
            if (Array.Exists(existingUsernames, u => u.Equals(username, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("Username sudah ada.");
                return false;
            }

            return true;
        }
    }
}
