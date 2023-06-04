using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Registrasi.Controllers
{
    public class RegistrasiController : ControllerBase
    {
        public List<User> users = new List<User>();

        public void RegisterUser(User user)
        {
            Contract.Requires(!string.IsNullOrEmpty(user.Username));
            Contract.Requires(!string.IsNullOrEmpty(user.Email));
            Contract.Requires(!string.IsNullOrEmpty(user.Password));

            // Check if user already exists
            Contract.Requires(!UserExists(user.Email));

            // Add new user to user list
            users.Add(user);
            Console.WriteLine("User with email {0} registered successfully.", user.Email);

            // Postconditions
            Contract.Ensures(UserExists(user.Email));
        }

        public bool UserExists(string email)
        {
            return FindUserByEmail(email) != null;
        }

        public User FindUserByEmail(string email)
        {
            return users.Find(u => u.Email == email);
        }

        public Dictionary<string, Action<List<User>, User>> table = new Dictionary<string, Action<List<User>, User>>();

        public Dictionary<string, Action<List<User>, User>> GetTable()
        {
            return table;
        }

        public void TambahUser(User user, Dictionary<string, Action<List<User>, User>> table)
        {
            Contract.Requires(table != null, "List Users cannot be null");
            Contract.Requires(user != null, "User cannot be null");

            // Check if user already exists
            if (table.TryGetValue("add", out Action<List<User>, User> add))
            {
                // Call the 'add' action with the list of users and the new user
                add(users, user);
            }
        }

        [HttpPost]
        public void TambahUserRil(User user)
        {
            Contract.Requires(user != null, "User cannot be null.");
            Contract.Requires(!string.IsNullOrWhiteSpace(user.Username), "Username cannot be null or empty.");
            Contract.Requires(!string.IsNullOrWhiteSpace(user.Password), "Password cannot be null or empty.");
            Contract.Requires(!string.IsNullOrWhiteSpace(user.Email), "Email cannot be null or empty.");

            Console.WriteLine("Masukan nama");
            Console.WriteLine("masukan password");
            Console.WriteLine("masukan email");

            Console.WriteLine("Items Added To Inventory Are: "); // Outputs List in reverse order. (Recent input first).
            for (int i = 0; i < 10; i++) // Continue For Loop until i is < the needed amount.
            {
                Console.WriteLine($"{i + 1}: Enter Item Name To Add To Inventory"); // Asks for user input into array.
                user.Username = Console.ReadLine(); // User inputs value into field.
                user.Password = Console.ReadLine();
                user.Email = Console.ReadLine();
                users.Add(user);
            }

            Dictionary<string, Action<List<User>, User>> table = new Dictionary<string, Action<List<User>, User>>();
            RegisterUser(user);
            TambahUser(user, table);
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            return users;
        }
    }

    public class User
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
