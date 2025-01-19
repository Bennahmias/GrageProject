using System;

namespace Ex03.GarageLogic
{
    public class Color
    {
        public enum eColor
        {
            Blue = 1,
            Black = 2,
            Gray = 3,
            White = 4
        }

        public static int GetMinOption()
        {
            return (int)Enum.GetValues(typeof(eColor)).GetValue(0);
        }

        public static int GetMaxOption()
        {
            return (int)Enum.GetValues(typeof(eColor)).GetValue(Enum.GetValues(typeof(eColor)).Length - 1);
        }
    }
}
