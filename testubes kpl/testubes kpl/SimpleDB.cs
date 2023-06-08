using System;
using System.Collections;
using System.Collections.Generic;

namespace testubes_kpl
{
    public class SimpleDB
    {
        private List<string> Mahasiswa;

        public SimpleDB()
        {
            Mahasiswa = new List<string>();
        }

        public string Registrasi(string nama_Mhs, string pass_Mhs)
        {
            if (AddMahasiswa(nama_Mhs, pass_Mhs))
            {v
                return "Failed";
            }

            ArrayList maha = new ArrayList() { nama_Mhs, pass_Mhs };
            Mahasiswa.AddRange((IEnumerable<string>)maha);

            return "Success";
        }

        public bool AddMahasiswa(string nama_Mhs, string pass_Mhs)
        {
            for (int i = 0; i < Mahasiswa.Count; i += 2)
            {
                if (Mahasiswa[i] == nama_Mhs || Mahasiswa[i + 1] == pass_Mhs)
                {
                    return true;
                }
            }
            return false;
        }

        public string Login(string nama_Mhs, string pass_Mhs)
        {
            if (string.IsNullOrEmpty(nama_Mhs) || string.IsNullOrEmpty(pass_Mhs))
            {
                return "Isikan nama dan password";
            }

            if (!validateLogUsername(nama_Mhs) || !validateLogPass(pass_Mhs))
            {
                return "User/password tidak ditemukan";
            }

            return "Success";

        }

        public bool validateLogUsername(string nama_Mhs)
        {
            if (nama_Mhs == null)
            {
                Console.WriteLine("Masukan username");
                return false;
            }
            else if (!Mahasiswa.Contains(nama_Mhs))
            {
                Console.WriteLine("Username tidak ditemukan");
                return false;
            }

            return true;
        }

        public bool validateLogPass(string pass_Mhs)
        {
            if (pass_Mhs == null)
            {
                Console.WriteLine("Masukan password");
                return false;
            }
            else if (!Mahasiswa.Contains(pass_Mhs))
            {
                Console.WriteLine("Password tidak ditemukan");
                return false;
            }

            return true;
        }
    }
}
