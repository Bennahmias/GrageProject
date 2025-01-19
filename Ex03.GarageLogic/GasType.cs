using System;

namespace Ex03.GarageLogic
{
    public class GasType
    {
        public enum eGasType
        {
            Soler = 1,
            Octan95 = 2,
            Octan96 = 3,
            Octan98 = 4
        }

        public static int GetMinOption()
        {
            return (int)Enum.GetValues(typeof(eGasType)).GetValue(0);
        }

        public static int GetMaxOption()
        {
            return (int)Enum.GetValues(typeof(eGasType)).GetValue(Enum.GetValues(typeof(eGasType)).Length - 1);
        }
    }
}
