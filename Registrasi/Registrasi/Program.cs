﻿using System;
using System.Net.Http;
using System.Diagnostics.Contracts;
using System.Net.Http.Json;

namespace Registration
{
    public enum RegistrationType
    {
        Default,
        Admin
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            bool isRegistered = false;

            while (!isRegistered)
            {
                Console.WriteLine("Menu");
                Console.WriteLine("1. Register");
                Console.WriteLine("2. Exit");
                Console.Write("Pilih: ");
                string pilih = Console.ReadLine();

                switch (pilih)
                {
                    case "1":
                        RegisterUser();
                        break;
                    case "2":
                        Console.WriteLine("Exiting program...");
                        return;
                    default:
                        Console.WriteLine("pilihan salah, coba lagi.");
                        break;
                }
            }
        }

        public static void RegisterUser()
        {
            Console.WriteLine("Registration Form");
            Console.Write("Masukan username: ");
            string username = Console.ReadLine();

            Console.Write("Masukan password: ");
            string password = Console.ReadLine();

            Console.Write("Konfirmasi password: ");
            string confirmPassword = Console.ReadLine();

            Contract.Requires<ArgumentException>(!string.IsNullOrEmpty(username), "Username cannot be empty.");
            Contract.Requires<ArgumentException>(!string.IsNullOrEmpty(password), "Password cannot be empty.");
            Contract.Requires<ArgumentException>(!string.IsNullOrEmpty(confirmPassword), "Confirmation password cannot be empty.");
            Contract.Requires<ArgumentException>(password == confirmPassword, "Password and confirmation password must match.");

            Console.WriteLine("Pilih tipe registrasi:");
            Console.WriteLine("1. Default");
            Console.WriteLine("2. Admin");
            Console.Write("Masukan tipe registrasi(1/2): ");
            string registrationTypeInput = Console.ReadLine();

            Contract.Requires<ArgumentException>(Enum.TryParse(registrationTypeInput, out RegistrationType registrationType), "Invalid registration type.");

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

            using (var client = new HttpClient())
            {
                var registrationData = new
                {
                    username = username,
                    password = password,
                    registrationType = registrationType.ToString()
                };

                var response = client.PostAsJsonAsync("https://api.example.com/register", registrationData).Result;

                Contract.Ensures(Contract.Result<bool>() == response.IsSuccessStatusCode);

                return response.IsSuccessStatusCode;
            }
        }
    }
}
