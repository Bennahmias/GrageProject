using Ex03.GarageLogic;
using System;
using System.Collections.Generic;

namespace Ex03.ConsoleUI
{
    public class GarageUI
    {
        private Garage m_Garage;
        private bool m_ExitFromSystem;
        private const int k_NoFilter = 0;
        private const bool k_WithFilterOption = true;
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
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        //TODO: what
                    }
                    printReturnToMenu();
                    Console.Clear();
                }
            }
        }
        private void applyMenuOption(MenuOptions.eMenuOptions i_UserInput)
        {
            switch (i_UserInput)
            {
                case MenuOptions.eMenuOptions.AddNewCar:
                    addNewVehicleToTheGarage();
                    break;
                case MenuOptions.eMenuOptions.ShowListOfLicenseNumbers:
                    showListOfLicenseNumbers();
                    break;
                case MenuOptions.eMenuOptions.ChangeVehicleStatus:
                    changeVehicleStatus();
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
            String userInput = Console.ReadLine();
            MenuOptions.eMenuOptions resultUserChoice;
            if (int.TryParse(userInput, out int o_UserChoice))
            {
                if ((o_UserChoice >= MenuOptions.getMinOption()) && (o_UserChoice <= MenuOptions.getMaxOption()))
                {
                    resultUserChoice = (MenuOptions.eMenuOptions)o_UserChoice;
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
                updateDetails(m_Garage.VehicleFilesDict[licenseNumber].Vehicle, vechileType);
                Console.WriteLine("Vehicle added successfully");
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
            if (int.TryParse(vechileTypeChoice, out int o_UserChoice))
            {
                if ((o_UserChoice >= VehicleType.getMinOption()) && (o_UserChoice <= VehicleType.getMaxOption()))
                {
                    resultUserChoice = (VehicleType.eVehicleType)o_UserChoice;
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
                Console.WriteLine("This vehicle is already exist in the garage, and has been updated to in repair status.");
                m_Garage.SetNewStatus(i_LicenseNumber, VehicleStatus.eVehicleStatus.InRepair);
                isInTheGarage = true;
            }

            return isInTheGarage;
        }
        private void updateDetails(Vehicle i_Vehicle, VehicleType.eVehicleType i_VehicleType)
        {
            getVehicleModelName(i_Vehicle);
            getWheelsDetails(i_Vehicle);
            switch (i_VehicleType)
            {
                case VehicleType.eVehicleType.ElectricCar:
                case VehicleType.eVehicleType.GasolineCar:
                    updateDetailsForCar((Car)i_Vehicle);
                    break;
                case VehicleType.eVehicleType.ElectricMotorcycle:
                case VehicleType.eVehicleType.GasolineMotorcycle:
                    updateDetailsForMotorcycle((Motorcycle)i_Vehicle);
                    break;
                case VehicleType.eVehicleType.GasolineTruck:
                    updateDetailsForTruck((Truck)i_Vehicle);
                    break;
            }
            updateEnergy(i_Vehicle);
        }
        private void getVehicleModelName(Vehicle i_Vehicle)
        {
            Console.Write("Please enter car model name: ");
            String modelName = Console.ReadLine();
            if (String.IsNullOrEmpty(modelName))
            {
                throw new ArgumentException("Model name cannot be null or empty.");
            }
            else
            {
                i_Vehicle.ModelName = modelName;
            }
        }
        private void updateDetailsForCar(Car i_Car)
        {
            printColorOptions();
            Color.eColor carColor = getCarColor();
            i_Car.Color = carColor;
            printDoorsOptions();
            DoorsNumber.eDoorsNumber carDoorsNumber = getDoorsNumber();
            i_Car.DoorsNumber = carDoorsNumber;
        }
        private void printColorOptions()
        {
            Console.WriteLine("Please enter car color: ");
            Console.WriteLine("1. Blue");
            Console.WriteLine("2. Black");
            Console.WriteLine("3. Gray");
            Console.WriteLine("4. White");
        }
        private Color.eColor getCarColor()
        {
            String carTypeChoice = Console.ReadLine();
            Color.eColor resultUserChoice;
            if (int.TryParse(carTypeChoice, out int o_UserChoice))
            {
                if ((o_UserChoice >= Color.getMinOption()) && (o_UserChoice <= Color.getMaxOption()))
                {
                    resultUserChoice = (Color.eColor)o_UserChoice;
                }
                else
                {
                    throw new ValueOutOfRangeException(Color.getMinOption(), Color.getMaxOption());
                }
            }
            else
            {
                throw new ArgumentException("Invalid input\n");
            }

            return resultUserChoice;
        }
        private void printDoorsOptions()
        {
            Console.WriteLine("Please enter car's doors number: ");
            Console.WriteLine("1. Two doors");
            Console.WriteLine("2. Three doors");
            Console.WriteLine("3. Four doors");
            Console.WriteLine("4. Five doors");
        }
        private DoorsNumber.eDoorsNumber getDoorsNumber()
        {
            String carDoorChoice = Console.ReadLine();
            DoorsNumber.eDoorsNumber resultUserChoice;
            if (int.TryParse(carDoorChoice, out int o_UserChoice))
            {
                if ((o_UserChoice >= DoorsNumber.getMinOption()) && (o_UserChoice <= DoorsNumber.getMaxOption()))
                {
                    resultUserChoice = (DoorsNumber.eDoorsNumber)o_UserChoice;
                }
                else
                {
                    throw new ValueOutOfRangeException(DoorsNumber.getMinOption(), DoorsNumber.getMaxOption());
                }
            }
            else
            {
                throw new ArgumentException("Invalid input\n");
            }

            return resultUserChoice;
        }
        private void updateDetailsForMotorcycle(Motorcycle i_Motorcycle)
        {
            printMotorcycleLicenseTypeOptions();
            LicenseType.eLicenseType licenseType = getLicenseType();
            i_Motorcycle.LicenseType = licenseType;
            printMotorcycleEngineDisplacement();
            i_Motorcycle.EngineDisplacement = getEngineDisplacement();
        }
        private void printMotorcycleLicenseTypeOptions()
        {
            Console.WriteLine("Please enter motorcycle's license type: ");
            Console.WriteLine("1. A1");
            Console.WriteLine("2. A2");
            Console.WriteLine("3. B1");
            Console.WriteLine("4. B2");
        }
        private LicenseType.eLicenseType getLicenseType()
        {
            String LicenseTypeChoice = Console.ReadLine();
            LicenseType.eLicenseType resultUserChoice;
            if (int.TryParse(LicenseTypeChoice, out int o_UserChoice))
            {
                if ((o_UserChoice >= LicenseType.getMinOption()) && (o_UserChoice <= LicenseType.getMaxOption()))
                {
                    resultUserChoice = (LicenseType.eLicenseType)o_UserChoice;
                }
                else
                {
                    throw new ValueOutOfRangeException(LicenseType.getMinOption(), LicenseType.getMaxOption());
                }
            }
            else
            {
                throw new ArgumentException("Invalid input\n");
            }

            return resultUserChoice;
        }
        private void printMotorcycleEngineDisplacement()
        {
            Console.WriteLine("Please enter motorcycle's engine displacement: ");
        }
        private int getEngineDisplacement()
        {
            String EngineDisplacementChoice = Console.ReadLine();
            if (!int.TryParse(EngineDisplacementChoice, out int o_UserChoice))
            {
                throw new FormatException("Must be an integer.\n");
            }

            return o_UserChoice;
        }
        private void updateDetailsForTruck(Truck i_Truck)
        {
            printTruckTransportingRefrigeratedMaterials();
            i_Truck.TransportingRefrigeratedMaterials = getTransportingRefrigeratedMaterials();
            printCargoVolume();
            i_Truck.CargoVolume = getCargoVolume();
        }
        private bool getTransportingRefrigeratedMaterials()
        {
            String transportingRefrigeratedMaterialsChoice = Console.ReadLine();
            bool resChoice;
            if (transportingRefrigeratedMaterialsChoice.ToUpper() == "Y")
            {
                resChoice = true;
            }
            else if (transportingRefrigeratedMaterialsChoice.ToUpper() == "N")
            {
                resChoice = false;
            }
            else
            {
                throw new FormatException("Must be an Y or N.\n");
            }

            return resChoice;
        }
        private void printTruckTransportingRefrigeratedMaterials()
        {
            Console.WriteLine("Please enter if the truck transporting refrigerated materials (Y/N): ");
        }
        private void printCargoVolume()
        {
            Console.WriteLine("Please enter cargo volume: ");
        }
        private float getCargoVolume()
        {
            String cargoVolume = Console.ReadLine();
            if (!float.TryParse(cargoVolume, out float o_UserChoice))
            {
                throw new FormatException("Must be a float.\n");
            }

            return o_UserChoice;
        }
        private void updateEnergy(Vehicle i_Vehicle)
        {
            if (i_Vehicle.EnergyType is Gasoline)
            {
                Console.Write("Please enter your current fuel amount (liters): ");
            }
            else
            {
                Console.Write("Please enter your current battery amount (hours): ");
            }
            float currentEnergy = getCurrentEenergyAmount();
            i_Vehicle.EnergyType.CurrentCapacity = currentEnergy;
        }
        private float getCurrentEenergyAmount()
        {
            String currentEnergy = Console.ReadLine();
            if (!float.TryParse(currentEnergy, out float o_UserChoice))
            {
                throw new FormatException("Must be a float.\n");
            }

            return o_UserChoice;
        }
        private void getWheelsDetails(Vehicle i_Vehicle)
        {
            String wheelsManufacturerName;
            float whellsCurrentAirPressure;
            Console.Write("Please enter your wheel's manufacturer name: ");
            wheelsManufacturerName = getManufacturerName();
            Console.Write("Please enter your wheel's current air pressure: ");
            whellsCurrentAirPressure = getCurrentAirPressure();
            for (int i = 0; i < i_Vehicle.VehicleWheels.Count; i++)
            {
                i_Vehicle.VehicleWheels[i].CurrentAirPressure = whellsCurrentAirPressure;
                i_Vehicle.VehicleWheels[i].ManufacturerName = wheelsManufacturerName;
            }
        }
        private String getManufacturerName()
        {
            String wheelsManufacturerName = Console.ReadLine();
            if (String.IsNullOrEmpty(wheelsManufacturerName))
            {
                throw new ArgumentException("Manufacturer name cannot be null or empty.");
            }

            return wheelsManufacturerName;
        }
        private float getCurrentAirPressure()
        {
            String wheelsCurrentAiPressure = Console.ReadLine();
            if (!float.TryParse(wheelsCurrentAiPressure, out float o_UserChoice))
            {
                throw new FormatException("Must be a float.\n");
            }

            return o_UserChoice;
        }
        private void showListOfLicenseNumbers()
        {
            printLicenseNumberFilterOptions();
            int filterOption = getStatusOption(k_WithFilterOption);
            List<String> licenseNumbersList;
            if (filterOption == k_NoFilter)
            {
                licenseNumbersList = m_Garage.GetListOfAllLicensesNumbers();
            }
            else
            {
                licenseNumbersList = m_Garage.GetListOfFilteredLicensesNumbers((VehicleStatus.eVehicleStatus)filterOption);
            }
            printLicenseList(licenseNumbersList, filterOption);
        }
        private void printLicenseNumberFilterOptions()
        {
            Console.WriteLine("Enter your filter option: ");
            Console.WriteLine("0. No filter");
            Console.WriteLine("1. In repair vehicles");
            Console.WriteLine("2. Fixed vehicles");
            Console.WriteLine("3. Paid vehicles");
        }
        private int getStatusOption(bool i_WithFilterOption)
        {
            String filterOption = Console.ReadLine();
            int resultUserChoice;
            if (int.TryParse(filterOption, out int o_UserChoice))
            {
                if ((o_UserChoice >= VehicleStatus.getMinOption()) && (o_UserChoice <= VehicleStatus.getMaxOption()))
                {
                    resultUserChoice = o_UserChoice;
                }
                else if (i_WithFilterOption && o_UserChoice == k_NoFilter)
                {
                    resultUserChoice = k_NoFilter;
                }
                else
                {
                    throw new ValueOutOfRangeException(VehicleStatus.getMinOption(), VehicleStatus.getMaxOption());
                }
            }
            else
            {
                throw new ArgumentException("Invalid input\n");
            }

            return resultUserChoice;
        }
        private void printList<T>(List<T> i_List)
        {
            int serialNumber = 1;
            foreach (T item in i_List)
            {
                Console.WriteLine($"{serialNumber++}: {item}");
            }
        }
        private bool isEmptyList<T>(List<T> i_List)
        {
            return i_List.Count == 0;
        }
        private void printLicenseList(List<String> i_LicenseNumbersList, int i_FilterStatus)
        {
            if (isEmptyList(i_LicenseNumbersList))
            {
                if (i_FilterStatus == k_NoFilter)
                {
                    Console.WriteLine("Sorry, there are no vehicles in the garage.");
                }
                else
                {
                    Console.WriteLine($"Sorry, there are no '{(VehicleStatus.eVehicleStatus)i_FilterStatus}' vehicles in the garage.");
                }
            }
            else
            {
                Console.WriteLine("The list of license numbers is:");
                printList(i_LicenseNumbersList);
            }
        }
        private void printReturnToMenu()
        {
            Console.Write("To return to the main menu, please press Enter... ");
            Console.ReadLine();
        }
        private void changeVehicleStatus()
        {
            Console.Write("Please enter license vehicle number: ");
            String licenseNumber = getLicenseNumber();
            if (!m_Garage.VehicleInGarage(licenseNumber))
            {
                printVehicleNotInGarage(licenseNumber);
            }
            else
            {
                updateVehicleStatus(licenseNumber);
            }
        }
        private int getStatusOption()
        {
            String filterOption = Console.ReadLine();
            int resultUserChoice;
            if (int.TryParse(filterOption, out int o_UserChoice))
            {
                if ((o_UserChoice >= VehicleStatus.getMinOption()) && (o_UserChoice <= VehicleStatus.getMaxOption()))
                {
                    resultUserChoice = o_UserChoice;
                }
                else
                {
                    throw new ValueOutOfRangeException(VehicleStatus.getMinOption(), VehicleStatus.getMaxOption());
                }
            }
            else
            {
                throw new ArgumentException("Invalid input\n");
            }

            return resultUserChoice;
        }

        private void printNewStatusOptions()
        {
            Console.WriteLine("Enter your new status option: ");
            Console.WriteLine("1. In repair vehicles");
            Console.WriteLine("2. Fixed vehicles");
            Console.WriteLine("3. Paid vehicles");
        }
        private String getLicenseNumber()
        {
            String licenseNumber = Console.ReadLine();
            if (String.IsNullOrEmpty(licenseNumber))
            {
                throw new ArgumentException("License number cannot be null or empty.");
            }

            return licenseNumber;
        }
        private void updateVehicleStatus(String i_LicenseNumber)
        {
            printNewStatusOptions();
            VehicleStatus.eVehicleStatus statusOption = (VehicleStatus.eVehicleStatus)getStatusOption(!k_WithFilterOption);
            m_Garage.SetNewStatus(i_LicenseNumber, statusOption);
            Console.WriteLine($"The vehicle with license number: {i_LicenseNumber} has been successfully updated to status '{statusOption}'.");
        }
        private void printVehicleNotInGarage(String i_LicenseNumber)
        {
            Console.WriteLine($"The vehicle with license number: {i_LicenseNumber} is not in the garage");
        }
    }
}
