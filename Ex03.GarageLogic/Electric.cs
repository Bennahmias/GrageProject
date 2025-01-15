using System;

namespace Ex03.GarageLogic
{
    public class Electric : EnergyType
    {
        public Electric(float i_MaxBatteryTime) : base(i_MaxBatteryTime) { }
        public void BatteryCharging(float i_HoursToAddToBattery)
        {
            if (CurrentCapacity + i_HoursToAddToBattery <= MaxCapacity)
            {
                CurrentCapacity += i_HoursToAddToBattery;
                SetEnergyPercentage();
            }
            else
            {
                throw new ValueOutOfRangeException(0.0f, MaxCapacity);
            }
        }


    }
}
