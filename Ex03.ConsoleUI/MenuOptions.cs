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
            ShowVehicleDetails = 7,
            ExitTheSystem = 8,
            InitializeInput = 9
        }

        public static int GetMinOption()
        {
            return (int)Enum.GetValues(typeof(eMenuOptions)).GetValue(0);
        }
        public static int GetMaxOption()
        {
            return (int)Enum.GetValues(typeof(eMenuOptions)).GetValue(Enum.GetValues(typeof(eMenuOptions)).Length - 1) - 1;
        }
    }
}
