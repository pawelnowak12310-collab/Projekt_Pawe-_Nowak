                float cpuUsage = cpuCounter.NextValue();
                ulong totalRam = computerInfo.TotalPhysicalMemory;
                ulong availableRam = computerInfo.AvailablePhysicalMemory;
                ulong usedRam = totalRam - availableRam;

                Console.Clear();
                Console.WriteLine("MONITOR ZUŻYCIA ZASOBÓW\n");

                Console.WriteLine($"CPU: {cpuUsage:F1} %");
                Console.WriteLine($"RAM użyty: {FormatBytes(usedRam)}");
                Console.WriteLine($"RAM dostępny: {FormatBytes(availableRam)}");
                Console.WriteLine($"RAM całkowity: {FormatBytes(totalRam)}");

                Console.WriteLine("\nOdświeżanie co 1 sekundę...");
                Thread.Sleep(1000);

