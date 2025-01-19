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

            printWelcome();
            while (!m_ExitFromSystem)
            {
                printMenu();
                MenuOptions.eMenuOptions io_UserInput = MenuOptions.eMenuOptions.InitializeInput;

                isValidInput = tryGetUserInput(ref io_UserInput);
                if (isValidInput)
                {
                    try
                    {
                        applyMenuOption(io_UserInput);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    printReturnToMenu(m_ExitFromSystem);
                    Console.Clear();
                }
            }
        }

        private bool tryGetUserInput(ref MenuOptions.eMenuOptions io_UserInput)
        {
            bool isValidInput;

            try
            {
                io_UserInput = getUserInput();
                isValidInput = true;
            }
            catch (Exception ex) when (ex is ArgumentException || ex is ValueOutOfRangeException)
            {
                Console.Clear();
                Console.WriteLine(ex.Message);
                isValidInput = false;
            }

            return isValidInput;
        }

        private static void printWelcome()
        {
            Console.WriteLine("Welcome to the Garage System!\nPress Enter to see the menu");
            Console.ReadLine();
            Console.Clear();
        }

        private static void printMenu()
        {
            Console.WriteLine("==== Garage Menu ====");
            Console.WriteLine("1. Add a New Vehicle");
            Console.WriteLine("2. Show License Numbers Of Vehicles In The Garage");
            Console.WriteLine("3. Change Vehicle Status");
            Console.WriteLine("4. Inflate Wheels To Maximum");
            Console.WriteLine("5. Refuel a Gasoline Vehicle");
            Console.WriteLine("6. Charging an Electric Vehicle");
            Console.WriteLine("7. Show Vehicle Details");
            Console.WriteLine("8. Exit The System");
            Console.Write("Please select an option: ");
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
                    inflateWheelsToMax();
                    break;
                case MenuOptions.eMenuOptions.RefuelGasolineVehicle:
                    refuelGasolineVehicle();
                    break;
                case MenuOptions.eMenuOptions.ChargingElectricVehicle:
                    chargingElectricVehicle();
                    break;
                case MenuOptions.eMenuOptions.ShowVehicleDetails:
                    showVehicleDetails();
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
                if ((o_UserChoice >= MenuOptions.GetMinOption()) && (o_UserChoice <= MenuOptions.GetMaxOption()))
                {
                    resultUserChoice = (MenuOptions.eMenuOptions)o_UserChoice;
                }
                else
                {
                    throw new ValueOutOfRangeException(MenuOptions.GetMinOption(), MenuOptions.GetMaxOption());
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
                vechileType = getVechileType();
                Console.Write("Please enter owner name: ");
                ownerName = Console.ReadLine();
                Console.Write("Please enter owner's phone number: ");
                ownerPhoneNumber = Console.ReadLine();
                m_Garage.AddVehicleToGarage(licenseNumber, vechileType, ownerName, ownerPhoneNumber);
                try
                {
                    updateDetails(m_Garage.VehicleFilesDict[licenseNumber].Vehicle, vechileType);
                }
                catch (Exception ex)
                {
                    m_Garage.VehicleFilesDict.Remove(licenseNumber);
                    throw ex;
                }
                Console.WriteLine("Vehicle added successfully.");
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
                if ((o_UserChoice >= VehicleType.GetMinOption()) && (o_UserChoice <= VehicleType.GetMaxOption()))
                {
                    resultUserChoice = (VehicleType.eVehicleType)o_UserChoice;
                }
                else
                {
                    throw new ValueOutOfRangeException(VehicleType.GetMinOption(), VehicleType.GetMaxOption());
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
            String modelName;

            Console.Write("Please enter car model name: ");
            modelName = Console.ReadLine();
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
            Color.eColor carColor;
            DoorsNumber.eDoorsNumber carDoorsNumber;

            printColorOptions();
            carColor = getCarColor();
            i_Car.Color = carColor;
            printDoorsOptions();
            carDoorsNumber = getDoorsNumber();
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
                if ((o_UserChoice >= Color.GetMinOption()) && (o_UserChoice <= Color.GetMaxOption()))
                {
                    resultUserChoice = (Color.eColor)o_UserChoice;
                }
                else
                {
                    throw new ValueOutOfRangeException(Color.GetMinOption(), Color.GetMaxOption());
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
                if ((o_UserChoice >= DoorsNumber.GetMinOption()) && (o_UserChoice <= DoorsNumber.GetMaxOption()))
                {
                    resultUserChoice = (DoorsNumber.eDoorsNumber)o_UserChoice;
                }
                else
                {
                    throw new ValueOutOfRangeException(DoorsNumber.GetMinOption(), DoorsNumber.GetMaxOption());
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
            LicenseType.eLicenseType licenseType;

            printMotorcycleLicenseTypeOptions();
            licenseType = getLicenseType();
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
            String licenseTypeChoice = Console.ReadLine();
            LicenseType.eLicenseType resultUserChoice;

            if (int.TryParse(licenseTypeChoice, out int o_UserChoice))
            {
                if ((o_UserChoice >= LicenseType.GetMinOption()) && (o_UserChoice <= LicenseType.GetMaxOption()))
                {
                    resultUserChoice = (LicenseType.eLicenseType)o_UserChoice;
                }
                else
                {
                    throw new ValueOutOfRangeException(LicenseType.GetMinOption(), LicenseType.GetMaxOption());
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
            Console.Write("Please enter motorcycle's engine displacement: ");
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
            float currentEnergy;

            if (i_Vehicle.EnergyType is Gasoline)
            {
                Console.Write("Please enter your current fuel amount (liters): ");
            }
            else
            {
                Console.Write("Please enter your current battery amount (hours): ");
            }
            currentEnergy = getCurrentEenergyAmount();
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
            float wheelsCurrentAirPressure;

            Console.Write("Please enter your wheel's manufacturer name: ");
            wheelsManufacturerName = getManufacturerName();
            Console.Write("Please enter your wheel's current air pressure: ");
            wheelsCurrentAirPressure = getCurrentAirPressure();
            m_Garage.SetWheelsDetails(i_Vehicle.LicenseNumber, wheelsManufacturerName, wheelsCurrentAirPressure);
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
            int filterOption;
            List<String> licenseNumbersList;

            printLicenseNumberFilterOptions();
            filterOption = getStatusOption(k_WithFilterOption);
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
                if ((o_UserChoice >= VehicleStatus.GetMinOption()) && (o_UserChoice <= VehicleStatus.GetMaxOption()))
                {
                    resultUserChoice = o_UserChoice;
                }
                else if (i_WithFilterOption && o_UserChoice == k_NoFilter)
                {
                    resultUserChoice = k_NoFilter;
                }
                else
                {
                    throw new ValueOutOfRangeException(VehicleStatus.GetMinOption(), VehicleStatus.GetMaxOption());
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

        private void printReturnToMenu(bool i_ExitFromSystem)
        {
            if (!i_ExitFromSystem)
            {
                Console.Write("To return to the main menu, please press Enter... ");
            }
            else
            {
                Console.Write("Thank you and goodbye...");
            }

            Console.ReadLine();
        }

        private void changeVehicleStatus()
        {
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

        private void printNewStatusOptions()
        {
            Console.WriteLine("Enter your new status option: ");
            Console.WriteLine("1. In repair vehicles");
            Console.WriteLine("2. Fixed vehicles");
            Console.WriteLine("3. Paid vehicles");
        }

        private String getLicenseNumber()
        {
            String licenseNumber;

            Console.Write("Please enter license vehicle number: ");
            licenseNumber = Console.ReadLine();
            if (String.IsNullOrEmpty(licenseNumber))
            {
                throw new ArgumentException("License number cannot be null or empty.");
            }

            return licenseNumber;
        }

        private void updateVehicleStatus(String i_LicenseNumber)
        {
            VehicleStatus.eVehicleStatus statusOption;

            printNewStatusOptions();
            statusOption = (VehicleStatus.eVehicleStatus)getStatusOption(!k_WithFilterOption);
            m_Garage.SetNewStatus(i_LicenseNumber, statusOption);
            Console.WriteLine($"The vehicle with license number: {i_LicenseNumber} has been successfully updated to status '{statusOption}'.");
        }

        private void printVehicleNotInGarage(String i_LicenseNumber)
        {
            Console.WriteLine($"The vehicle with license number: {i_LicenseNumber} is not in the garage");
        }

        private void inflateWheelsToMax()
        {
            String licenseNumber = getLicenseNumber();

            if (isVehicleInGarageOrNotify(licenseNumber))
            {
                m_Garage.SetWheelsPressureToMax(licenseNumber);
                Console.WriteLine($"The wheels on vehicle with license number: {licenseNumber} were successfully inflated to maximum pressure.");
            }
        }

        private bool isVehicleInGarageOrNotify(String i_LicenseNumber)
        {
            bool vehicleInGarage = true;

            if (!m_Garage.VehicleInGarage(i_LicenseNumber))
            {
                vehicleInGarage = false;
                printVehicleNotInGarage(i_LicenseNumber);
            }

            return vehicleInGarage;
        }

        private void refuelGasolineVehicle()
        {
            String licenseNumber = getLicenseNumber();

            if (isVehicleInGarageOrNotify(licenseNumber) && isGasolineVehicleOrNotify(licenseNumber))
            {
                GasType.eGasType gasTypeChoice = getGasType();
                float energyAmountChoice;

                Console.Write("Please enter fuel amount: ");
                energyAmountChoice = getEnergyAmount();
                m_Garage.refuelVehicle(m_Garage.VehicleFilesDict[licenseNumber].Vehicle, energyAmountChoice, gasTypeChoice);
                Console.WriteLine("The vehicle fueled successfully.");
            }
        }

        private GasType.eGasType getGasType()
        {
            String gasTypeChoice;
            GasType.eGasType resultUserChoice;

            printGasTypeOptions();
            gasTypeChoice = Console.ReadLine();
            if (int.TryParse(gasTypeChoice, out int o_UserChoice))
            {
                if ((o_UserChoice >= GasType.GetMinOption()) && (o_UserChoice <= GasType.GetMaxOption()))
                {
                    resultUserChoice = (GasType.eGasType)o_UserChoice;
                }
                else
                {
                    throw new ValueOutOfRangeException(GasType.GetMinOption(), GasType.GetMaxOption());
                }
            }
            else
            {
                throw new ArgumentException("Invalid input\n");
            }

            return resultUserChoice;
        }

        private bool isGasolineVehicleOrNotify(String i_LicenseNumber)
        {
            bool isGasolineVehicle;

            isGasolineVehicle = m_Garage.VehicleFilesDict[i_LicenseNumber].Vehicle.EnergyType is Gasoline;
            if (!isGasolineVehicle)
            {
                Console.WriteLine("The vehicle is not fuel type.");
            }

            return isGasolineVehicle;
        }

        private float getEnergyAmount()
        {
            String energyAmountChoice = Console.ReadLine();

            if (!float.TryParse(energyAmountChoice, out float o_UserChoice))
            {
                throw new FormatException("Must be a float.\n");
            }

            return o_UserChoice;
        }

        private void printGasTypeOptions()
        {
            Console.WriteLine("Please enter gas type: ");
            Console.WriteLine("1. Soler");
            Console.WriteLine("2. Octan95");
            Console.WriteLine("3. Octan96");
            Console.WriteLine("4. Octan98");
        }

        private void chargingElectricVehicle()
        {
            String licenseNumber = getLicenseNumber();

            if (isVehicleInGarageOrNotify(licenseNumber) && isElectricVehicleOrNotify(licenseNumber))
            {
                Console.Write("Please enter the number of battery hours for charging: ");
                float energyAmountChoice = getEnergyAmount();
                m_Garage.refuelVehicle(m_Garage.VehicleFilesDict[licenseNumber].Vehicle, energyAmountChoice);
                Console.WriteLine("The vehicle charged successfully.");
            }
        }

        private bool isElectricVehicleOrNotify(String i_LicenseNumber)
        {
            bool isElectricVehicle;

            isElectricVehicle = m_Garage.VehicleFilesDict[i_LicenseNumber].Vehicle.EnergyType is Electric;
            if (!isElectricVehicle)
            {
                Console.WriteLine("The vehicle is not electric type.");
            }

            return isElectricVehicle;
        }

        private void showVehicleDetails()
        {
            String licenseNumber = getLicenseNumber();

            if (isVehicleInGarageOrNotify(licenseNumber))
            {
                displayVehicleData(licenseNumber);
            }
        }

        private void displayVehicleData(String i_LicenseNumber)
        {
            Console.WriteLine("============================================");
            displayVechileFileDetails(i_LicenseNumber);
            displayVechileTypeDetails(i_LicenseNumber);
            displayVechileDetails(i_LicenseNumber);
            displayVechileEnergyType(i_LicenseNumber);
        }

        private void displayVechileDetails(String i_LicenseNumber)
        {
            foreach (KeyValuePair<string, string> kvp in m_Garage.VehicleFilesDict[i_LicenseNumber].Vehicle.ShowVehicle())
            {
                Console.WriteLine($"{kvp.Key}{kvp.Value}");
            }
        }

        private void displayVechileTypeDetails(String i_LicenseNumber)
        {
            foreach (KeyValuePair<string, string> kvp in m_Garage.VehicleFilesDict[i_LicenseNumber].Vehicle.ShowDetails())
            {
                Console.WriteLine($"{kvp.Key}{kvp.Value}");
            }
        }

        private void displayVechileEnergyType(String i_LicenseNumber)
        {
            foreach (KeyValuePair<string, string> kvp in m_Garage.VehicleFilesDict[i_LicenseNumber].Vehicle.EnergyType.ShowEnergyType())
            {
                Console.WriteLine($"{kvp.Key}{kvp.Value}");
            }
        }

        private void displayVechileFileDetails(String i_LicenseNumber)
        {
            foreach (KeyValuePair<string, string> kvp in m_Garage.VehicleFilesDict[i_LicenseNumber].ShowVehicleFile())
            {
                Console.WriteLine($"{kvp.Key}{kvp.Value}");
            }
        }
    }
}