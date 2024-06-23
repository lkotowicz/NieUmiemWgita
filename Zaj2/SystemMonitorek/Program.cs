using System;
using System.Diagnostics;
using System.Threading;

namespace SystemMonitor
{
    class Program
    {
        private const string EventLogSource = "SystemMonitor";
        private const string EventLogName = "Application";
        private const int MemoryThreshold = 8; // Procentowy próg zużycia pamięci
        private const int CPULoadThreshold = 10; // Procentowy próg obciążenia CPU

        static void Main(string[] args)
        {
            // Utwórz źródło zdarzeń, jeśli nie istnieje
            if (!EventLog.SourceExists(EventLogSource))
            {
                EventLog.CreateEventSource(EventLogSource, EventLogName);
            }

            // Rozpocznij monitorowanie
            MonitorSystem();
        }

        static void MonitorSystem()
        {
            // Pętla monitorowania
            while (true)
            {
                // Sprawdź zużycie pamięci
                PerformanceCounter memoryCounter = new PerformanceCounter("Memory", "Available MBytes");
                float availableMemory = memoryCounter.NextValue();
                float totalMemory = new Microsoft.VisualBasic.Devices.ComputerInfo().TotalPhysicalMemory / (1024 * 1024);
                float memoryUsagePercentage = ((totalMemory - availableMemory) / totalMemory) * 100;

                // Sprawdź obciążenie CPU
                PerformanceCounter cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
                float cpuUsage = cpuCounter.NextValue();

                // Zapisz zdarzenie, jeśli przekroczono progi
                if (memoryUsagePercentage > MemoryThreshold)
                {
                    LogEvent($"Za dużo pamięci jest obecnie w użyciu,\n oczekiwane:{MemoryThreshold}%, obecnie : {memoryUsagePercentage}%");
                }

                if (cpuUsage < CPULoadThreshold)
                {
                    LogEvent($"Obciążenie CPU mniejsze {CPULoadThreshold}%, aktualnie: {cpuUsage}%");
                }

                // Poczekaj przed kolejnym sprawdzeniem
                Thread.Sleep(5000); // Co 5 sekund
            }
        }

        static void LogEvent(string message)
        {
            EventLog.WriteEntry(EventLogSource, message, EventLogEntryType.Warning);
            Console.WriteLine($"[EVENT] {message}");
        }
    }
}
