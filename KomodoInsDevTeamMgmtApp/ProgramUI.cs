using KomodoClasses.POCO;
using KomodoClasses.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsDevTeamMgmtApp
{
    class ProgramUI
    {

        private DeveloperRepo _devRepo = new DeveloperRepo();
        private DevTeamRepo _teamRepo = new DevTeamRepo();

        public void Run()
        {
            Menu();
        }

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Welcome to Komodo Team and Developer Management App\n" +
                    "Please select a menu option:\n" +
                    "1. View All Developers\n" +
                    "2. Add A New Developer\n" +
                    "3. View All Developer Teams\n" +
                    "4. Create Developer Team\n" +
                    "5. Exit");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        DisplayAllDevelopers();
                        break;
                    case "2":
                        CreateNewDeveloper();
                        break;
                    case "3":
                        DisplayDeveloperTeams();
                        break;
                    case "4":
                        CreateNewTeam();
                        break;
                    case "5":
                        Console.WriteLine("Thank you for visiting!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number.");
                        break;
                }

                Console.WriteLine("Press any key to continiue.");
                Console.ReadKey();
                Console.Clear();
            }
        }
        private void DisplayAllDevelopers()
        {
            Console.Clear();
            List<Developer> listOfDevelopers = _devRepo.GetDeveloperList();
            if (listOfDevelopers?.Any() != true)
            {
                Console.WriteLine("There are currently no developers in the directory\n" +
                    "--------------------------------------");
            }
            else
            {
                foreach (Developer developer in listOfDevelopers)
                {
                    Console.WriteLine("----------------------\n" +
                        $"ID#: {developer.DevID}\n" +
                        $"Name: {developer.FirstName} {developer.LastName}\n" +
                        $"Access to Pluralsight?: {developer.Pluralsight}");
                }
            }
        }

        private void CreateNewDeveloper()
        {
            Console.Clear();

            Developer newDeveloper = new Developer();

            Console.WriteLine("Enter your new developer's first name:");
            newDeveloper.FirstName = Console.ReadLine();

            Console.WriteLine("Enter your new developer's last name:");
            newDeveloper.LastName = Console.ReadLine();

            Console.WriteLine("Enter their ID#:");
            newDeveloper.DevID = int.Parse(Console.ReadLine());

            Console.WriteLine("Do they have access to Pluralsight? (y/n):");
            string pluralSightString = Console.ReadLine();

            if (pluralSightString == "y")
            {
                newDeveloper.Pluralsight = true;
            }
            else
            {
                newDeveloper.Pluralsight = false;
            }

            _devRepo.AddDeveloperToList(newDeveloper);

            Console.Clear();
            Console.WriteLine("New Developer Info:\n" +
                "-------------------------------\n" +
                $"First Name: {newDeveloper.FirstName}\n" +
                $"Last Name: {newDeveloper.LastName}\n" +
                $"ID#: {newDeveloper.DevID}\n" +
                $"Has Pluralsight Access?: {newDeveloper.Pluralsight}\n" +
                $"-------------------------------");
        }

        private void DisplayDeveloperTeams()
        {
            Console.Clear();
            List<DevTeam> listOfDevTeams = _teamRepo.GetTeamList();

            if (listOfDevTeams?.Any() != true)
            {
                Console.WriteLine("There are currently no developer teams.\n" +
                    "-----------------------------");
            }
            else
            {
                foreach (DevTeam devTeam in listOfDevTeams)
                {
                    Console.WriteLine("--------------------\n" +
                        $"Team ID# {devTeam.TeamID}\n" +
                        $"Team Name: {devTeam.TeamName}");
                }
                Console.WriteLine("------------------------\n" +
                    "Enter the ID# of the team you would like to see details of");
                int teamID = int.Parse(Console.ReadLine());

                DevTeam devTeamID = _teamRepo.GetTeamByID(teamID);
                {
                    if (teamID != null)
                    {
                        Console.WriteLine($"Team ID# {devTeamID.TeamID}\n" +
                                            $"Team Name: {devTeamID.TeamName}\n" +
                                            $"Team Members: {devTeamID._developerList}");
                        AddToTeam();
                    }
                    else
                    {
                        Console.WriteLine("There is no developer team with that ID#");
                    }
                }
            }
        }
        private void CreateNewTeam()
        {
            Console.Clear();

            DevTeam newTeam = new DevTeam();

            Console.WriteLine("What will the the new team's ID# be?:");
            newTeam.TeamID = int.Parse(Console.ReadLine());

            Console.WriteLine("What will the new team's name be?:");
            newTeam.TeamName = Console.ReadLine();

            _teamRepo.AddDeveloperTeam(newTeam);


            AddToTeam();
        }

        private void AddToTeam() {

            Console.WriteLine("Would you like to add a member to this team? (y/n)");
            string newMember = Console.ReadLine();

            if (newMember == "y")
            {
                Console.WriteLine("Here is the current developer directory:");
                Console.WriteLine("----------------------------------------");

                DisplayAllDevelopers();

                Console.WriteLine("----------------------------------------");
                Console.WriteLine("What is the ID# of the developer you would like to add to the team?");
                int devID = int.Parse(Console.ReadLine());

                Developer developer = _devRepo.GetDeveloperByID(devID);

                if (devID != null)
                {
                    Console.WriteLine($"ID# {developer.DevID}\n" +
                                        $"Name: {developer.FirstName} {developer.LastName}\n" +
                                        $"Access to Pluralsight?: {developer.Pluralsight}");
                    _devRepo.AddDeveloperToList(developer);
                }
                else
                {
                    Console.WriteLine("There is no developer with that ID#.");
                }
            }
            else
            {
                Console.WriteLine("Thank you for visiting!");
            }
        }
    }
}

