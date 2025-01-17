using System;

namespace Ex03.GarageLogic
{
    public class VehicleStatus
    {
        public enum eVehicleStatus
        {
            InRepair = 1,
            Fixed = 2,
            Paid = 3
        }

        public static int GetMinOption()
        {
            return (int)Enum.GetValues(typeof(eVehicleStatus)).GetValue(0);
        }
        public static int GetMaxOption()
        {
            return (int)Enum.GetValues(typeof(eVehicleStatus)).GetValue(Enum.GetValues(typeof(eVehicleStatus)).Length - 1);
        }
    }
}
