using System;
using System.Collections.Generic;

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
                throw new ValueOutOfRangeException(0.0f, MaxCapacity - CurrentCapacity);
            }
        }
        public override Dictionary<String, String> ShowEnergyType()
        {
            Dictionary<String, String> energyTypeDetails =
                new Dictionary<String, String>(3);
            energyTypeDetails.Add("Current battery hours: ", CurrentCapacity.ToString());
            energyTypeDetails.Add("Maximum battery hours: ", MaxCapacity.ToString());
            energyTypeDetails.Add("Battery hours percentage: ", EnergyPercentage.ToString() + "%");

            return energyTypeDetails;
        }
    }
}
