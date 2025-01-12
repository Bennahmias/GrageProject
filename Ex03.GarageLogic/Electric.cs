using System;

namespace Ex03.GarageLogic
{
    public class Electric : EnergyType
    {
        public Electric(float i_MaxBatteryTime) : base(i_MaxBatteryTime) { }
        public void BatteryCharging(float i_HoursToAddToBattery)
        {
            if (m_CurrentCapacity + i_HoursToAddToBattery <= m_MaxCapacity)
            {
                m_CurrentCapacity += i_HoursToAddToBattery;
            }
            else
            {
                //TODO: trow exception of ValueOutOfRangeException
            }
        }


    }
}
