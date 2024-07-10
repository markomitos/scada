using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReportManagerApp.ReportServiceReference;

namespace ReportManagerApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (ReportServiceClient client = new ReportServiceClient())
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("SCADA Reports - Main Menu");
                    Console.WriteLine(
                        "1. All alarms which happened in a given time frame (sorted by time and priority)");
                    Console.WriteLine("2. All alarms with a given priority (sorted by time)");
                    Console.WriteLine(
                        "3. All tag values which were recorded in a given time frame (sorted by time)");
                    Console.WriteLine("4. Latest value of all AI tags (sorted by time)");
                    Console.WriteLine("5. Latest value of all DI tags (sorted by time)");
                    Console.WriteLine("6. All values of a tag with a specific id (sorted by value)");
                    Console.WriteLine("7. Exit");
                    Console.Write("Select an option: ");

                    string input = Console.ReadLine();

                    switch (input)
                    {
                        case "1":
                            GetTimePeriod(out DateTime startTime, out DateTime endTime);
                            GetSortingAttribute(out bool sortByPriority);
                            Console.Write(client.ShowAllAlarmsInTimePeriod(startTime, endTime, sortByPriority));
                            break;
                        case "2":
                            int priority = GetPriority();
                            Console.Write(client.ShowAlarmsByPriority(priority));
                            break;
                        case "3":
                            GetTimePeriod(out startTime, out endTime);
                            Console.Write(client.ShowTagValuesInTimePeriod(startTime, endTime));
                            break;
                        case "4":
                            Console.Write(client.ShowLastValuesOfAITags());
                            break;
                        case "5":
                            Console.Write(client.ShowLastValuesOfDITags());
                            break;
                        case "6":
                            string tagId = GetTagId();
                            Console.Write(client.ShowValuesOfTagById(tagId));
                            break;
                        case "7":
                            return;
                        default:
                            Console.WriteLine("Invalid option. Please try again.");
                            break;
                    }

                    Console.WriteLine("Press any key to return to the main menu...");
                    Console.ReadKey();
                }
            }
        }

        static void GetTimePeriod(out DateTime startTime, out DateTime endTime)
        {
            while (true)
            {
                Console.Write("Enter start time (yyyy-mm-dd hh:mm:ss): ");
                if (DateTime.TryParse(Console.ReadLine(), out startTime))
                {
                    Console.Write("Enter end time (yyyy-mm-dd hh:mm:ss): ");
                    if (DateTime.TryParse(Console.ReadLine(), out endTime))
                    {
                        if (endTime > startTime)
                        {
                            return;
                        }
                        else
                        {
                            Console.WriteLine("End time must be after start time. Please try again.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid end time format. Please try again.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid start time format. Please try again.");
                }
            }
        }

        public static void GetSortingAttribute(out bool sortByPriority)
        {
            Console.Write("Do you want to sort by priority? (yes/no): ");
            string input = Console.ReadLine().Trim().ToLower();

            while (input != "yes" && input != "no")
            {
                Console.Write("Invalid input. Please enter 'yes' or 'no': ");
                input = Console.ReadLine().Trim().ToLower();
            }

            sortByPriority = input == "yes";
        }

        static int GetPriority()
        {
            while (true)
            {
                Console.Write("Enter priority: ");
                if (int.TryParse(Console.ReadLine(), out int priority) && priority >= 0)
                {
                    return priority;
                }
                else
                {
                    Console.WriteLine("Invalid priority. Please enter a non-negative integer.");
                }
            }
        }

        static string GetTagId()
        {
            while (true)
            {
                Console.Write("Enter tag identifier: ");
                string tagId = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(tagId))
                {
                    return tagId.Trim();
                }
                else
                {
                    Console.WriteLine("Invalid tag identifier. Please enter a non-empty string.");
                }
            }
        }
    }
}

