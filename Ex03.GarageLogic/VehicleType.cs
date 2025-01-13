
using System;

namespace Ex03.GarageLogic
{
    public class VehicleType
    {
        public enum eVehicleType
        {
            ElectricCar,
            GasolineCar,
            ElectricMotorcycle,
            GasolineMotorcycle,
            GasolineTruck
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
