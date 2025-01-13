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
                    addNewCarGetInput();
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
                if ((userChoice >= 1) && (userChoice <= 8))
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
        private void addNewCarGetInput()
        {
            String licenseNumber;
            Console.Write("Please enter license car number: ");
            licenseNumber = Console.ReadLine();

        }
    }
}
