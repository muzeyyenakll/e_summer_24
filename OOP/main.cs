using System;
using System.Collections.Generic;

namespace OOP_in_Csharp
{
    class Computer
    {
        private string _BIOSname;
        private string _ipadress;
        private string _OS;
        private static int _counter = 0;
        public Computer(string bn, string ip, string os)
        {
            this._BIOSname = bn;
            this._ipadress = ip;
            this._OS = os;

            _counter++;
        }
        public Computer()
        {
            _counter++;
        }
        public static int getCompsNum()
        {
            return _counter;
        }
        //properties
        public string BiosName
        {
            get { return this._BIOSname; }
            set { this._BIOSname = value; }
        }
        public string IPAddress
        {
            get { return this._ipadress; }
            set { this._ipadress = value; }
        }

        public string OS
        {
            get { return this._OS; }
            set { this._OS = value; }
        }

        public static string getNum()
        {
            Random random = new Random();
            int num;
            num = random.Next(1, 255);
            return num.ToString();
        }

        public void StartComputer()
        {
            IPAddress = "10.0." + getNum() + "." + getNum();
        }
    }

    class Program
    {

        static void ShowCompters(List<Computer> network)
        {
            foreach (Computer comp in network)
            {
                Console.WriteLine("{0} {1}", comp.BiosName, comp.IPAddress);
            }
            Console.WriteLine("\nWe have {0} computers!!!!", Computer.getCompsNum());
        }

        static void ShutDownComp(List<Computer> network, string compName)
        {
            for (int i = 0; i < network.Count; i++)
            {
                if (network[i].BiosName == compName)
                {
                    network.RemoveAt(i);
                    break; // Exit loop after removing the computer
                }
            }
        }

        static void ping(string ip_to, List<Computer> network)
        {
            Random random = new Random();
            int min = 10000;
            int max = 0;
            int time = 0;
            double avg = 0;

            bool found = false;
            for (int i = 0; i < network.Count; i++)
            {
                if (ip_to == network[i].IPAddress)
                {
                    found = true;
                    break;
                }
            }
            if (found)
            {
                Console.WriteLine("Pinging {0} with 32 bytes of data:", ip_to);
                for (int i = 0; i < 4; i++)
                {
                    time = random.Next(1, 50);
                    if (time > max) { max = time; }
                    if (time < min) { min = time; }
                    avg += time;
                    Console.WriteLine("Reply from {0}: bytes=32 time={1}ms TTL=55", ip_to, time);
                }

                Console.WriteLine("Ping statistics for {0}", ip_to);
                Console.WriteLine("Minimum = {0}ms Maximum = {1}ms Average = {2}ms", min, max, Math.Round(avg / 4, 0));
            }
            else
            {
                Console.WriteLine("Pinging {0} with 32 bytes of data:", ip_to);
            }
        }

        public static void Main(string[] args)
        {
            List<Computer> net = new List<Computer>();
            Computer server = new Computer();
            server.BiosName = "SERVER";
            server.IPAddress = "10.0.100.100";
            server.OS = "Linux";
            net.Add(server);

            const int numComps = 5;

            for (int i = 1; i < numComps; i++)
            {
                Computer comp = new Computer("comp" + i.ToString(), "", "Win10");
                net.Add(comp);
                comp.StartComputer();
            }
            ShowCompters(net);

            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n------ Menu ------");
                Console.WriteLine("1. Display Computers");
                Console.WriteLine("2. Exit");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("\n--- Displaying Computers ---");
                        ShowCompters(net);
                        break;
                    case "2":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please choose again.");
                        break;
                }
            }
        }
    }
}
