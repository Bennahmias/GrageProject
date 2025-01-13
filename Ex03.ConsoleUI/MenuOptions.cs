using System;

namespace Ex03.ConsoleUI
{
    public class MenuOptions
    {
        public enum eMenuOptions
        {
            AddNewCar = 1,
            ShowListOfLicenseNumbers = 2,
            ChangeVehicleStatus = 3, 
            InflateWheelsToMax = 4, 
            RefuelGasolineVehicle = 5, 
            ChargingElectricVehicle = 6, 
            ShowAllVehicleDetails = 7, 
            ExitTheSystem = 8
        }
    }
}
