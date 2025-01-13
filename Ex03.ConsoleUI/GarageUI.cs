using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Ex03.GarageLogic;

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
            GarageConsoleUI.PrintWelcome();

            while (!m_ExitFromSystem)
            {
                GarageConsoleUI.PrintMenu();
                MenuOptions.eMenuOptions userInput = getUserInput();
                applyMenuOption(userInput);
                Console.Clear();
            }
        }

        private void applyMenuOption(MenuOptions.eMenuOptions i_UserInput)
        {
            switch (i_UserInput)
            {
                case MenuOptions.eMenuOptions.AddNewCar:
                    //
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
                   resultUserChoice =  (MenuOptions.eMenuOptions)userChoice;
                }
                else
                {
                    throw new ValueOutOfRangeException(1.0f, 8.0f);
                }
            }
            else
            {
                throw new ArgumentException("Invalid input, try again!");
            }

            return resultUserChoice;
        }
    }
}
