
using daftarEventLibrary;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace daftarEvent
{
    public class daftarEventUI
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
                Console.WriteLine((i + 1) + ") " + l[i].Title + " - " + status.statusEvent(l[i].StartDate, l[i].EndDate));
                Console.WriteLine(l[i].Description);
                Console.WriteLine("Waktu Mulai    : " + l[i].StartDate);
                Console.WriteLine("Waktu Berakhir : " + l[i].EndDate);
                Console.WriteLine(" ");
            }
        }


        public List<Event> removeEventsLewat(List<Event> l)
        {
            List<Event> t = new List<Event>();
            foreach (Event e in Events)
            {
                if(status.statusEvent(e.StartDate, e.EndDate) != "Berakhir" && status.statusEvent(e.StartDate, e.EndDate) != "Sedang Berlangsung")
                {
                    t.Add(e);
                }
            }
            return t;
        }

        public void sortByStartDate(List<Event> l)
        {
            List<Event> t = l;
            t.Sort((x, y) => x.StartDate.CompareTo(y.StartDate));
            printAllList(t);
        }

        public string AskForInput()
        {
            string input = null;
            bool inValid = true;
            while(inValid)
            {
                try
                {
                    input = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(input))
                    {
                        inValid = true;
                        throw new Exception();
                    }
                    inValid = false;
                }
                catch (Exception)
                {
                    Console.WriteLine("Input tidak boleh kosong");
                }
            }

            return input;
        }

        public int addEvent()
        {
            Console.WriteLine("Daftar event ke : ");

            String input;
            int intInput = 0;
            bool inValid = true;

            while (inValid)
            {
                try
                {
                    input = AskForInput();
                    intInput = int.Parse(input);
                    if (intInput <= 0 || intInput > Events.Count)
                    {
                        throw new Exception();
                    }
                    inValid = false;
                }
                catch (Exception)
                {
                    Console.WriteLine("Input tidak valid");
                }


            }

            if (myEvents.Contains(Events[intInput - 1]))
            {
                return -1;
            }
            else
            {
                return intInput;
            }
        }

        public void addToMyEvents(int x)
        {
            if(x == -1)
            {
                Console.WriteLine("Anda sudah mendaftar pada event ini sebelumnya");
            }
            else
            {
                myEvents.Add(Events[x - 1]);
                Console.WriteLine("Pendaftaran berhasil");
            }
        }

        public int deleteEvent()
        {
            if (myEvents.Count == 0)
            {
                return -1;
            }
            else
            {
                sortByStartDate(myEvents);

                Console.WriteLine("Hapus event ke : ");
                String input1;
                int intInput1 = 0;
                bool inValid = true;

                while (inValid)
                {
                    try
                    {
                        input1 = AskForInput();
                        intInput1 = int.Parse(input1);

                        if (intInput1 <= 0 || intInput1 > myEvents.Count)
                        {
                            throw new Exception();
                        }

                        inValid = false;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Input tidak valid");
                    }
                }

                return intInput1;

                
            }
        }

        public void deleteFromMyEvents(int x)
        {
            if(x == -1)
            {
                Console.WriteLine("Anda Belum Mendaftar Pada Event");
            }
            else
            {
                myEvents.Remove(myEvents[x - 1]);

                Console.WriteLine("Penghapusan berhasil");

                Console.WriteLine();
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

                        if (Events.Count == 0)
                        {
                            Console.WriteLine("Tidak ada event yang tersedia");
                        }
                        else
                        {
                            Events = removeEventsLewat(Events);
                            sortByStartDate(Events);
                        }
                        

                        Console.WriteLine("=======[My Events] - [Add] - [Exit]=======");
                        Console.WriteLine();
                        Console.WriteLine("1 = My Events");
                        Console.WriteLine("2 = Add");
                        Console.WriteLine("3 = Exit");
                        Console.WriteLine("Pilih Menu : ");

                        tombol = AskForInput();
                        if (tombol == "1")
                        {
                            state = State.myEvents;

                        }
                        else if (tombol == "2"){
                            state = State.addEvent;
                            
                        }else if (tombol == "3")
                        {
                            state = State.Exit;
                        }
                        break;

                    case State.myEvents:
                        Console.WriteLine("==============Halaman My Events==============");

                        if (myEvents.Count == 0)
                        {
                            Console.WriteLine("Anda Belum Mendaftar Pada Event");
                        }
                        else
                        {
                            sortByStartDate(myEvents);
                        }
                        

                        Console.WriteLine("==========[Main] - [Delete] - [Exit]=========");
                        Console.WriteLine();
                        Console.WriteLine("1 = Main");
                        Console.WriteLine("2 = Delete");
                        Console.WriteLine("3 = Exit");
                        Console.WriteLine("Pilih Menu : ");

                        tombol = AskForInput();
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
                        break;

                    case State.addEvent:
                        Console.WriteLine("==========Halaman Pendaftaran Event==========");

                        if (Events.Count == 0)
                        {
                            Console.WriteLine("Tidak ada event yang tersedia");
                        }
                        else
                        {
                            Events = removeEventsLewat(Events);
                            sortByStartDate(Events);
                        }

                        addToMyEvents(addEvent());

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
                        break;
                    case State.deleteEvent:
                        Console.WriteLine("==============Halaman My Events==============");


                        deleteFromMyEvents(deleteEvent());
                        
                        Console.WriteLine("=======[My Events] - [Delete] - [Exit]=======");
                        Console.WriteLine();
                        Console.WriteLine("1 = myEvent");
                        Console.WriteLine("2 = Delete");
                        Console.WriteLine("3 = Exit");
                        Console.WriteLine("Pilih Menu : ");

                        tombol = AskForInput();

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
                        break;
                }
            }
            Console.WriteLine("Anda keluar dari program");

        }
    }

    
}
