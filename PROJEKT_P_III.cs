using System;
using System.IO;
using System.Diagnostics;

namespace SystemInfoGrabber
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("POBIERANIE DANYCH O SYSTEMIE");
            Console.WriteLine("");

            //Podstawowe informacje o środowisku
            Console.WriteLine("System");
            Console.WriteLine($"Nazwa komputera: {Environment.MachineName}");
            Console.WriteLine($"Użytkownik: {Environment.UserName}");
            Console.WriteLine($"System operacyjny: {Environment.OSVersion}");
            Console.WriteLine($"Ilość procesorów (logicznych): {Environment.ProcessorCount}");

            //Informacje o dyskach
            Console.WriteLine("\nDyski");
            DriveInfo[] allDrives = DriveInfo.GetDrives();

            foreach (DriveInfo d in allDrives)
            {
                if (d.IsReady)
                {
                    Console.WriteLine($"Dysk {d.Name}");
                    Console.WriteLine($"  Format: {d.DriveFormat}");
                    double freeSpace = d.TotalFreeSpace / (1024.0 * 1024.0 * 1024.0);
                    double totalSpace = d.TotalSize / (1024.0 * 1024.0 * 1024.0);

                    Console.WriteLine($"  Wolne miejsce: {freeSpace:0.00} GB");
                    Console.WriteLine($"  Rozmiar całkowity: {totalSpace:0.00} GB");
                }
            }

            //Uptime (Czas pracy systemu)
            // Environment.TickCount zwraca milisekundy, dzielimy by uzyskać godziny
            TimeSpan uptime = TimeSpan.FromMilliseconds(Environment.TickCount64);
            Console.WriteLine($"\n--- Inne ---");
            Console.WriteLine($"Czas pracy systemu: {uptime.Days} dni, {uptime.Hours} godz, {uptime.Minutes} min");

            Console.WriteLine("\nNaciśnij dowolny klawisz, aby zakończyć...");
            Console.ReadKey();
        }
    }
}
