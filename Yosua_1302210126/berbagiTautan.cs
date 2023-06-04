using System;
using System.Diagnostics;
using System.Text.Json;
using Newtonsoft;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Yosua_1302210126
{
    public class berbagiTautan
    {
        public enum aplikasi
        {
            Instagram,
            WhatsApp,
            Twitter
        }

        public string getAplikasi(aplikasi x)
        {
            string[] App = {"Event Akan Terkirim Ke Instagram", "Event Akan Terkirim Ke WhatsApp", "Event Akan Terkirim Ke Twitter" };
            int indeks = (int)x;
            return App[indeks];
        }
        static void Main(string[] args)
        {
            berbagiTautan program = new berbagiTautan();

            /*Console.WriteLine("masukkan 4 digit OTP");
            string a = Console.ReadLine();
            Console.WriteLine(program.kodeOTP(a));
            Console.WriteLine(" ");*/

            PilihEvent(program);

        }

        static void Pilih()
        {
            berbagiTautan newthing = new berbagiTautan();
            Console.WriteLine("Pilih media share");
            Console.WriteLine(" ");
            Console.WriteLine("1. Instagram");
            Console.WriteLine("2. WhatsApp");
            Console.WriteLine("3. Twitter");
            Console.WriteLine(" ");

            string input = Console.ReadLine();

            if (input == "1")
            {
                string pilihan = newthing.getAplikasi(aplikasi.Instagram);
                Console.WriteLine(pilihan);
            }
            else if ( input == "2") 
            {
                string pilihan = newthing.getAplikasi(aplikasi.WhatsApp);
                Console.WriteLine(pilihan);
            }
            else if (input == "3")
            {
                string pilihan = newthing.getAplikasi(aplikasi.Twitter);
                Console.WriteLine(pilihan);
            }
            else
            {
                Console.WriteLine("Pilih Aplikasi Media Share");
            }

        }

       /* public string kodeOTP(string i)
        {
            int inputCek = Convert.ToInt32(i);

            if (inputCek > 999 && inputCek < 10000)
            {
                return "terimakasih atas perhatiannya";
            }
            else
            {
                Console.WriteLine("Kode salah");
                Environment.Exit(0);
                return " ";
            }
        }*/

        public bool kepastian(string a)
        {
            if (a.ToLower() == "yes")
            {
                return true;
            }
            else if (a.ToLower() == "no")
            {
                return false;
            }
            else { return false; }
        }

        static void PilihEvent(berbagiTautan program) 
        {
            List<listEvent> daftar = new List<listEvent>();
            daftar.Add(new listEvent("Bachelor Software Enginering", "TelkomUniversity", "Selasa, 9 Mei 2023"));
            daftar.Add(new listEvent("Software Quality Assurance Life Cycle in Traditional and Agile Software Development", "TelkomUniversity", "Sabtu 6 Mei 2023"));
            daftar.Add(new listEvent("Database Implementation in Microservices Architecture", "TelkomUniversity", "Selasa 2 Mei 2023"));
            Seri(daftar);
            List<listEvent> Daftar = deseri<List<listEvent>>("event.json");
            Console.WriteLine(" ");
            Console.WriteLine("0.  Bachelor Software Enginering");
            Console.WriteLine("1.  Software Quality Assurance Life Cycle in Traditional and Agile Software Development");
            Console.WriteLine("2.  Database Implementation in Microservices Architecture");
            Console.WriteLine(" ");
            Console.WriteLine("Silahkan Pilih Event Yang Ingin Di Share : ");

            string i = Console.ReadLine();


            Debug.Assert(i.Length == 1, "Input Berlebihan");

            try
            {
                int cek = Convert.ToInt32(i);

                if (cek <= 2)
                {
                    Console.WriteLine("Nama Event: " + daftar[cek].namaEvent);
                    Console.WriteLine("Alamat : " + daftar[cek].alamat);
                    Console.WriteLine("Tanggal : " + daftar[cek].tanggal);
                    Console.WriteLine(" ");
                    Pilih();
                    Console.WriteLine("anda yakin mengirim postingan?");
                    Console.WriteLine(" ");
                    string b = Console.ReadLine();
                    if (program.kepastian(b) == true)
                    {
                        Console.WriteLine("Proses Selesai");
                    }
                    else
                    {
                        Console.WriteLine("Proses dibatalkan");

                    }

                }
               
            }
            catch ( FormatException e)
            {
                Console.WriteLine("Input melebihi");
            }
        }   
        private static void Seri(Object obj) 
        {
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };
            string output = JsonSerializer.Serialize(obj, options);
            File.WriteAllText(@"D:\semester 4\KPL\Latihan\Yosua_1302210126\Yosua_1302210126\event.json", output);
        }

        private static Tipe deseri<Tipe>(string input)
        {
            string JsonString = File.ReadAllText(@"D:\semester 4\KPL\Latihan\Yosua_1302210126\Yosua_1302210126\event.json");
            return JsonSerializer.Deserialize<Tipe>(JsonString);
        }
    }

    public class listEvent
    {
        public string namaEvent { get; set; } 
        public string alamat { get; set; }
        public string tanggal { get; set; }

       public listEvent() { }

        public listEvent(string namaEvent, string alamat, string tanggal)
        {
            this.namaEvent = namaEvent;
            this.alamat = alamat;  
            this.tanggal = tanggal;

        }
    }
}