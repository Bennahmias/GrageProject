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

        public static int getMinOption()
        {
            return (int)Enum.GetValues(typeof(eMenuOptions)).GetValue(0);
        }
        public static int getMaxOption()
        {
            return (int)Enum.GetValues(typeof(eMenuOptions)).GetValue(Enum.GetValues(typeof(eMenuOptions)).Length - 1);
        }
    }
}
