// See https://aka.ms/new-console-template for more information
using Regisrtation;
using WindowsFormsApp1;
using System.Runtime.CompilerServices;


public class Program
{
    public enum RegistrationType
    {
        Default,
        Admin
    }
    public static string[] existingUsernames = new string[0];
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

                    Console.WriteLine("form registrasi");
                    Console.Write("Masukan username: ");
                    string username = Console.ReadLine();
                    Console.Write("Masukan password: ");
                    string password = Console.ReadLine();
                    Console.Write("Konfirmasi password: ");
                    string confirmpassword = Console.ReadLine();
                    Console.WriteLine("Pilih tipe registrasi:");
                    Console.WriteLine("1. Default");
                    Console.WriteLine("2. Admin");
                    Console.Write("Masukan tipe registrasi(1/2): ");
                    string registrationTypeInput = Console.ReadLine();
                    Class1.RegisterUser(username, password, confirmpassword, registrationTypeInput);
                    break;
                case "2":
                    Console.WriteLine("Exiting program...");
                    return;
                default:
                    Console.WriteLine("pilihan salah, coba lagi.");
                    break;
            }
        }
        Form1 Form1;
    }
}

