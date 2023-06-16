using System;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Function
{

    public class Login
    {

        static async Task Main(string[] args)
        {
            bool isAuthenticated = false;

            while (!isAuthenticated)
            {
                Console.WriteLine("Menu");
                string Menu = Console.ReadLine();

                Console.WriteLine("Masukan username:");
                string username = Console.ReadLine();


                Console.WriteLine("Masukan password:");
                string password = Console.ReadLine();


                Console.WriteLine("Apakah username dan password nya sudah benar? (yes/no)");
                string confirmation = Console.ReadLine();
                if (confirmation.ToLower() == "yes")
                {
                    Console.WriteLine("Anda berhasil Melakukan login:");
                }
                else if (confirmation.ToLower() == "no")
                {
                    Console.WriteLine("Input tidak valid!");
                    Console.WriteLine("Anda gagal Melakukan login:");
                }
                else
                {
                    Console.WriteLine("Input tidak valid!");

                }

                if (await ValidateLogin(username, password))
                {
                    isAuthenticated = true;
                    Console.WriteLine("Login successful!");
                }
                else
                {
                    Console.WriteLine("Invalid username or password. Please try again.");
                }
            }
        }

        static async Task<bool> ValidateLogin(string username, string password)
        {
            // Perform automata validation on the client-side
            if (!ValidateUsername(username) || !ValidatePassword(password))
            {
                return false;
            }

            using (var client = new HttpClient())
            {
                var loginData = new
                {
                    username,
                    password
                };

                var response = await client.PostAsJsonAsync("https://api.example.com/login", loginData);

                if (response.IsSuccessStatusCode)
                {
                    // Login successful
                    return true;
                }
                else
                {
                    // Login failed
                    return false;
                }
            }
        }

        static bool ValidateUsername(string username)
        {
            // Automata logic for username validation
            // Add your automata rules here
            return true; // Return true if username is valid, otherwise false
        }

        static bool ValidatePassword(string password)
        {
            // Automata logic for password validation
            // Add your automata rules here
            return true; // Return true if password is valid, otherwise false
        }
    }
}
