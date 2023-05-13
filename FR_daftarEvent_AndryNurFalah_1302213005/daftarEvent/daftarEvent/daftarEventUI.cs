using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace daftarEvent
{
    internal class daftarEventUI
    {
        public List<Event> myEvents = new List<Event>();
        public List<Event> Events;
        public daftarEventUI(eventList a) {
            Events = a.events;
        }
        public enum State {Main,  myEvents, addEvent, deleteEvent, Exit};

        State state = State.Main;

        public void printAllList(List<Event> l)
        {
            for (int i = 0; i < l.Count; i++)
            {
                Console.WriteLine((i + 1) + ") " + l[i].Title);
                Console.WriteLine(l[i].Description);
                Console.WriteLine("Waktu Mulai    : " + l[i].StartDate);
                Console.WriteLine("Waktu Berakhir : " + l[i].EndDate);
                Console.WriteLine(" ");
            }
        }

        public void runApp()
        {

            while (state != State.Exit)
            {
                string tombol;

                switch (state)
                {
                    case State.Main:
                        Console.WriteLine("==========Halaman Pendaftaran Event==========");

                        printAllList(Events);

                        Console.WriteLine("=======[My Events] - [Add] - [Exit]=======");
                        Console.WriteLine();
                        Console.WriteLine("1 = My Events");
                        Console.WriteLine("2 = Add");
                        Console.WriteLine("3 = Exit");
                        Console.WriteLine("Pilih Menu : ");

                        tombol = Console.ReadLine();
                        if (tombol == "1")
                        {
                            state = State.myEvents;

                        }
                        else if (tombol == "2"){
                            state = State.addEvent;
                            
                        }else if (tombol == "3")
                        {
                            state = State.Exit;
                        }else
                        {
                            state = State.Main;
                        }
                        break;

                    case State.myEvents:
                        Console.WriteLine("==============Halaman My Events==============");

                        printAllList(myEvents);

                        Console.WriteLine("==========[Main] - [Delete] - [Exit]=========");
                        Console.WriteLine();
                        Console.WriteLine("1 = Main");
                        Console.WriteLine("2 = Delete");
                        Console.WriteLine("3 = Exit");
                        Console.WriteLine("Pilih Menu : ");

                        tombol = Console.ReadLine();

                        if (tombol == "1")
                        {
                            state = State.Main;

                        }
                        else if (tombol == "2")
                        {
                            state = State.deleteEvent;

                        }
                        else if (tombol == "3")
                        {
                            state = State.Exit;
                        }
                        else
                        {
                            state = State.myEvents;
                        }
                        break;

                    case State.addEvent:
                        Console.WriteLine("==========Halaman Pendaftaran Event==========");

                        printAllList(Events);

                        Console.WriteLine("Daftar event ke : ");
                        String input = Console.ReadLine();

                        int intInput = int.Parse(input);

                        myEvents.Add(Events[intInput-1]);

                        Console.WriteLine("Pendaftaran berhasil");
                        Console.WriteLine();
                        Console.WriteLine("=======[My Events] - [Add] - [Exit]=======");
                        Console.WriteLine();
                        Console.WriteLine("1 = My Events");
                        Console.WriteLine("2 = Add");
                        Console.WriteLine("3 = Exit");
                        Console.WriteLine("Pilih Menu : ");

                        tombol = Console.ReadLine();
                        if (tombol == "1")
                        {
                            state = State.myEvents;

                        }
                        else if (tombol == "2")
                        {
                            state = State.addEvent;

                        }
                        else if (tombol == "3")
                        {
                            state = State.Exit;
                        }
                        else
                        {
                            state = State.Main;
                        }
                        break;
                    case State.deleteEvent:
                        Console.WriteLine("==============Halaman My Events==============");


                        printAllList(myEvents);

                        Console.WriteLine("Hapus event ke : ");
                        String input1 = Console.ReadLine();

                        int intInput1 = int.Parse(input1);

                        myEvents.Remove(myEvents[intInput1-1]);

                        Console.WriteLine("Penghapusan berhasil");
                        Console.WriteLine();
                        Console.WriteLine("=======[My Events] - [Delete] - [Exit]=======");
                        Console.WriteLine();
                        Console.WriteLine("1 = myEvent");
                        Console.WriteLine("2 = Delete");
                        Console.WriteLine("3 = Exit");
                        Console.WriteLine("Pilih Menu : ");

                        tombol = Console.ReadLine();

                        if (tombol == "1")
                        {
                            state = State.myEvents;

                        }
                        else if (tombol == "2")
                        {
                            state = State.deleteEvent;

                        }
                        else if (tombol == "3")
                        {
                            state = State.Exit;
                        }
                        else
                        {
                            state = State.myEvents;
                        }
                        break;
                }
            }

        }
    }

    
}
