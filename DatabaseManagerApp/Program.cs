using System;
using System.Net;
using System.Xml.Linq;
using DatabaseManagerApp.TagServiceReference;
using DatabaseManagerApp.UserServiceReference;
using Scada.models;

namespace DatabaseManagerApp
{
    internal class Program
    {
        private static UserServiceReference.UserServiceClient userServiceClient = new UserServiceClient();
        private static TagServiceReference.TagServiceClient tagServiceClient = new TagServiceClient();
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
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
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

                if (tagServiceClient.IsTagNameUnique(tagName))
                {
                    Console.WriteLine("Tag with given name doesn't exist, please try again.");
                    continue;
                }

                TagValue tagValue = tagServiceClient.GetLastTagValue(tagName);

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
                tagServiceClient.UpdateDigitalInputTag(digitalInputTag);
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
                tagServiceClient.UpdateAnalogInputTag(analogInputTag);
                Console.WriteLine(analogInputTag.OnOffScan ? $"Scan toggled on for tag {analogInputTag.Name}" : $"Scan toggled off for tag {analogInputTag.Name}");
            }
        }

        private static void RemoveTag()
        {

            Console.Write("Enter tag name you wish to delete: ");
            string tagName = Console.ReadLine();
            Console.Write("Are you sure you want to delete " + tagName + "? (y/n): ");
            string confirmation = Console.ReadLine();
            if (confirmation == "y") {

                bool successful = tagServiceClient.RemoveTag(tagName);
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

            Console.Write("Enter tag IO address: ");
            string tagIoAddress = Console.ReadLine();

            Console.Write("Enter tag driver [SIM/RT]: ");
            string tagDriver = Console.ReadLine();

            Console.Write("Enter tag scan time (ms): ");
            string tagScanTime = Console.ReadLine();

            Console.Write("Enter tag on/off scan [true/false]: ");
            string tagOnOffScan = Console.ReadLine();

            Console.Write("Enter tag low limit: ");
            string tagLowLimit = Console.ReadLine();

            Console.Write("Enter tag high limit: ");
            string tagHighLimit = Console.ReadLine();

            Console.Write("Enter tag units: ");
            string tagUnits = Console.ReadLine();

            Console.Write("Enter tag alarms [true/false]: ");
            string tagAlarms = Console.ReadLine();

            AnalogInputTag tag = new AnalogInputTag
            {
                Name = tagName,
                Description = tagDescription,
                IoAddress = tagIoAddress,
                Driver = tagDriver,
                ScanTime = int.Parse(tagScanTime),
                OnOffScan = bool.Parse(tagOnOffScan),
                LowLimit = double.Parse(tagLowLimit),
                HighLimit = double.Parse(tagHighLimit),
                Units = tagUnits,
                Alarms = bool.Parse(tagAlarms)
            };

               tagServiceClient.AddAnalogInputTag(tag);
        }

        private static void AddDigitalInputTag()
        {
            string tagName = EnterTagName();

            Console.Write("Enter tag description: ");
            string tagDescription = Console.ReadLine();

            Console.Write("Enter tag driver [SIM/RT]: ");
            string tagDriver = Console.ReadLine();

            Console.Write("Enter tag IO address [R/C/S/IP_Address]: ");
            string tagIoAddress = Console.ReadLine();

            Console.Write("Enter tag scan time (ms): ");
            string tagScanTime = Console.ReadLine();

            Console.Write("Enter tag on/off scan [true/false]: ");
            string tagOnOffScan = Console.ReadLine();

            DigitalInputTag tag = new DigitalInputTag
            {
                Name = tagName,
                Description = tagDescription,
                IoAddress = tagIoAddress,
                Driver = tagDriver,
                ScanTime = int.Parse(tagScanTime),
                OnOffScan = bool.Parse(tagOnOffScan),
            };

            tagServiceClient.AddDigitalInputTag(tag);
        }

        private static void AddAnalogOutputTag()
        {
            string tagName = EnterTagName();

            Console.Write("Enter tag description: ");
            string tagDescription = Console.ReadLine();

            Console.Write("Enter tag IO address [R/C/S/IP_Address]: ");
            string tagIoAddress = Console.ReadLine();

            Console.Write("Enter tag initial value: ");
            string tagInitialValue = Console.ReadLine();

            Console.Write("Enter tag low limit: ");
            string tagLowLimit = Console.ReadLine();

            Console.Write("Enter tag high limit: ");
            string tagHighLimit = Console.ReadLine();

            Console.Write("Enter tag units: ");
            string tagUnits = Console.ReadLine();

            AnalogOutputTag tag = new AnalogOutputTag
            {
                Name = tagName,
                Description = tagDescription,
                IoAddress = tagIoAddress,
                LowLimit = double.Parse(tagLowLimit),
                HighLimit = double.Parse(tagHighLimit),
                Units = tagUnits,
                InitialValue = double.Parse(tagInitialValue)
            };

            tagServiceClient.AddAnalogOutputTag(tag);
        }

        private static void AddDigitalOutputTag()
        {
            string tagName = EnterTagName();

            Console.Write("Enter tag description: ");
            string tagDescription = Console.ReadLine();

            Console.Write("Enter tag IO address [R/C/S/IP_Address]: ");
            string tagIoAddress = Console.ReadLine();

            Console.Write("Enter tag initial value: ");
            string tagInitialValue = Console.ReadLine();

            DigitalOutputTag tag = new DigitalOutputTag
            {
                Name = tagName,
                Description = tagDescription,
                IoAddress = tagIoAddress,
                InitialValue = double.Parse(tagInitialValue)
            };

            tagServiceClient.AddDigitalOutputTag(tag);
        }

        private static string EnterTagName()
        {
            string tagName;
            bool isUnique;

            do
            {
                Console.Write("Enter tag name: ");
                tagName = Console.ReadLine();

                isUnique = tagServiceClient.IsTagNameUnique(tagName);

                if (!isUnique)
                {
                    Console.WriteLine("Tag name already exists. Please enter a unique tag name.");
                }

            } while (!isUnique);

            return tagName;
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

    }
}
