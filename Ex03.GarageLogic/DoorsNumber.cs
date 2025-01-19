using System;

namespace Ex03.GarageLogic
{
    public class DoorsNumber
    {
        public enum eDoorsNumber
        {
            Two = 1,
            Three = 2,
            Four = 3,
            Five = 4
        }

        public static int GetMinOption()
        {
            return (int)Enum.GetValues(typeof(eDoorsNumber)).GetValue(0);
        }

        public static int GetMaxOption()
        {
            return (int)Enum.GetValues(typeof(eDoorsNumber)).GetValue(Enum.GetValues(typeof(eDoorsNumber)).Length - 1);
        }
    }
}
