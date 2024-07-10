using System;
using System.Net;
using System.ServiceModel;
using System.Xml.Linq;
using DatabaseManagerApp.AlarmServiceReference;
using DatabaseManagerApp.TagServiceReference;
using DatabaseManagerApp.UserServiceReference;
using Scada.models;

namespace DatabaseManagerApp
{
    public class TagProcessingCallback : ITagServiceCallback
    {
        public void NotifyValueChanged(TagValue inputTag)
        {
        }
    }

    internal class Program
    {
        private static UserServiceReference.UserServiceClient userServiceClient = new UserServiceClient();
        private static TagServiceReference.TagServiceClient tagServiceClient = new TagServiceClient(new InstanceContext(new TagProcessingCallback()));
        private static AlarmServiceReference.AlarmServiceClient alarmServiceClient = new AlarmServiceReference.AlarmServiceClient();
        private static string currentToken = null;

        static void Main(string[] args)
        {
            tagServiceClient.Hello();
            while (true)
            {
                Console.Clear();
                if (currentToken == null)
                {
                    ShowMainMenu();
                }
                else
                {
                    ShowLoggedInMenu();
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }

        private static void ShowMainMenu()
        {
            Console.WriteLine("SCADA System - User Management");
            Console.WriteLine("1. Register");
            Console.WriteLine("2. Login");
            Console.WriteLine("3. Exit");
            Console.Write("Select an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    RegisterUser();
                    break;
                case "2":
                    LoginUser();
                    break;
                case "3":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }

        private static void ShowLoggedInMenu()
        {
            Console.WriteLine("SCADA System - User Management (Logged In)");
            Console.WriteLine($"Current Token: {currentToken}");
            Console.WriteLine("1. Add tag");
            Console.WriteLine("2. Remove tag");
            Console.WriteLine("3. Logout");
            Console.WriteLine("4. Toggle scan");
            Console.WriteLine("5. Get output value");
            Console.WriteLine("6. Change output value");
            Console.WriteLine("7. Add alarm");
            Console.WriteLine("8. View all alarms");
            Console.WriteLine("9. Remove alarms");
            Console.Write("Select an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddTagMenu();
                    break;
                case "2":
                    RemoveTag();
                    break;
                case "3":
                    LogoutUser();
                    break;
                case "4":
                    ToggleScan();
                    break;
                case "5":
                    GetOutputValue();
                    break;
                case "6":
                    ChangeOutputValue();
                    break;
                case "7":
                    AddAlarm();
                    break;
                case "8":
                    ViewAllAlarms();
                    break;
                case "9":
                    RemoveAlarms();
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }

        private static void RemoveAlarms()
        {
            Console.Write("Enter Alarm Name to remove or 'x' to go back: ");
            string alarmName = Console.ReadLine();

            if (alarmName.ToLower().Equals("x")) return;

            if (alarmServiceClient.RemoveAlarm(currentToken, alarmName))
            {
                Console.WriteLine("Successfully deleted alarm...");
                return;
            }
            Console.WriteLine("Unsuccessfully deleted alarm...");
        }

        private static void ChangeOutputValue()
        {
            String IoAddress = null;
            Scada.models.ValueType valueType = 0;

            while (true)
            {
                Console.Write("Enter Tag Name or 'x' to go back: ");
                string tagName = Console.ReadLine();

                if (tagName.ToLower().Equals("x"))
                {
                    return;
                }

                AnalogInputTag aitag = tagServiceClient.GetAnalogInputTag(tagName);
                if (aitag != null)
                {
                    IoAddress = aitag.IoAddress;
                    valueType = Scada.models.ValueType.ANALOG;
                }

                DigitalInputTag ditag = tagServiceClient.GetDigitalInputTag(tagName);
                if (ditag != null)
                {
                    IoAddress = ditag.IoAddress;
                    valueType = Scada.models.ValueType.DIGITAL;
                }

                if (aitag == null && ditag == null)
                {
                    Console.WriteLine("Tag with given name doesn't exist, please try again.");
                    continue;
                }


                Console.Write("Enter a value: ");
                int value;

                if (valueType == Scada.models.ValueType.DIGITAL)
                {
                    Console.Write("Enter a value (0|1): ");
                    while (!int.TryParse(Console.ReadLine(), out value) || (value != 0 && value != 1))
                    {
                        Console.Write("Invalid input. Please enter valid int for a value: ");
                    }
                }
                else
                {
                    Console.Write("Enter a value: ");
                    while (!int.TryParse(Console.ReadLine(), out value))
                    {
                        Console.Write("Invalid input. Please enter valid int for a value: ");
                    }
                }

                tagServiceClient.AddTagValue(new TagValue(IoAddress, tagName, value, valueType));

                Console.Write("\nValue Changed");
            }
        }

        private static void GetOutputValue()
        {
            while (true)
            {
                Console.Write("Enter Tag Name or 'x' to go back: ");
                string tagName = Console.ReadLine();

                if (tagName.ToLower().Equals("x"))
                {
                    return;
                }

                if (tagServiceClient.IsTagNameUnique(currentToken, tagName))
                {
                    Console.WriteLine("Tag with given name doesn't exist, please try again.");
                    continue;
                }

                TagValue tagValue = tagServiceClient.GetLastTagValue(currentToken, tagName);

                Console.WriteLine(@"Tag: {0}, Value: {1}, Type: {2}", tagValue.TagName, tagValue.Value, tagValue.ValueType);
            }
        }

        private static void ToggleScan()
        {
            Console.Write("Enter tag name: ");
            string tagName = Console.ReadLine();
            AnalogInputTag analogInputTag = tagServiceClient.GetAnalogInputTag(tagName);

            if (analogInputTag != null)
            {
                toggleAnalogScan(analogInputTag);
                return;
            }

            DigitalInputTag digitalInputTag = tagServiceClient.GetDigitalInputTag(tagName);
            if (digitalInputTag != null)
            {
                toggleDigitalScan(digitalInputTag);
                return;
            }

            Console.WriteLine($"Tag {tagName} doesn't exist.");
        }

        private static void toggleDigitalScan(DigitalInputTag digitalInputTag)
        {
            Console.Write(digitalInputTag.OnOffScan ? $"Are you sure you want to toggle scan off for tag {digitalInputTag.Name} (y/n): " : $"Are you sure you want to toggle scan on for tag {digitalInputTag.Name} (y/n): ");
            string confirmation = Console.ReadLine();

            if (confirmation.ToLower().Equals("y"))
            {
                digitalInputTag.OnOffScan = !digitalInputTag.OnOffScan;
                tagServiceClient.UpdateDigitalInputTag(currentToken, digitalInputTag);
                Console.WriteLine(digitalInputTag.OnOffScan ? $"Scan toggled on for tag {digitalInputTag.Name}" : $"Scan toggled off for tag {digitalInputTag.Name}");
            }
        }

        private static void toggleAnalogScan(AnalogInputTag analogInputTag)
        {
            Console.Write(analogInputTag.OnOffScan ? $"Are you sure you want to toggle scan off for tag {analogInputTag.Name} (y/n): " : $"Are you sure you want to toggle scan on for tag {analogInputTag.Name} (y/n): ");
            string confirmation = Console.ReadLine();

            if (confirmation.ToLower().Equals("y"))
            {
                analogInputTag.OnOffScan = !analogInputTag.OnOffScan;
                tagServiceClient.UpdateAnalogInputTag(currentToken, analogInputTag);
                Console.WriteLine(analogInputTag.OnOffScan ? $"Scan toggled on for tag {analogInputTag.Name}" : $"Scan toggled off for tag {analogInputTag.Name}");
            }
        }

        private static void RemoveTag()
        {

            Console.Write("Enter tag name you wish to delete: ");
            string tagName = Console.ReadLine();
            Console.Write("Are you sure you want to delete " + tagName + "? (y/n): ");
            string confirmation = Console.ReadLine();
            if (confirmation == "y")
            {

                bool successful = tagServiceClient.RemoveTag(currentToken, tagName);
                Console.WriteLine(successful ? "Delete successful" : "Error: tag " + tagName + " doesn't exist.");
            }
        }

        private static void AddTagMenu()
        {
            Console.WriteLine("1. Add analog input tag");
            Console.WriteLine("2. Add digital input tag");
            Console.WriteLine("3. Add analog output tag");
            Console.WriteLine("4. Add adigital output tag");
            Console.WriteLine("5. Exit");
            Console.Write("Select an option: ");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    AddAnalogInputTag();
                    break;
                case "2":
                    AddDigitalInputTag();
                    break;
                case "3":
                    AddAnalogOutputTag();
                    break;
                case "4":
                    AddDigitalOutputTag();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }

        private static void AddAnalogInputTag()
        {
            string tagName = EnterTagName();

            Console.Write("Enter tag description: ");
            string tagDescription = Console.ReadLine();

            string tagDriver = EnterTagDriver();

            string tagIoAddress = EnterTagIoAddress(tagDriver);

            int tagScanTime = EnterTagScanTime();

            bool tagOnOffScan = EnterTagOnOffScan();

            double tagLowLimit = EnterTagLimit("low");

            double tagHighLimit = EnterTagLimit("high");

            Console.Write("Enter tag units: ");
            string tagUnits = Console.ReadLine();

            bool tagAlarms = EnterTagAlarms();

            AnalogInputTag tag = new AnalogInputTag
            {
                Name = tagName,
                Description = tagDescription,
                IoAddress = tagIoAddress,
                Driver = tagDriver,
                ScanTime = tagScanTime,
                OnOffScan = tagOnOffScan,
                LowLimit = tagLowLimit,
                HighLimit = tagHighLimit,
                Units = tagUnits,
                Alarms = tagAlarms
            };

            tagServiceClient.AddAnalogInputTag(currentToken, tag);
        }

        private static void AddDigitalInputTag()
        {
            string tagName = EnterTagName();

            Console.Write("Enter tag description: ");
            string tagDescription = Console.ReadLine();

            string tagDriver = EnterTagDriver();

            string tagIoAddress = EnterTagIoAddress(tagDriver);

            int tagScanTime = EnterTagScanTime();

            bool tagOnOffScan = EnterTagOnOffScan();

            DigitalInputTag tag = new DigitalInputTag
            {
                Name = tagName,
                Description = tagDescription,
                IoAddress = tagIoAddress,
                Driver = tagDriver,
                ScanTime = tagScanTime,
                OnOffScan = tagOnOffScan,
            };

            tagServiceClient.AddDigitalInputTag(currentToken, tag);
        }

        private static void AddAnalogOutputTag()
        {
            string tagName = EnterTagName();

            Console.Write("Enter tag description: ");
            string tagDescription = Console.ReadLine();

            Console.Write("Enter tag IO address (SIM: 'R'/'C'/'S'/): ");
            string tagIoAddress = Console.ReadLine();

            double tagInitialValue = EnterTagInitialValue();

            double tagLowLimit = EnterTagLimit("low");

            double tagHighLimit = EnterTagLimit("high");

            Console.Write("Enter tag units: ");
            string tagUnits = Console.ReadLine();

            AnalogOutputTag tag = new AnalogOutputTag
            {
                Name = tagName,
                Description = tagDescription,
                IoAddress = tagIoAddress,
                LowLimit = tagLowLimit,
                HighLimit = tagHighLimit,
                Units = tagUnits,
                InitialValue = tagInitialValue
            };

            tagServiceClient.AddAnalogOutputTag(currentToken, tag);
        }

        private static void AddDigitalOutputTag()
        {
            string tagName = EnterTagName();

            Console.Write("Enter tag description: ");
            string tagDescription = Console.ReadLine();

            Console.Write("Enter tag IO address [R/C/S/IP_Address]: ");
            string tagIoAddress = Console.ReadLine();

            double tagInitialValue = EnterTagInitialValue();

            DigitalOutputTag tag = new DigitalOutputTag
            {
                Name = tagName,
                Description = tagDescription,
                IoAddress = tagIoAddress,
                InitialValue = tagInitialValue
            };

            tagServiceClient.AddDigitalOutputTag(currentToken, tag);
        }

        private static string EnterTagName()
        {
            string tagName;
            bool isUnique;

            do
            {
                Console.Write("Enter tag name: ");
                tagName = Console.ReadLine();

                isUnique = tagServiceClient.IsTagNameUnique(currentToken, tagName);

                if (!isUnique)
                {
                    Console.WriteLine("Tag name already exists. Please enter a unique tag name.");
                }

            } while (!isUnique);

            return tagName;
        }

        private static string EnterTagDriver()
        {
            string tagDriver;
            while (true)
            {
                Console.Write("Enter tag driver [SIM/RTD]: ");
                tagDriver = Console.ReadLine().ToUpper();
                if (tagDriver == "SIM" || tagDriver == "RTD")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Driver must be SIM or RTD.");
                }
            }
            return tagDriver;
        }

        private static string EnterTagIoAddress(string tagDriver)
        {
            string tagIoAddress;
            while (true)
            {
                Console.Write("Enter tag IO address (SIM: 'R'/'C'/'S'/): ");
                tagIoAddress = Console.ReadLine().ToUpper();
                if (tagDriver == "SIM")
                {
                    if (tagIoAddress == "R" || tagIoAddress == "C" || tagIoAddress == "S")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. IO address must be R, C, or S when driver is SIM.");
                    }
                }
                else
                {
                    break;
                }
            }
            return tagIoAddress;
        }

        private static int EnterTagScanTime()
        {
            int tagScanTime;
            while (true)
            {
                Console.Write("Enter tag scan time (ms): ");
                if (int.TryParse(Console.ReadLine(), out tagScanTime) && tagScanTime > 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Scan time must be a positive number.");
                }
            }
            return tagScanTime;
        }

        private static bool EnterTagOnOffScan()
        {
            bool tagOnOffScan;
            while (true)
            {
                Console.Write("Enter tag on/off scan [true/false]: ");
                if (bool.TryParse(Console.ReadLine(), out tagOnOffScan))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. On/Off scan must be true or false.");
                }
            }
            return tagOnOffScan;
        }

        private static double EnterTagLimit(string limitType)
        {
            double tagLimit;
            while (true)
            {
                Console.Write($"Enter tag {limitType} limit: ");
                if (double.TryParse(Console.ReadLine(), out tagLimit))
                {
                    break;
                }
                else
                {
                    Console.WriteLine($"Invalid input. {limitType} limit must be a number.");
                }
            }
            return tagLimit;
        }

        private static double EnterTagInitialValue()
        {
            double tagInitialValue;
            while (true)
            {
                Console.Write("Enter tag initial value: ");
                if (double.TryParse(Console.ReadLine(), out tagInitialValue))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Initial value must be a number.");
                }
            }
            return tagInitialValue;
        }

        private static bool EnterTagAlarms()
        {
            bool tagAlarms;
            while (true)
            {
                Console.Write("Enter tag alarms [true/false]: ");
                if (bool.TryParse(Console.ReadLine(), out tagAlarms))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Alarms must be true or false.");
                }
            }
            return tagAlarms;
        }


        private static void RegisterUser()
        {
            Console.Write("Enter username: ");
            string username = Console.ReadLine();
            Console.Write("Enter password: ");
            string password = Console.ReadLine();

            bool result = userServiceClient.RegisterUser(username, password);

            if (result)
            {
                Console.WriteLine("User registered successfully.");
            }
            else
            {
                Console.WriteLine("User registration failed.");
            }
        }

        private static void LoginUser()
        {
            Console.Write("Enter username: ");
            string username = Console.ReadLine();
            Console.Write("Enter password: ");
            string password = Console.ReadLine();

            string token = userServiceClient.LogInUser(username, password);

            if (token != "Login failed")
            {
                currentToken = token;
                Console.WriteLine("Login successful. Token: " + token);
            }
            else
            {
                Console.WriteLine("Login failed.");
            }
        }

        private static void LogoutUser()
        {
            if (currentToken == null)
            {
                Console.WriteLine("No user is currently logged in.");
                return;
            }

            bool result = userServiceClient.Logout(currentToken);

            if (result)
            {
                currentToken = null;
                Console.WriteLine("Logout successful.");
            }
            else
            {
                Console.WriteLine("Logout failed.");
            }
        }

        private static void ViewAllAlarms()
        {
            alarmServiceClient.GetAllAlarms();
            foreach (Alarm alarm in alarmServiceClient.GetAllAlarms())
            {
                Console.WriteLine(alarm.ToString());
            }
        }

        private static void AddAlarm()
        {
            Console.Write("Enter alarm name: ");
            string alarmName = Console.ReadLine();

            Console.Write("Enter alarm type (LOW/HIGH): ");
            string alarmTypeInput = Console.ReadLine();
            AlarmType alarmType;
            while (!Enum.TryParse(alarmTypeInput, true, out alarmType) || !Enum.IsDefined(typeof(AlarmType), alarmType))
            {
                Console.Write("Invalid alarm type. Please enter LOW or HIGH: ");
                alarmTypeInput = Console.ReadLine();
            }

            int alarmPriority = 0;
            while (alarmPriority < 1 || alarmPriority > 3)
            {
                Console.Write("Priority must be between 1-3. Enter alarm priority: ");
                string alarmPriorityInput = Console.ReadLine();

                while (!int.TryParse(alarmPriorityInput, out alarmPriority))
                {
                    Console.Write("Invalid input. Please enter a valid integer for alarm priority: ");
                    alarmPriorityInput = Console.ReadLine();
                }
            }

            Console.Write("Enter alarm threshold: ");
            string alarmThresholdInput = Console.ReadLine();
            double alarmThreshold;
            while (!double.TryParse(alarmThresholdInput, out alarmThreshold))
            {
                Console.Write("Invalid input. Please enter a valid number for alarm threshold: ");
                alarmThresholdInput = Console.ReadLine();
            }

            Console.Write("Enter alarm unit: ");
            string alarmUnit = Console.ReadLine();

            Console.Write("Enter tag name: ");
            string tagName = Console.ReadLine();


            Alarm alarm = new Alarm
            {
                Name = alarmName,
                Type = alarmType,
                Priority = alarmPriority,
                Threshold = alarmThreshold,
                Unit = alarmUnit,
                TagName = tagName
            };

            alarmServiceClient.AddAlarm(currentToken, alarm);
        }


    }
}
