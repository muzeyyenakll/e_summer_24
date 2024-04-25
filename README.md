# project summer 2024
## OOP
### Network Management System Repository

### Description 

The system allows users to perform various operations such as displaying computers in the network, pinging a computer, shutting down computers, starting the server, and starting computers.

### Features:



```csharp

            // Display list of computers
            internal static void ShowComputers(List<Computer> network)
        {
            foreach (Computer comp in network)
            {
                string is_on = comp.ON ? "ON" : "OFF";
                Console.WriteLine("{0} {1} {2} {3}", comp.BIOSName, comp.IP, comp.ON, is_on);
            }
            Console.WriteLine("We have {0} computers!!!!", Computer.getCounter());
        }
 
        // Shut down 2 computers
        internal static void ShutDownComp(List<Computer> network, int count)
        {
            Random random = new Random();
            List<Computer> computersToShutDown = new List<Computer>();

            while (count > 0 && network.Count > 0)
            {
                int index = random.Next(0, network.Count);
                computersToShutDown.Add(network[index]);
                network.RemoveAt(index);
                count--;
            }

            foreach (Computer comp in computersToShutDown)
            {
                comp.ON = false;
                WriteLog(comp, "Shut down");
            }
        }
        
        // Start all computers
        internal static void StartComputer(List<Computer> network)
        {
            Random random = new Random();

            foreach (Computer comp in network)
            {
                if (!comp.ON)
                {
                    comp.ON = true;
                    WriteLog(comp, "Started");
                    return;
                }
            }

            Console.WriteLine("No turned off computers found.");
        }

        // Start the server
        internal static void StartServer(List<Computer> network)
        {
            foreach (Computer comp in network)
            {
                if (comp.BIOSName == "SERVER" && !comp.ON)
                {
                    comp.ON = true;
                    WriteLog(comp, "Server started");
                    return;
                }
            }

            Console.WriteLine("Server is either already on or not found.");
        }

        internal static void StartComputers(List<Computer> network)
        {
            Console.WriteLine("--- Turning On Computers ---");
            foreach (Computer comp in network)
            {
                if (comp.ON)
                {
                    comp.ON = true;
                    WriteLog(comp, "Started");
                }
            }
        }

        
        // Ping a computer
        internal static void ping(string ip_to, List<Computer> network)
        {
            Random random = new Random();
            int min = 10000;
            int max = 0;
            int time = 0;
            double avg = 0;

            bool found = false;
            for (int i = 0; i < network.Count; i++)
            {
                if (ip_to == network[i].IP)
                {
                    found = true;
                    break;
                }
            }
```
