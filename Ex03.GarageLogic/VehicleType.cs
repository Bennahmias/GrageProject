
using System;

namespace Ex03.GarageLogic
{
    public class VehicleType
    {
        public enum eVehicleType
        {
            ElectricCar = 1,
            GasolineCar = 2,
            ElectricMotorcycle = 3,
            GasolineMotorcycle = 4,
            GasolineTruck = 5
        }

        public static int getMinOption()
        {
            return (int)Enum.GetValues(typeof(eVehicleType)).GetValue(0);
        }
        public static int getMaxOption()
        {
            return (int)Enum.GetValues(typeof(eVehicleType)).GetValue(Enum.GetValues(typeof(eVehicleType)).Length - 1);
        }
    }
}
