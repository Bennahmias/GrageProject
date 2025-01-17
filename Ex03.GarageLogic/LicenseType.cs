using System;

namespace Ex03.GarageLogic
{
    public class LicenseType
    {
        public enum eLicenseType
        {
            A1 = 1,
            A2 = 2,
            B1 = 3,
            B2 = 4
        }

        public static int GetMinOption()
        {
            return (int)Enum.GetValues(typeof(eLicenseType)).GetValue(0);
        }
        public static int GetMaxOption()
        {
            return (int)Enum.GetValues(typeof(eLicenseType)).GetValue(Enum.GetValues(typeof(eLicenseType)).Length - 1);
        }
    }
}
