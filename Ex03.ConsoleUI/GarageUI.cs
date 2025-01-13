using Ex03.GarageLogic;
using System;

namespace Ex03.ConsoleUI
{
    public class GarageUI
    {
        private Garage m_Garage;
        private bool m_ExitFromSystem;
        public GarageUI()
        {
            m_Garage = new Garage();
            m_ExitFromSystem = false;
        }
        public void RunGarage()
        {
            bool isValidInput = false;
            GarageConsoleUI.PrintWelcome();

            while (!m_ExitFromSystem)
            {

                GarageConsoleUI.PrintMenu();
                MenuOptions.eMenuOptions userInput = MenuOptions.eMenuOptions.AddNewCar;
                try
                {
                    userInput = getUserInput();
                    isValidInput = true;
                }
                catch (Exception ex) when (ex is ArgumentException || ex is ValueOutOfRangeException)
                {
                    Console.Clear();
                    Console.WriteLine(ex.Message);
                    isValidInput = false;
                }

                if (isValidInput)
                {
                    try
                    {
                        applyMenuOption(userInput);
                        Console.WriteLine(m_Garage.VehicleFilesDict["1234"].OwnerName);
                        Console.WriteLine(m_Garage.VehicleFilesDict["1234"].PhoneNumber);
                        Console.WriteLine(m_Garage.VehicleFilesDict["1234"].Vehicle.ModelName);
                        Console.WriteLine(m_Garage.VehicleFilesDict["1234"].Vehicle.EnergyType.MaxCapacity);
                        Console.WriteLine(m_Garage.VehicleFilesDict["1234"].Vehicle.EnergyType.CurrentCapacity);
                    }
                    catch
                    {

                    }
                    Console.Clear();
                }
            }
        }
        private void applyMenuOption(MenuOptions.eMenuOptions i_UserInput)
        {
            switch (i_UserInput)
            {
                case MenuOptions.eMenuOptions.AddNewCar:
                    // TODO: try and catch, if the vechile exist then change the status - make a new function for this task.
                    addNewVehicleToTheGarage();
                    break;
                case MenuOptions.eMenuOptions.ShowListOfLicenseNumbers:
                    //
                    break;
                case MenuOptions.eMenuOptions.ChangeVehicleStatus:
                    //
                    break;
                case MenuOptions.eMenuOptions.InflateWheelsToMax:
                    //
                    break;
                case MenuOptions.eMenuOptions.RefuelGasolineVehicle:
                    //
                    break;
                case MenuOptions.eMenuOptions.ChargingElectricVehicle:
                    //
                    break;
                case MenuOptions.eMenuOptions.ShowAllVehicleDetails:
                    //
                    break;
                case MenuOptions.eMenuOptions.ExitTheSystem:
                    m_ExitFromSystem = true;
                    break;
            }
        }
        private MenuOptions.eMenuOptions getUserInput()
        {
            string userInput = Console.ReadLine();
            MenuOptions.eMenuOptions resultUserChoice;
            if (int.TryParse(userInput, out int userChoice))
            {
                if ((userChoice >= MenuOptions.getMinOption()) && (userChoice <= MenuOptions.getMaxOption()))
                {
                    resultUserChoice = (MenuOptions.eMenuOptions)userChoice;
                }
                else
                {
                    throw new ValueOutOfRangeException(MenuOptions.getMinOption(), MenuOptions.getMaxOption());
                }
            }
            else
            {
                throw new ArgumentException("Invalid input, must be a number from the menu, try again!\n");
            }

            return resultUserChoice;
        }
        private void addNewVehicleToTheGarage()
        {
            String licenseNumber, ownerName, ownerPhoneNumber;
            VehicleType.eVehicleType vechileType;
            Console.Write("Please enter license vehicle number: ");
            licenseNumber = Console.ReadLine();
            if (!vehicleIsInTheGrage(licenseNumber))
            {
                printVechileTypeMenu();
                vechileType = getVechileType(); // The exception will go up, greate!
                Console.Write("Please enter owner name: ");
                ownerName = Console.ReadLine();
                Console.Write("Please enter owner's phone number: ");
                ownerPhoneNumber = Console.ReadLine();
                m_Garage.AddVehicleToGarage(licenseNumber, vechileType, ownerName, ownerPhoneNumber);
                updateDetails(m_Garage.VehicleFilesDict[licenseNumber]);
            }
        }
        private void printVechileTypeMenu()
        {
            Console.WriteLine("Please enter car type:");
            Console.WriteLine("1. Electric car");
            Console.WriteLine("2. Gasoline car");
            Console.WriteLine("3. Electric motorcycle");
            Console.WriteLine("4. Gasoline motorcycle");
            Console.WriteLine("5. Gasoline truck");
        }
        private VehicleType.eVehicleType getVechileType()
        {
            String vechileTypeChoice = Console.ReadLine();
            VehicleType.eVehicleType resultUserChoice;
            if (int.TryParse(vechileTypeChoice, out int userChoice))
            {
                if ((userChoice >= VehicleType.getMinOption()) && (userChoice <= VehicleType.getMaxOption()))
                {
                    resultUserChoice = (VehicleType.eVehicleType)userChoice;
                }
                else
                {
                    throw new ValueOutOfRangeException(VehicleType.getMinOption(), VehicleType.getMaxOption());
                }
            }
            else
            {
                throw new ArgumentException("Invalid input\n");
            }

            return resultUserChoice;
        }
        private bool vehicleIsInTheGrage(String i_LicenseNumber)
        {
            bool isInTheGarage = false;
            if (m_Garage.VehicleInGarage(i_LicenseNumber))
            {
                Console.WriteLine("This vehicle is already exist in the garage.");
                m_Garage.SetNewStatus(i_LicenseNumber, VehicleStatus.eVehicleStatus.InRepair);
                isInTheGarage = true;
            }

            return isInTheGarage;
        }
        private void updateDetails()
        {

        }
    }
}
