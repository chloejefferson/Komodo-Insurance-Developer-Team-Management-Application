using DevTeamsProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class ProgramUI
    {
        private DeveloperRepo _devRepo = new DeveloperRepo();

        //Run the application
        public void Run()
        {
            SeedDevList();
            Menu();
        }

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Enter the number associated with the menu options below:\n" +
                    "1. Add new developer\n" +
                    "2. View developer directory\n" +
                    "3. Search directory by ID\n" +
                    "4. Update existing developer info\n" +
                    "5. Delete a developer\n" +
                    "6. Exit application");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AddNewDeveloper();
                        break;
                    case "2":
                        ViewDeveloperDirectory();
                        break;
                    case "3":
                        SearchDirectoryByID();
                        break;
                    case "4":
                        UpdateExistingDeveloperInfo();
                        break;
                    case "5":
                        DeleteADeveloper();
                        break;
                    case "6":
                        Console.WriteLine("Thank you for using our application.");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number.");
                        break;
                }
                Console.WriteLine("Please press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private void AddNewDeveloper()
        {
            Console.Clear();
            Developer newDeveloper = new Developer();

            Console.WriteLine("Enter the name of the developer.");
            newDeveloper.Name = Console.ReadLine();

            Console.WriteLine("Enter the ID for the developer.");
            string iDAsString = Console.ReadLine();
            newDeveloper.ID = int.Parse(iDAsString);

            Console.WriteLine("Does the developer have access to Pluralsight? Enter Y for yes and N for no.");
            string hasAccessString = Console.ReadLine().ToLower();

            if(hasAccessString == "y")
            {
                newDeveloper.HasPluralsightAccess = true;
            }
            else if(hasAccessString == "n")
            {
                newDeveloper.HasPluralsightAccess = false;
            }
            else
            {
                newDeveloper.HasPluralsightAccess = false;
                Console.WriteLine("Hmm... I did not recognize your entry. For now, I have marked that the developer does NOT have access to Pluralsight. You can update this information through the main menu later, if needed.");
            }

            _devRepo.AddDeveloperToList(newDeveloper);
        }

        private void ViewDeveloperDirectory()
        {
            Console.Clear();

            List<Developer> listOfDevelopers = _devRepo.GetDevelopersList();

            foreach (Developer developer in listOfDevelopers)
            {
                Console.WriteLine($"ID: {developer.ID}\n" +
                    $"Name: { developer.Name}\n" +
                    $"Pluralsight Access: {developer.HasPluralsightAccess}\n");
            }
        }

        private void SearchDirectoryByID()
        {
            Console.Clear();
            Console.WriteLine("Enter the ID of the developer you'd like to see.");

            string iDAsString = Console.ReadLine();
            int iD = int.Parse(iDAsString);

            Developer developer = _devRepo.GetDeveloperByID(iD);

            if (developer != null)
            {
                Console.WriteLine($"ID: {developer.ID}\n" +
                    $"Name: { developer.Name}\n" +
                    $"Pluralsight Access: {developer.HasPluralsightAccess}");
            }
            else
            {
                Console.WriteLine("No developer found with that ID.");
            }
        }

        private void UpdateExistingDeveloperInfo()
        {
            ViewDeveloperDirectory();
            Console.WriteLine("\n Enter the ID of the developer you'd like to update.");
            string iDString = Console.ReadLine();
            int oldID = int.Parse(iDString);
            //

            Developer newDeveloper = new Developer();

            Console.WriteLine("Enter the updated ID for the developer.");
            string iDAsString = Console.ReadLine();
            newDeveloper.ID = int.Parse(iDAsString);

            Console.WriteLine("Enter the updated name of the developer.");
            newDeveloper.Name = Console.ReadLine();

            Console.WriteLine("Does the developer have access to Pluralsight? Enter Y for yes and N for no.");
            string hasAccessString = Console.ReadLine().ToLower();

            if (hasAccessString == "y")
            {
                newDeveloper.HasPluralsightAccess = true;
            }
            else if (hasAccessString == "n")
            {
                newDeveloper.HasPluralsightAccess = false;
            }
            else
            {
                newDeveloper.HasPluralsightAccess = false;
                Console.WriteLine("Hmm... I did not recognize your entry. For now, I have marked that the developer does NOT have access to Pluralsight. You can update this information through the main menu later, if needed.");
            }

            _devRepo.UpdateDeveloperDirectory(oldID, newDeveloper);

            //Check update
            bool wasUpdated = _devRepo.UpdateDeveloperDirectory(oldID, newDeveloper);

            if (wasUpdated)
            {
                Console.WriteLine("Content successfully updated!");
            }

            else
            {
                Console.WriteLine("Could not update content.");
            }
        }

        private void DeleteADeveloper()
        {
            ViewDeveloperDirectory();
            Console.WriteLine("\n Enter the ID of the developer you'd like to delete.");
            string iDAsString = Console.ReadLine();
            int iD = int.Parse(iDAsString);

            bool wasDeleted = _devRepo.RemoveDeveloperFromDirectory(iD);

            if (wasDeleted)
            {
                Console.WriteLine("The developer was successfully deleted.");
            }
            else
            {
                Console.WriteLine("The developer could not be deleted.");
            }
        }
        private void SeedDevList()
        {
            Developer A = new Developer(111, "John Jacob", true);
            Developer B = new Developer(222, "Allison Smith", false);
            Developer C = new Developer(333, "Melanie Herald", true);

            _devRepo.AddDeveloperToList(A);
            _devRepo.AddDeveloperToList(B);
            _devRepo.AddDeveloperToList(C);
        }
    }
}
